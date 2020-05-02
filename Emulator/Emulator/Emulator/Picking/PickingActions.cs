using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using Emulator.Static_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator.Emulator.Picking
{
    public class PickingActions
    {
        public static DataTable GetOutOrderDocuments()
        {
            return Sql.GetTable("GetInProcessOutOrderDocs", new object[] { "@WhId", GlobalUser.CurrentWarehouseId });
        }

        public static DataTable GetPalletTypes()
        {
            return Sql.GetTable("SelectPalletTypes");
        }

        public static DataTable GetWorkOrdersByOutOrder()
        {
            return Sql.GetTable("GetWorkOrdersByOutOrder", new object[] { "@OutOrderId", Cache.ReturnValueByKey("@OutOrderId") });
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

        public static void PutAwayItems(DataTable dt)
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

        public static void DeductSpotVolume(decimal Volume, string ZoneCode)
        {
            Sql.ExecuteCmd("DeductSpotVolume", new object[]
            {
                "@Volume", Volume,
                "@ZoneCode", ZoneCode,
                "@Whid", GlobalUser.CurrentWarehouseId
            });
        }

        public static void PutAwayCU()
        {
            string PalletBarcode = Cache.ReturnValueByKey("@Barcode");
            string ZoneCode = Cache.ReturnValueByKey("@StageLocation");

            Sql.ExecuteCmd("SavePalletToZone", new object[]
            {
                "@ZoneCode", ZoneCode,
                "@Whid", GlobalUser.CurrentWarehouseId,
                "@Barcode", PalletBarcode,
                "@Created", DateTime.Now,
                "@Updated", DateTime.Now,
                "@OutOrderId", Cache.ReturnValueByKey("@OutOrderId")
            });
        }

        public static void FinishOutOrderStatus()
        {
            Sql.GetTable("SetOutOrderFinished", new object[] { "@OutOrderId", Cache.ReturnValueByKey("@OutOrderId") });
        }

        public static void SetWOInProcess(int WOId)
        {
            Sql.GetTable("SetInprocessWO", new object[] { "@WOId", WOId });
        }

        public static void CloseWO(int WOId)
        {
            Sql.GetTable("CloseWO", new object[] { "@WOId", WOId });
        }

        private static DataTable ProcessDataTableQuantityById(DataTable dt)
        {
            DataTable clone = dt.Clone();

            foreach (DataRow row in dt.Rows)
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

        public static int ZoneExists(string ZoneCode)
        {
            return NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateShippingLocation('{GlobalUser.CurrentWarehouseId}','{ZoneCode}')"));
        }
    }
}
