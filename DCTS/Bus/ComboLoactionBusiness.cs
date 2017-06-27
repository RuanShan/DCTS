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
                // 检查图片是否存在？
                if (model.img != null && model.img.Length > 0)
                {
                    string path = EntityPathConfig.LocationImagePath(model);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }

                // 检查word是否存在？
                if (model.word != null && model.word.Length > 0)
                {
                    string path = EntityPathConfig.LocationWordPath(model);
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
                var model = ctx.Customers.Find(id);
           
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

        //检验新的location,字段是否正确。
        public static bool Validate(ComboLocation location)
        {
            //如果为新创建， id =0
            int id = location.id;
            bool valid = true;

            string title = location.title;
            string img = location.img;
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

                if (img.Length > 0)
                {
                    string imgFileName = Path.GetFileName(img);
                    //如果 imgFileName ！= img， 即 img 中包含路径信息， 修改和更新都可能发生。
                    if (!imgFileName.Equals(img))
                    {

                        bool existSameImage = false;

                        existSameImage = (ctx.ComboLocations.Where(o => o.ltype == location.ltype && o.img == imgFileName && o.id != id).Count() > 0);

                        if (existSameImage)
                        {
                            throw new DbEntityValidationException(string.Format("图片<{0}>已存在。", imgFileName));                                    
                        }
                    }
                }

            }
            return valid;
        }

        public static bool ExistsLocationTitle(DctsEntities ctx, string title)
        {

            return  (ctx.ComboLocations.Where(o=>o.title == title).Count() > 0);

        }

        public static bool ExistsLocationImageName( DctsEntities ctx, string imgFileName, ComboLocationEnum ltype = ComboLocationEnum.Scenic)
        {
            bool existSameImage = false;
              
            existSameImage = (ctx.ComboLocations.Where(o=> o.img == imgFileName).Count() > 0);
            
            return existSameImage;
        }


        public static List<ComboLocation> TypedLocation(DctsEntities ctx, ComboLocationEnum locationType)
        {
            var query = ctx.ComboLocations.Where(o => o.ltype == (int)locationType);

            return query.ToList();
        }
    }
}
