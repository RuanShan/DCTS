﻿using DCTS.DB;
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

        public static void Delete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var model = ctx.ComboLocations.Find(id);
                var days = model.DayLocations;
                ctx.DayLocations.RemoveRange(days);
                ctx.ComboLocations.Remove(model);
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


        public static bool Validate(ComboLocation location)
        {
            bool valid = true;

            string title = location.title;
            string img = location.img;
            using( var ctx = new DctsEntities())
            {
                if (title.Length == 0)
                {
                    throw new DbEntityValidationException("景点名称不能为空");
                }

                if (ExistsLocationTitle(ctx, title))
                {
                    throw new DbEntityValidationException(string.Format("景点名称<{0}>已存在。", title));            
                }
                if (img.Length > 0)
                {
                    string imgFileName = Path.GetFileName(img);

                    if (ExistsLocationImageName(ctx, img))
                    {
                        throw new DbEntityValidationException(string.Format("景点图片<{0}>已存在。", imgFileName));                                    
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

    }
}
