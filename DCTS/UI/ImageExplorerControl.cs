using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DCTS.DB;

namespace DCTS.UI
{
    public partial class ImageExplorerControl : UserControl
    {
        public ImageExplorerControl()
        {
            InitializeComponent();
            string basePath = EntityPathHelper.ImageBasePath;
            var uri = new Uri(basePath);
            this.shellTreeView1.RootFolder = new GongSolutions.Shell.ShellItem(uri);
            
        }

        private void shellNotificationListener1_FolderRenamed(object sender, GongSolutions.Shell.ShellItemChangeEventArgs e)
        {
            string msg = string.Format("rename folder {0} to {1}", e.OldItem.DisplayName, e.NewItem.DisplayName);
            Console.WriteLine(msg);

            RenameFolderName(e.OldItem, e.NewItem);
        }

        private void shellNotificationListener1_ItemRenamed(object sender, GongSolutions.Shell.ShellItemChangeEventArgs e)
        {
            string msg = string.Format("rename file {0} to {1}", e.OldItem.DisplayName, e.NewItem.DisplayName);
            Console.WriteLine(msg);
            RenameImageName(e.OldItem, e.NewItem);
        }


        private void RenameImageName(GongSolutions.Shell.ShellItem oldItem, GongSolutions.Shell.ShellItem newItem)
        {
            string basePath = EntityPathHelper.ImageBasePath;
            string oldAbsolutePath = oldItem.FileSystemPath;
            string newAbsolutePath = newItem.FileSystemPath;

            //跳过其他目录修正事件
            if (!oldAbsolutePath.Contains(basePath))
            {
                return;
            }

            string oldRelativePath = oldAbsolutePath.Substring(basePath.Length);
            string newRelativePath = newAbsolutePath.Substring(basePath.Length);
            using (var db = new DctsEntities())
            { 

                // 更新combolocation
                string updateLocationSql = string.Format("UPDATE ComboLocations SET `image_path`='{0}' WHERE `image_path`='{1}';", newRelativePath, oldRelativePath);
                // 更新trip
                string updateTripSql = string.Format("UPDATE Trips SET `image_path`='{0}' WHERE `image_path`='{1}';", newRelativePath, oldRelativePath);

                // 更新tripDay
                string updateTripDaySql = string.Format("UPDATE TripDays SET `image_path`='{0}' WHERE `image_path`='{1}';", newRelativePath, oldRelativePath);

                db.Database.ExecuteSqlCommand(updateLocationSql);
                db.Database.ExecuteSqlCommand(updateTripSql);
                db.Database.ExecuteSqlCommand(updateTripDaySql);

            }
        }

        private void RenameFolderName(GongSolutions.Shell.ShellItem oldItem, GongSolutions.Shell.ShellItem newItem)
        {
            string basePath = EntityPathHelper.ImageBasePath;
            string oldAbsolutePath = oldItem.FileSystemPath;
            string newAbsolutePath = newItem.FileSystemPath;
            //跳过其他目录修正事件
            if (!oldAbsolutePath.Contains(basePath))
            {
                return;
            }

            string oldRelativePath = oldAbsolutePath.Substring(basePath.Length);
            string newRelativePath = newAbsolutePath.Substring(basePath.Length);
            using (var db = new DctsEntities())
            {
                string safeOldRelativePath = MySql.Data.MySqlClient.MySqlHelper.EscapeString(oldRelativePath);
                string safeNewRelativePath = MySql.Data.MySqlClient.MySqlHelper.EscapeString(newRelativePath);
                //if (oldRelativePath.Contains(System.IO.Path.DirectorySeparatorChar.ToString()))
                {   // 子路经 abc/xxx 
                    // 更新combolocation
                    //REPLACE('www.roseindia.net', 'w', 'W');
                    //SUBSTRING('foobarbar' FROM 4)
                    //string replace = string.Format("REPLACE(`image_path`, '{0}', '{1}')", oldRelativePath, newRelativePath);
                    // 考虑中文符集
                    string replaceSql = string.Format("`image_path` = CONCAT('{0}',SUBSTRING(`image_path`, CHAR_LENGTH('{1}')+1))", safeNewRelativePath, safeOldRelativePath);
                    // id>0 Error Code: 1175. You are using safe update mode
                    string whereSql = string.Format(" id>0 AND SUBSTRING(`image_path` , 1, CHAR_LENGTH('{0}'))='{1}'", safeOldRelativePath, safeOldRelativePath);

                    string updateLocationSql = string.Format("UPDATE ComboLocations SET {0} WHERE {1};", replaceSql, whereSql);
                    // 更新trip
                    string updateTripSql = string.Format("UPDATE Trips  SET {0} WHERE  {1};", replaceSql, whereSql);

                    // 更新tripDay
                    string updateTripDaySql = string.Format("UPDATE TripDays SET {0} WHERE {1};", replaceSql, whereSql);

                    db.Database.ExecuteSqlCommand(updateLocationSql);
                    db.Database.ExecuteSqlCommand(updateTripSql);
                    db.Database.ExecuteSqlCommand(updateTripDaySql);

                }
               

            }
        }

