﻿using System;
using System.Collections.Generic;
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
                var days = model.Days;
                ctx.Days.RemoveRange(days);
                ctx.ComboLocations.Remove(model);
                ctx.SaveChanges();
            }

        }


    }
}
