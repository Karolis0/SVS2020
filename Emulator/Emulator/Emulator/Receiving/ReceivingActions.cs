using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using Emulator.Static_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Emulator.Receiving
{
    public class ReceivingActions
    {
        public static int ZoneExists (string ZoneCode)
        {
            return NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateReceivingLocation('{GlobalUser.CurrentWarehouseId}','{ZoneCode}')"));
        }

        public static DataTable GetReceivingItemList()
        {
            return Sql.GetTable("GetOrderedItemsByReceivingDocId", new object[] { "@ReceivingDocId", Parameters.ReturnValueByKey("@RcvDocId") });
        }

        public static DataTable GetReceivingDocuments()
        {
            return Sql.GetTable("GetInProcessRcvDocs", new object[] { "@WhId", GlobalUser.CurrentWarehouseId });
        }

        public static void SavePalletToZone()
        {
            string PalletBarcode = Parameters.ReturnValueByKey("@Barcode");
            string ZoneCode = Parameters.ReturnValueByKey("@Location");

            Sql.ExecuteCmd("SavePalletToZone", new object[]
            {
                "@ZoneCode", ZoneCode,
                "@Whid", GlobalUser.CurrentWarehouseId,
                "@Barcode", PalletBarcode,
                "@Created", DateTime.Now,
                "@Updated", DateTime.Now
            });
        }

        public static void SaveItemsToZoneAndPallet(DataTable dt)
        {
            string PalletId = NullCheck.IsNullString(Sql.GetString($"SELECT dbo.GetPalletId('{Parameters.ReturnValueByKey("@Barcode")}')"));
            DataTable Insert = ProcessDataTableQuantityById(dt);
            foreach (DataRow row in Insert.Rows)
            {
                Sql.ExecuteCmd("SaveStoredItem", new object[] {
                    "@PalletId", PalletId,
                    "@ItemId", row["ItemId"],
                    "@Created", DateTime.Now,
                    "@Updated", DateTime.Now,
                    "@Quantity", row["Quantity"]
                });
            }
            
        }

        public static void FinishReceivingDoc()
        {
            Sql.ExecuteCmd("SetRcvDocFinished", new object[] { "@RcvDocId", Parameters.ReturnValueByKey("@RcvDocId") });
        }

        public static string GetSuggestedReceivingZone()
        {
            return Sql.GetString($"SELECT dbo.GetFirstReceivingLocation('{GlobalUser.CurrentWarehouseId}')");
        }

        private static DataTable ProcessDataTableQuantityById(DataTable dt)
        {
            DataTable clone = dt.Clone();

            foreach(DataRow row in dt.Rows)
            {
                DataRow _row = clone.AsEnumerable().Where(x => x.Field<int>("ItemId") == NullCheck.IsNullInt(row["ItemId"])).FirstOrDefault();

                if (_row == null)
                {
                    clone.Rows.Add(row.ItemArray);
                }
                else
                {
                    _row["Quantity"] = NullCheck.IsNullDecimal(_row["Quantity"]) + NullCheck.IsNullDecimal(row["Quantity"]);
                }
            }

            return clone;
        }
    }
}