        private void shellNotificationListener1_FolderCreated(object sender, GongSolutions.Shell.ShellItemEventArgs e)
        {
            string msg = string.Format("folder created {0}  ", e.Item.DisplayName);
            Console.WriteLine(msg);
        }

        private void shellNotificationListener1_FolderDeleted(object sender, GongSolutions.Shell.ShellItemEventArgs e)
        {
            string msg = string.Format("folder deleted {0}  ", e.Item.DisplayName);
            Console.WriteLine(msg);
            RemoveFolderOrFile(e.Item);
        }

        private void shellNotificationListener1_FolderUpdated(object sender, GongSolutions.Shell.ShellItemEventArgs e)
        {
            string msg = string.Format("folder updated {0}  ", e.Item.DisplayName);
            Console.WriteLine(msg);
        }

        private void shellNotificationListener1_ItemDeleted(object sender, GongSolutions.Shell.ShellItemEventArgs e)
        {
            string msg = string.Format("file deleted {0}  ", e.Item.DisplayName);
            Console.WriteLine(msg);
            RemoveFolderOrFile(e.Item);

        }

        private void shellNotificationListener1_ItemCreated(object sender, GongSolutions.Shell.ShellItemEventArgs e)
        {
            string msg = string.Format("file created {0}  ", e.Item.DisplayName);
            Console.WriteLine(msg);
        }

        private void shellView1_DragDrop(object sender, DragEventArgs e)
        {
             
            string msg = string.Format("DragDrop event ");
            Console.WriteLine(msg);
        }


        private void RemoveFolderOrFile(GongSolutions.Shell.ShellItem item )
        {
            string basePath = EntityPathHelper.ImageBasePath;
            string absolutePath = item.FileSystemPath;

            //跳过其他目录修正事件
            if (!absolutePath.Contains(basePath))
            {
                return;
            }

            string relativePath = absolutePath.Substring(basePath.Length);
             using (var db = new DctsEntities())
            {
                string safeOldRelativePath = MySql.Data.MySqlClient.MySqlHelper.EscapeString(relativePath);

                //if (oldRelativePath.Contains(System.IO.Path.DirectorySeparatorChar.ToString()))
                {   // 子路经 abc/xxx 
                    // 更新combolocation
                    //REPLACE('www.roseindia.net', 'w', 'W');
                    //SUBSTRING('foobarbar' FROM 4)
                    string replaceSql =  "`image_path`=''";
                    // 考虑中文符集
                    // id>0 Error Code: 1175. You are using safe update mode
                    string whereSql = string.Format(" id>0 AND SUBSTRING(`image_path` , 1, CHAR_LENGTH('{0}'))='{1}'", safeOldRelativePath, safeOldRelativePath);

                    string updateLocationSql = string.Format("UPDATE ComboLocations SET {0} WHERE {1};", replaceSql, whereSql);
                    // 更新trip
                    string updateTripSql = string.Format("UPDATE Trips  SET {0} WHERE  {1};", replaceSql, whereSql);
                    // 更新tripDay
                    string updateTripDaySql = string.Format("UPDATE TripDays SET {0} WHERE {1};", replaceSql, whereSql);

                    db.Database.ExecuteSqlCommand(updateLocationSql);
                    db.Database.ExecuteSqlCommand(updateTripSql);
                    db.Database.ExecuteSqlCommand(updateTripDaySql);

                }


            }
        }
    }
}
