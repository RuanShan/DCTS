using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;

namespace DCTS.Uti
{
    class DBConfiguration
    {
        /// 
        /// 获取ConnectionStrings 
        /// 
        /// 
        /// 
        public static Dictionary<string, string> ConnectionSettings()
        {
            var ctx = new DctsEntities();
            string connectionString = GetConnectionString();
            Dictionary<string,string> setting = new Dictionary<string,string>();
            //"server=127.0.0.1;user id=root;database=dcts_dev;allowuservariables=True;characterset=utf8"
            string[] kvs = connectionString.Split(';');
            foreach (string kv in kvs)
            {
                var key_val = kv.Split('=');
                setting[key_val[0]] = key_val[1];
            }           
            // 设置 password, importsql 使用
            if (!setting.ContainsKey("password"))
            {
                setting["password"] = String.Empty;
            }

            return setting;
        }
       
            /// 
            /// 获取ConnectionStrings 
            /// 
            /// 
            /// 
            public static string GetConnectionString( )
            {
                var ctx = new DctsEntities();

               
                return ctx.Database.Connection.ConnectionString;
            }

            /// 
            /// 更新连接字符串 
            /// 
            /// 
            /// 
            /// 
            public static void SetConnectionString(string newName, string newConString, string newProviderName)
            {
                bool isModified = false;    //记录该连接串是否已经存在 
                if (ConfigurationManager.ConnectionStrings[newName] != null)
                {
                    isModified = true;
                }
                //新建一个连接字符串实例 
                ConnectionStringSettings mySettings = new ConnectionStringSettings(newName, newConString, newProviderName);

                // 打开可执行的配置文件*.exe.config 
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // 如果连接串已存在，首先删除它 
                if (isModified)
                {
                    config.ConnectionStrings.ConnectionStrings.Remove(newName);
                    // 将新的连接串添加到配置文件中. 
                    config.ConnectionStrings.ConnectionStrings.Add(mySettings);
                    // 保存对配置文件所作的更改 
                    config.Save(ConfigurationSaveMode.Modified);
                    // 强制重新载入配置文件的ConnectionStrings配置节  
                    ConfigurationManager.RefreshSection("ConnectionStrings");
                }
            }
        
    }
}
