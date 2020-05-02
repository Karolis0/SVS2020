using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using Emulator.Static_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Emulator.Shipping
{
    public class ShippingActions
    {
        public static DataTable GetShipping()
        {
            return Sql.GetTable("GetShippingByWhId", new object[] { "@WhId", GlobalUser.CurrentWarehouseId });
        }

        public static DataTable GetRelatedCU()
        {
            return Sql.GetTable("GetRelatedCUForLoading", new object[] { "@ParcelId", Cache.ReturnValueByKey("@ShippingId") });
        }

        public static void LoadCU(int PalletId)
        {
            Sql.ExecuteCmd("LoadCU", new object[] { "@PalletId", PalletId });
        }
    }
}
