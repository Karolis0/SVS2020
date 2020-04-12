using Bakalauras_2020.Forms.Mappers;
using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakalauras_2020.Forms.Warehouse.Items
{
    public partial class WarehouseZoneEditor : Form
    {
        public int WarehouseZoneId = -1;
        public int FZoneParentId = -1;
        public static readonly string SelectProcedure = "GetWarehouseZoneById";
        public static readonly string SaveProcedure = "SaveWarehouseZone";
        public static readonly string UpdateProcedure = "UpdateWarehouseZone";    

        public WarehouseZoneEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tCreated.Enabled = false;
            tUpdated.Enabled = false;
            tWarehouse.Enabled = false;
            tParent.Enabled = false;
            tSpotWidth.Enabled = false;
            tSpotHeight.Enabled = false;
        }

        private void Save()
        {
            if (WarehouseZoneId == -1)
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@FZoneCode", tFZoneCode.Text,
                    "@FZoneName", tFZoneName.Text,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@ParentId", FZoneParentId,
                    "@Created", DateTime.Now.ToShortDateString(),
                    "@Updated", DateTime.Now.ToShortDateString(),
                    "@SpotHeight", tSpotHeight.Text,
                    "@SpotWidth", tSpotWidth.Text
                });
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@FZoneCode", tFZoneCode.Text,
                    "@FZoneName", tFZoneName.Text,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@ParentId", FZoneParentId,
                    "@FZoneId", WarehouseZoneId,
                    "@Updated", DateTime.Now.ToShortDateString(),
                    "@SpotHeight", tSpotHeight.Text,
                    "@SpotWidth", tSpotWidth.Text
                });
            LogAction(WarehouseZoneId == -1 ? SaveProcedure : UpdateProcedure);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;
            Save();
        }

        private bool ValidInput()
        {
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(tFZoneCode.Text))
            {
                tFZoneName.Invalidate();
                errorMsg += "Negalimas vietovės kodas\n";
            }

            if (string.IsNullOrEmpty(tFZoneName.Text))
            {
                tFZoneName.Invalidate();
                errorMsg += "Negalimas zonos pavadinimas\n";
            }

            int Exists = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateFZone('{tFZoneName.Text}', '{tFZoneCode.Text}')"));

            if (Exists > 0 && WarehouseZoneId < 0)
            {
                errorMsg += "Zonos kodo ir pavadinimo kombinacija nėra unikali\n";
            }

            if (Exists > 0 && WarehouseZoneId > 0)
            {
                if (NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.CheckIfFZoneIsUnique('{WarehouseZoneId}','{tFZoneName.Text}','{tFZoneCode.Text}')")) == 0)
                {
                    errorMsg += "Zonos kodo ir pavadinimo kombinacija nėra unikali\n";
                }
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti zonos:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadData()
        {
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@WarehouseZoneId", WarehouseZoneId });
            if (dt.Rows.Count > 0)
            {
                tFZoneCode.Text = NullCheck.IsNullString(dt.Rows[0]["ZoneCode"]);
                tFZoneName.Text = NullCheck.IsNullString(dt.Rows[0]["ZoneName"]);
                tWarehouse.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseName"]);
                tCreated.Text = NullCheck.IsNullDate(dt.Rows[0]["CreateDate"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["UpdateDate"]).ToShortDateString();
                FZoneParentId = NullCheck.IsNullInt(dt.Rows[0]["ParentID"]);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tWarehouse.Text = Sql.GetString($"SELECT dbo.GetWarehouseName({GlobalUser.CurrentWarehouseId})");
            tParent.Text = Sql.GetString($"SELECT dbo.GetNodeNameById({FZoneParentId})");
            if (WarehouseZoneId != -1)
            {
                LoadData();
            }
        }

        private void tVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void LogAction(string Command)
        {
            Sql.LogAction(new object[] {
                "Procedure", Command,
                "@Obj1", WarehouseZoneId, "@Obj1Name", nameof(WarehouseZoneId),
                "@Obj2", tFZoneCode.Text, "@Obj2Name", nameof(tFZoneCode).Substring(1),
                "@Obj3", tWarehouse.Text, "@Obj3Name", nameof(tWarehouse).Substring(1),
                "@Obj4", tParent.Text, "@Obj4Name", nameof(tParent).Substring(1),
                "@Obj5", tSpotHeight.Text, "@Obj5Name", nameof(tSpotHeight).Substring(1),
                "@Obj6", tSpotWidth.Text, "@Obj6Name", nameof(tSpotWidth).Substring(1),
                "@Obj7", tFZoneName.Text, "@Obj7Name", nameof(tFZoneName).Substring(1),
                "@Obj8", DateTime.Now.ToShortDateString(), "@Obj6Name", nameof(DateTime),
                "@Obj9", DateTime.Now.ToShortDateString(), "@Obj7Name", nameof(DateTime)
            });
        }
    }
}
