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
    public partial class ItemEditor : Form
    {
        public int ItemId = -1;
        public static readonly string SelectProcedure = "GetItemByWarehouseAndId";
        public static readonly string SaveProcedure = "SaveItem";
        public static readonly string UpdateProcedure = "UpdateItem";    

        public ItemEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            SetupComboboxes();
            tWarehouseId.Text = GlobalUser.CurrentWarehouseId.ToString();
            tCreateDate.Enabled = false;
            tWarehouseId.Enabled = false;
            tUpdated.Enabled = false;
        }

        private void SetupComboboxes()
        {
            LoadMUCombo();
            LoadItemTypeCombo();
        }

        private void LoadItemTypeCombo()
        {
            DataTable dTable = Sql.GetTable("SelectItemTypesComboBox");
            cItemType.DataSource = dTable;
            cItemType.DisplayMember = "ItemTypeName";
            cItemType.ValueMember = "ItemTypeId";
            cItemType.SelectedIndex = 0;
        }

        private void LoadMUCombo()
        {
            DataTable dTable = Sql.GetTable("SelectMUComboBox");
            cMU.DataSource = dTable;
            cMU.DisplayMember = "UnitName";
            cMU.ValueMember = "UnitId";
            cMU.SelectedIndex = 0;
        }

        private void Save()
        {
            Sql.ExecuteCmd(ItemId == -1 ? SaveProcedure : UpdateProcedure, new object[] {
                "@ItemId", ItemId,
                "@Code", tItemCode.Text,
                "@Name", tItemName.Text,
                "@Description", tItemDescription.Text,
                "@TypeId", cItemType.SelectedValue,
                "@NetWeight", tNetWeight.Text.Trim().Replace(',','.'),
                "@BrutoWeight", tBrutoWeight.Text.Trim().Replace(',','.'),
                "@Volume", tVolume.Text.Trim().Replace(',','.'),
                "@MUId", cMU.SelectedValue,
                "@CreateDate", DateTime.Now.ToShortDateString(),
                "@UpdateDate", DateTime.Now.ToShortDateString(),
                "@WhId", GlobalUser.CurrentWarehouseId,
                "@Barcode", tBarcode.Text,
                "@Width", tWidth.Text.Replace(',','.'),
                "@Height", tHeight.Text.Replace(',','.')
            });
            LogAction(ItemId == -1 ? SaveProcedure : UpdateProcedure);
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
            if (string.IsNullOrEmpty(tItemCode.Text))
            {
                tItemCode.Invalidate();
                errorMsg += "Negalimas prekės kodas\n";
            }
            if (string.IsNullOrEmpty(tItemName.Text))
            {
                tItemName.Invalidate();
                errorMsg += "Negalimas prekės pavadinimas\n";
            }
            if (string.IsNullOrEmpty(tNetWeight.Text))
            {
                tNetWeight.Invalidate();
                errorMsg += "Negalimas prekės neto svoris\n";
            }
            if (string.IsNullOrEmpty(tBrutoWeight.Text))
            {
                tBrutoWeight.Invalidate();
                errorMsg += "Negalimas prekės bruto svoris\n";
            }
            if (string.IsNullOrEmpty(tVolume.Text))
            {
                tItemCode.Invalidate();
                errorMsg += "Negalimas prekės tūris\n";
            }

            if (string.IsNullOrEmpty(tBarcode.Text))
            {
                tBarcode.Invalidate();
                errorMsg += "Negalimas prekės barkodas\n";
            }

            if (string.IsNullOrEmpty(tHeight.Text))
            {
                tHeight.Invalidate();
                errorMsg += "Negalimas prekės aukštis\n";
            }

            if (string.IsNullOrEmpty(tWidth.Text))
            {
                tWidth.Invalidate();
                errorMsg += "Negalimas prekės plotas\n";
            }

            if (NullCheck.IsNullDecimal(tWidth.Text) <= 0)
            {
                tWidth.Invalidate();
                errorMsg += "Prekės plotis negali būti lygus ar mažesnis už 0\n";
            }
            if (NullCheck.IsNullDecimal(tHeight.Text) <= 0)
            {
                tHeight.Invalidate();
                errorMsg += "Prekės aukštis negali būti lygus ar mažesnis už 0\n";
            }

            if (!string.IsNullOrEmpty(tNetWeight.Text) && !string.IsNullOrEmpty(tBrutoWeight.Text) && NullCheck.IsNullDecimal(tNetWeight.Text) > NullCheck.IsNullDecimal(tBrutoWeight.Text))
            {
                errorMsg += "Neto svoris negali būti didesnis už bruto svorį\n";
            }

            if (NullCheck.IsNullDecimal(tNetWeight.Text) <= 0)
            {
                errorMsg += "Neto svoris negali būti lygus 0 arba mažesnei reikšmei\n";
            }

            if (NullCheck.IsNullDecimal(tBrutoWeight.Text) <= 0)
            {
                errorMsg += "Bruto svoris negali būti lygus 0 arba mažesnei reikšmei\n";
            }

            int Exists = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateItem('{tItemCode.Text}', '{tItemName.Text}')"));

            if (Exists > 0 && ItemId < 0)
            {
                errorMsg += "Prekės kodo ir pavadinimo kombinacija nėra unikali\n";
            }

            if (Exists > 0 && ItemId > 0)
            {
                if (NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.CheckIfItemIsUnique('{ItemId}','{tItemName.Text}','{tItemCode.Text}')")) == 0)
                {
                    errorMsg += "Prekės kodo ir pavadinimo kombinacija nėra unikali\n";
                }
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti prekės kortelės:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tNetWeight_KeyPress(object sender, KeyPressEventArgs e)
           {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tBrutoWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        public void LoadData()
        {
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@ItemId", ItemId});
            if (dt.Rows.Count > 0)
            {
                tItemCode.Text = NullCheck.IsNullString(dt.Rows[0]["Code"]);
                tItemName.Text = NullCheck.IsNullString(dt.Rows[0]["Name"]);
                tItemDescription.Text = NullCheck.IsNullString(dt.Rows[0]["Description"]);
                cItemType.SelectedValue = NullCheck.IsNullString(dt.Rows[0]["TypeId"]);
                tNetWeight.Text = NullCheck.IsNullString(dt.Rows[0]["NetWeight"]);
                tBrutoWeight.Text = NullCheck.IsNullString(dt.Rows[0]["BrutoWeight"]);
                tVolume.Text = NullCheck.IsNullString(dt.Rows[0]["Volume"]);
                cMU.SelectedValue = NullCheck.IsNullString(dt.Rows[0]["MeasureUnitId"]);
                tCreateDate.Text = NullCheck.IsNullDate(dt.Rows[0]["CreateDate"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["UpdateDate"]).ToShortDateString();
                tWarehouseId.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseCode"]);
                tBarcode.Text = NullCheck.IsNullString(dt.Rows[0]["Barcode"]);
                tWidth.Text = NullCheck.IsNullString(dt.Rows[0]["Width"]);
                tHeight.Text = NullCheck.IsNullString(dt.Rows[0]["Height"]);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (ItemId != -1)
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
                "@Obj1", ItemId, "@Obj1Name", nameof(ItemId),
                "@Obj2", tItemCode.Text, "@Obj2Name", nameof(tItemCode).Substring(1),
                "@Obj3", tItemName.Text, "@Obj3Name", nameof(tItemName).Substring(1),
                "@Obj4", tItemDescription.Text, "@Obj4Name", nameof(tItemDescription).Substring(1),
                "@Obj5", cItemType.SelectedValue, "@Obj5Name", nameof(cItemType).Substring(1),
                "@Obj6", tNetWeight.Text.Trim(), "@Obj6Name", nameof(tNetWeight).Substring(1),
                "@Obj7", tBrutoWeight.Text.Trim(), "@Obj7Name", nameof(tBrutoWeight).Substring(1),
                "@Obj8", tVolume.Text.Trim(), "@Obj8Name", nameof(tVolume).Substring(1),
                "@Obj9", tBarcode.Text.Trim(), "@Obj9Name", nameof(tBarcode).Substring(1),
                "@Obj10", tWidth.Text.Trim(), "@Obj10Name", nameof(tWidth).Substring(1),
                "@Obj11", tHeight.Text.Trim(), "@Obj11Name", nameof(tHeight).Substring(1),
                "@Obj12", cMU.SelectedValue, "@Obj12Name", "Measure unit id",
                "@Obj13", DateTime.Now.ToShortDateString(), "@Obj13Name", nameof(DateTime),
                "@Obj14", DateTime.Now.ToShortDateString(), "@Obj14Name", nameof(DateTime),
                "@Obj15", GlobalUser.CurrentWarehouseId, "@Obj15Name", "CurrentWarehouseId"
            });
        }

        public void AssignTextBoxes(string[] values)
        {
            ItemId = int.Parse(values[0]);
            tItemCode.Text = values[1];
            tItemName.Text = values[2];
            tItemDescription.Text = values[3];
            cItemType.SelectedValue = 3;
            tNetWeight.Text = values[5];
            tBrutoWeight.Text = values[6];
            tVolume.Text = values[7];
            cMU.SelectedValue = 1;
            tBarcode.Text = values[9];
            tWidth.Text = values[10];
            tHeight.Text = values[11];
            GlobalUser.CurrentWarehouseId = 3;
        }

        public void PerformSave()
        {
            bSave_Click(null, null);
        }
    }
}
