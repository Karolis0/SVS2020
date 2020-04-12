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
    public partial class WarehouseEditor : Form
    {
        public int WarehouseId = -1;
        public static readonly string SelectProcedure = "GetWarehouseById";
        public static readonly string SaveProcedure = "SaveWarehouse";
        public static readonly string UpdateProcedure = "UpdateWarehouse";    

        public WarehouseEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            SetupComboboxes();
            tCreateDate.Enabled = false;
            tUpdated.Enabled = false;
            cWarehouseLocId.DropDownHeight = 1;
            cWarehouseLocId.DropDown += CWarehouseLocId_DropDown;
        }

        private void CWarehouseLocId_DropDown(object sender, EventArgs e)
        {
            int LocId = WarehouseLocMapper.SelectLocId();
            if (!((DataTable)cWarehouseLocId.DataSource).AsEnumerable().Any(row => LocId == row.Field<int>("LocationId")))
            {
                LoadWarehouseCombo();
            }
            cWarehouseLocId.SelectedValue = LocId;
            cWarehouseLocId.DroppedDown = false;
            cWarehouseLocId.Focus();
        }

        private void SetupComboboxes()
        {
            LoadWarehouseCombo();
        }

        private void LoadWarehouseCombo()
        {
            DataTable dTable = Sql.GetTable("SelectLocationsComboBox");
            cWarehouseLocId.DataSource = dTable;
            cWarehouseLocId.DisplayMember = "LocationCode";
            cWarehouseLocId.ValueMember = "LocationId";
            cWarehouseLocId.SelectedIndex = 0;
        }

        private void Save()
        {
            if (WarehouseId == -1)
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@WarehouseCode", tCode.Text,
                    "@WarehouseName", tName.Text,
                    "@LocationId", cWarehouseLocId.SelectedValue,
                    "@CreateDate", DateTime.Now.ToShortDateString(),
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@WarehouseCode", tCode.Text,
                    "@WarehouseName", tName.Text,
                    "@LocationId", cWarehouseLocId.SelectedValue,
                    "@WarehouseId", WarehouseId,
                    "@UpdateDate", DateTime.Now.ToShortDateString()
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
            if (string.IsNullOrEmpty(tCode.Text))
            {
                tCode.Invalidate();
                errorMsg += "Negalimas sandėlio kodas\n";
            }
            if (string.IsNullOrEmpty(tName.Text))
            {
                tName.Invalidate();
                errorMsg += "Negalimas sandėlio pavadinimas\n";
            }

            int Exists = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateWarehouse('{tCode.Text}', '{tName.Text}')"));

            if (Exists > 0 && WarehouseId < 0)
            {
                errorMsg += "Sandėlio kodo ir pavadinimo kombinacija nėra unikali\n";
            }

            if (Exists > 0 && WarehouseId > 0)
            {
                if (NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.CheckIfWarehouseIsUnique('{WarehouseId}','{tName.Text}','{tCode.Text}')")) == 0)
                {
                    errorMsg += "Sandėlio kodo ir pavadinimo kombinacija nėra unikali\n";
                }
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@WarehouseId", WarehouseId });
            if (dt.Rows.Count > 0)
            {
                tCode.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseCode"]);
                tName.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseName"]);
                cWarehouseLocId.SelectedValue = NullCheck.IsNullString(dt.Rows[0]["LocationId"]);
                tCreateDate.Text = NullCheck.IsNullDate(dt.Rows[0]["CreateDate"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["UpdateDate"]).ToShortDateString();            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (WarehouseId != -1)
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
                "@Obj1", WarehouseId, "@Obj1Name", nameof(WarehouseId),
                "@Obj2", tCode.Text, "@Obj2Name", nameof(tCode).Substring(1),
                "@Obj3", tName.Text, "@Obj3Name", nameof(tName).Substring(1),
                "@Obj4", cWarehouseLocId.SelectedValue, "@Obj4Name", nameof(cWarehouseLocId).Substring(1),
                "@Obj5", DateTime.Now.ToShortDateString(), "@Obj5Name", nameof(DateTime),
                "@Obj6", DateTime.Now.ToShortDateString(), "@Obj6Name", nameof(DateTime)
            });
        }
    }
}
