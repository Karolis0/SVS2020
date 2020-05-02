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
            return Sql.GetTable("GetOrderedItemsByReceivingDocId", new object[] { "@ReceivingDocId", Cache.ReturnValueByKey("@RcvDocId") });
        }

        public static DataTable GetReceivingDocuments()
        {
            return Sql.GetTable("GetInProcessRcvDocs", new object[] { "@WhId", GlobalUser.CurrentWarehouseId });
        }

        public static void SavePalletToZone()
        {
            string PalletBarcode = Cache.ReturnValueByKey("@Barcode");
            string ZoneCode = Cache.ReturnValueByKey("@Location");

            Sql.ExecuteCmd("SavePalletToZone", new object[]
            {
                "@ZoneCode", ZoneCode,
                "@Whid", GlobalUser.CurrentWarehouseId,
                "@Barcode", PalletBarcode,
                "@Created", DateTime.Now,
                "@Updated", DateTime.Now,
                "@RcvDocId", Cache.ReturnValueByKey("@RcvDocId")
            });
        }

        public static void SaveItemsToZoneAndPallet(DataTable dt)
        {
            string PalletId = NullCheck.IsNullString(Sql.GetString($"SELECT dbo.GetPalletId('{Cache.ReturnValueByKey("@Barcode")}')"));
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
            Sql.ExecuteCmd("SetRcvDocFinished", new object[] { "@RcvDocId", Cache.ReturnValueByKey("@RcvDocId") });
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

        public static void DeductSpotVolume(decimal Volume, string ZoneCode)
        {
            Sql.ExecuteCmd("DeductSpotVolume", new object[]
            {
                "@Volume", Volume,
                "@ZoneCode", ZoneCode,
                "@Whid", GlobalUser.CurrentWarehouseId
            });
        }

        public static decimal CalculateTotalVolume(DataTable dt)
        {
            if (dt != null)
            {
                decimal Total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    Total += NullCheck.IsNullDecimal(row["Volume"]) * NullCheck.IsNullDecimal(row["Quantity"]);
                }
                return Total;
            }
            return decimal.Zero;
        }
    }
}
