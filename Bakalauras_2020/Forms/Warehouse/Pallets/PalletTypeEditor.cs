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
    public partial class PalletTypeEditor : Form
    {
        public int WarehouseId = -1;
        public static readonly string SelectProcedure = "SelectPalletById";
        public static readonly string SaveProcedure = "SavePallet";
        public static readonly string UpdateProcedure = "UpdatePallet";    

        public PalletTypeEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tNumber.Enabled = false;
            tVolume.Enabled = false;
        }


        private void Save()
        {
            if (WarehouseId == -1)
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@PalletHeight", tHeight.Text,
                    "@PalletLength", tLength.Text,
                    "@PalletWidth", tWidth.Text,
                    "@PalletVolume", NullCheck.IsNullDecimal(tHeight.Text) * NullCheck.IsNullDecimal(tLength.Text) * NullCheck.IsNullDecimal(tWidth.Text)
                });
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@PalletId", WarehouseId,
                    "@PalletHeight", tHeight.Text,
                    "@PalletLength", tLength.Text,
                    "@PalletWidth", tWidth.Text,
                    "@PalletVolume", NullCheck.IsNullDecimal(tHeight.Text) * NullCheck.IsNullDecimal(tLength.Text) * NullCheck.IsNullDecimal(tWidth.Text)
                });
            LogAction(WarehouseId == -1 ? SaveProcedure : UpdateProcedure);
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
            if (string.IsNullOrEmpty(tHeight.Text))
            {
                tHeight.Invalidate();
                errorMsg += "Negalimas paletės aukštis\n";
            }

            if (string.IsNullOrEmpty(tLength.Text))
            {
                tHeight.Invalidate();
                errorMsg += "Negalimas paletės ilgis\n";
            }

            if (string.IsNullOrEmpty(tWidth.Text))
            {
                tHeight.Invalidate();
                errorMsg += "Negalimas paletės plotis\n";
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti sandėlio:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@PalletId", WarehouseId });
            if (dt.Rows.Count > 0)
            {
                tNumber.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseId"]);
                tHeight.Text = NullCheck.IsNullString(dt.Rows[0]["PalletHeight"]);
                tWidth.Text = NullCheck.IsNullDate(dt.Rows[0]["PalletWidth"]).ToShortDateString();
                tLength.Text = NullCheck.IsNullDate(dt.Rows[0]["PalletLength"]).ToShortDateString();
                tVolume.Text = NullCheck.IsNullDate(dt.Rows[0]["PalletVolume"]).ToShortDateString();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (WarehouseId != -1)
            {
                LoadData();
            }
        }

        private void LogAction(string Command)
        {
            Sql.LogAction(new object[] {
                "Procedure", Command,
                "@Obj1", WarehouseId, "@Obj1Name", "PalletId",
                "@Obj2", tNumber.Text, "@Obj2Name", nameof(tNumber).Substring(1),
                "@Obj3", tHeight.Text, "@Obj3Name", nameof(tHeight).Substring(1),
                "@Obj4", tWidth.Text, "@Obj4Name", nameof(tWidth).Substring(1),
                "@Obj5", tLength.Text, "@Obj5Name", nameof(tLength).Substring(1),
                "@Obj6", tVolume.Text, "@Obj6Name", nameof(tVolume).Substring(1),
                "@Obj7", DateTime.Now.ToShortDateString(), "@Obj7Name", nameof(DateTime),
                "@Obj8", DateTime.Now.ToShortDateString(), "@Obj8Name", nameof(DateTime)
            });
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

        private void tNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }

        private void tVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            tGeneral_KeyPress(sender, e);
        }
    }
}
