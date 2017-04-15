using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTS.Bus
{
    class ScenicDbHelper
    {
        public static void Delete(long id)
        {
            using (var ctx = new DctsEntities())
            {
                var model = ctx.Scenics.Find(id);

                ctx.Scenics.Remove(model);

                ctx.SaveChanges();
            }

        }
    }
}
