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
        private decimal RemainingVolume = -1;
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
            tSpotVolume.ReadOnly = true;
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
                    "@SpotWidth", tSpotWidth.Text,
                    "@SpotLength", tSpotLength.Text,
                    "@SpotVolume", tSpotVolume.Text
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
                    "@SpotWidth", tSpotWidth.Text,
                    "@SpotLength", tSpotLength.Text,
                    "@SpotVolume", tSpotVolume.Text
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
                errorMsg += "Negalimas zonos kodas\n";
            }

            if (string.IsNullOrEmpty(tFZoneName.Text))
            {
                errorMsg += "Negalimas zonos pavadinimas\n";
            }

            if (string.IsNullOrEmpty(tSpotWidth.Text))
            {
                errorMsg += "Negalimas zonos plotis\n";
            }

            if (string.IsNullOrEmpty(tSpotVolume.Text))
            {
                errorMsg += "Negalimas zonos tūris\n";
            }

            if (string.IsNullOrEmpty(tSpotHeight.Text))
            {
                errorMsg += "Negalimas zonos aukštis\n";
            }

            if (string.IsNullOrEmpty(tSpotLength.Text))
            {
                errorMsg += "Negalimas zonos ilgis\n";
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
                tSpotHeight.Text = NullCheck.IsNullString(dt.Rows[0]["SpotHeight"]);
                tSpotLength.Text = NullCheck.IsNullString(dt.Rows[0]["SpotLength"]);
                tSpotWidth.Text = NullCheck.IsNullString(dt.Rows[0]["SpotWidth"]);
                tSpotVolume.Text = NullCheck.IsNullString(dt.Rows[0]["SpotVolume"]);
            }


            RemainingVolume = NullCheck.IsNullDecimal(Sql.GetString($"SELECT dbo.RemainingZoneVolume('{WarehouseZoneId}')"));
            if (NullCheck.IsNullDecimal(dt.Rows[0]["SpotVolume"]) != RemainingVolume)
            {
                tSpotHeight.Enabled = false;
                tSpotLength.Enabled = false;
                tSpotVolume.Enabled = false;
                tSpotWidth.Enabled = false;
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

        private void tGeneral_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RecalculateSpotVolume()
        {
            if (string.IsNullOrEmpty(tSpotLength.Text) || string.IsNullOrEmpty(tSpotWidth.Text) || string.IsNullOrEmpty(tSpotHeight.Text))
            {
                return;
            }

            tSpotVolume.Text = NullCheck.IsNullString(NullCheck.IsNullDecimal(tSpotLength.Text) * NullCheck.IsNullDecimal(tSpotWidth.Text) * NullCheck.IsNullDecimal(tSpotHeight.Text));
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

        private void tSpotHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tSpotWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tSpotLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tSpotVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tSpotWidth_TextChanged(object sender, EventArgs e)
        {
            RecalculateSpotVolume();
        }

        private void tSpotLength_TextChanged(object sender, EventArgs e)
        {
            RecalculateSpotVolume();
        }

        private void tSpotHeight_TextChanged(object sender, EventArgs e)
        {
            RecalculateSpotVolume();
        }
    }
}
