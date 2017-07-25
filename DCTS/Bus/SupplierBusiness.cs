using DCTS.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{
    class SupplierBusiness
    {
        public static List<Supplier> TypedSuppliers(DctsEntities ctx, SupplierEnum supplierType)
        {
            var query = ctx.Suppliers.Where(o => o.stype == (int)supplierType);

            return query.ToList();
        }


        //处理图片 image_path
        public static bool ProcessImage(Supplier location)
        {
            // image_path 取值
            // 1. 为空，null, 缺省值
            // 2. string.empty
            // 3. 相对路径，用户素材图片路径
            // 4. 绝对路径，用户新选择了素材图片路径下的一个图片。
            // 5. 绝对路径，用户新选择了非素材路径下的一个图片。

            if (location.image_path == null || location.image_path.Length == 0)
            {
                return false;
            }

            string imgFilePath = location.image_path;
            string imgFileName = Path.GetFileName(imgFilePath);
            // 检查选择图片是否是素材目录下的，原有数据是相对路径
            // 如果是，直接设置image_path,image_name, 
            // 如果不是，需要检查素材目录下是否存在，
            //      如果存在 提示文件已存在，是否覆盖
            //      如果不存在，直接拷贝到素材目录下

            if (Path.IsPathRooted(imgFilePath))
            {
                if (imgFilePath.StartsWith(EntityPathHelper.ImageBasePath))
                {  // 用户选择素材目录下文件
                    string relativeImagePath = imgFilePath.Substring(EntityPathHelper.ImageBasePath.Length);
                    location.image_path = relativeImagePath;

                }
                else
                {
                    string copyToPath = Path.Combine(EntityPathHelper.ImageBasePath, imgFileName);
                    // 用户选择素材目录之外的图片
                    location.image_path = imgFileName;
                    File.Copy(imgFilePath, copyToPath, true);
                }
            }
            else
            {
                //图片为相对路径，系统素材相对路径中图片

            }

            return true;
        }

    }
}
