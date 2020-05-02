using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using Emulator.Static_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Emulator.Storing
{
    public class StoringActions
    {
        public static DataTable GetStoringZones()
        {
            return Sql.GetTable("GetStorageZones", new object[] { "@Whid", GlobalUser.CurrentWarehouseId });
        }

        public static void MovePallet()
        {
            string PalletId = NullCheck.IsNullString(Sql.GetString($"SELECT dbo.GetPalletId('{Cache.ReturnValueByKey("@Barcode")}')"));

            Sql.ExecuteCmd("MovePallet", new object[] {
                "@ToZoneId", Cache.ReturnValueByKey("@Location"),
                "@Whid", GlobalUser.CurrentWarehouseId,
                "@PalletId", PalletId
            });
        }
    }
}
