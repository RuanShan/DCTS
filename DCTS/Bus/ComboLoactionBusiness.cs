using DCTS.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{
    

    class ComboLoactionBusiness
    {

        public static List<ComboLocation> Paginate(ComboLocationEnum locationType, int currentPage = 1, int pageSize = 25, string nation = "", string city = "", string title = "")
        {
            // 如果数据为0，分页控件，设置currentPage = 0; 这回导致下面查询异常
            if (currentPage <= 0)
            {
                currentPage = 1;
            }
            List<ComboLocation> list = new List<ComboLocation>();

            using (var ctx = new DctsEntities())
            {

                var query = ctx.ComboLocations.Where(o => o.ltype == (int)locationType);

                if (nation.Length > 0 )
                {
                    query = query.Where(o => o.nation == nation);
                }
                if (city.Length > 0 )
                {
                    query = query.Where(o => o.city == city);
                }
                if (title.Length > 0)
                {
                    query = query.Where(o => o.city.Contains(city));
                }

                if (pageSize > 0)
                {
                    int offset = (currentPage-1) * pageSize;
                    // order is required before skip
                    query = query.OrderBy(o => o.id).Skip(offset).Take(pageSize);
                }
                list = query.ToList();

            }
            return list;   
        }


        public static int Count( ComboLocationEnum locationType, string nation, string city, string title)
        {
            int count = 0;
            using (var ctx = new DctsEntities())
            {
                var query = ctx.ComboLocations.AsQueryable();
                
                if ((int)locationType > 0)
                {
                    query = query.Where(o => o.ltype == (int)ComboLocationEnum.Scenic);

                }
                if (nation.Length > 0 )
                {
                    query = query.Where(o => o.nation == nation);
                }

                if (city.Length > 0 )
                {
                    query = query.Where(o => o.city == city);
                }

                if (title.Length > 0)
                {
                    query = query.Where(o => o.city.Contains(city));
                }
                count = query.Count();
            }
            return count;
        }


        public static void Delete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var model = ctx.ComboLocations.Find(id);
                var days = model.DayLocations;
                ctx.DayLocations.RemoveRange(days);
                ctx.ComboLocations.Remove(model);
                ctx.SaveChanges();
                // 无需删除图片                

                // 检查word是否存在？
                if (model.word != null && model.word.Length > 0)
                {
                    string path = EntityPathHelper.LocationWordPath(model);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }

        }

        public static void nationsDelete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var model = ctx.Nations.Find(id);
               
                ctx.Nations.Remove(model);
                ctx.SaveChanges();
            }

        }

        public static void locaimageDelete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var model = ctx.LocationImages.Find(id);
                
                ctx.LocationImages.Remove(model);
                ctx.SaveChanges();
            }

        }
        public static void Supplier_Delete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var model = ctx.Suppliers.Find(id);
              
                ctx.Suppliers.Remove(model);
                ctx.SaveChanges();
            }

        }
        public static void Schedules_Delete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var model = ctx.Schedules.Find(id);

                ctx.Schedules.Remove(model);
                ctx.SaveChanges();
            }

        }

        public static void Customer_Delete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var trips = new List<Trip>();
                var model = ctx.Customers.Find(id);
                var tripCustomers = model.TripCustomers.ToList(); 
                foreach (var tc in tripCustomers)
                {
                    trips.Add(tc.Trip);                    
                }
                ctx.TripCustomers.RemoveRange(tripCustomers);

                foreach (var trip in trips)
                {
                    //如果当前trip没有其他Customer,则删除。
                    if ( !trip.TripCustomers.Any(o=>o.customer_id != model.id))
                    {                        
                        TripBusiness.Delete(trip.id);
                    }
                }
                ctx.Tickets.RemoveRange(model.Tickets);
                ctx.Customers.Remove(model);
                ctx.SaveChanges();
            }

        }
        public static string DisplayOpeningHours(ComboLocation location)
        {
            string str = string.Empty;
            if (location.open_at != null && location.close_at != null)
            {
                str = String.Format("{0:HH:mm}-{1:HH:mm}", location.open_at, location.close_at);
            }

            return str;
        }

        //处理图片 image_path
        public static bool ProcessImage(ComboLocation location)
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
            else { 
                //图片为相对路径，系统素材相对路径中图片
            
            }

            return true;
        }


        //检验新的location,字段是否正确。
        public static bool Validate(ComboLocation location)
        {
            //如果为新创建， id =0
            int id = location.id;
            bool valid = true;

            string title = location.title;
            string image_path = location.image_path;
            using( var ctx = new DctsEntities())
            {
                if (title.Length == 0)
                {
                    throw new DbEntityValidationException("名称不能为空");
                }
                if (title.Length > 120)
                {
                    throw new DbEntityValidationException(string.Format("名称<{0}>字数超过>120。", title));
                } 
                var existTitle = (ctx.ComboLocations.Where(o => o.title == title && o.id != id).Count() > 0);

                if (existTitle)
                {
                    throw new DbEntityValidationException(string.Format("名称<{0}>已存在。", title));            
                }

                if (image_path.Length > 0)
                {                   
                    //FIXME
                    //如果 imgFileName ！= img， 即 img 中包含路径信息， 修改和更新都可能发生。
                    //如果 路径不是 ImageBasePath  即 /data/image, 不需要检查素材是否存在，form 窗口已提示重名，用户点击保存，覆盖即可                    
                }

            }
            return valid;
        }

        //检验 location 是否可以被删除，主要检验外键约束，如 机场，住宿是否被票务引用，
        public static bool ValidateForDelete(ComboLocation location)
        {
            int id = location.id;
            bool valid = true;

            string title = location.title;

            using (var ctx = new DctsEntities())
            {
               //  throw new DbEntityValidationException("名称不能为空");
            }
            return valid;
        }

        public static bool ExistsLocationTitle(DctsEntities ctx, string title)
        {

            return  (ctx.ComboLocations.Where(o=>o.title == title).Count() > 0);

        }


        public static List<ComboLocation> TypedLocation(DctsEntities ctx, ComboLocationEnum locationType)
        {
            var query = ctx.ComboLocations.Where(o => o.ltype == (int)locationType);

            return query.ToList();
        }
    }
}
