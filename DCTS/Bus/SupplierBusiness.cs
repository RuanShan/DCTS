using DCTS.DB;
using System;
using System.Collections.Generic;
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
    }
}
