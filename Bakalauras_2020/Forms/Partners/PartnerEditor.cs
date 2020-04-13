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
    public partial class PartnerEditor : Form
    {
        public int PartnerId = -1;
        public static readonly string SelectProcedure = "SelectPartners";
        public static readonly string SaveProcedure = "SavePartner";
        public static readonly string UpdateProcedure = "UpdatePartner";    

        public PartnerEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tCreated.Enabled = false;
            tUpdated.Enabled = false;
        }

        private void Save()
        {
            Sql.ExecuteCmd(PartnerId == -1 ? SaveProcedure : UpdateProcedure, new object[] {
                "@PartnerCode", tPartnerCode.Text,
                "@PartnerName", tPartnerName.Text,
                "@Supplier", cbSupply.Checked,
                "@Customer", cbCustomer.Checked,
                "@PartnerId", PartnerId,
                "@Created", DateTime.Now.ToShortDateString(),
                "@Updated", DateTime.Now.ToShortDateString()
            });
            LogAction(PartnerId == -1 ? SaveProcedure : UpdateProcedure);
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
            if (string.IsNullOrEmpty(tPartnerCode.Text))
            {
                tPartnerName.Invalidate();
                errorMsg += "Negalimas partnerio kodas\n";
            }

            if (string.IsNullOrEmpty(tPartnerName.Text))
            {
                tPartnerName.Invalidate();
                errorMsg += "Negalimas partnerio pavadinimas\n";
            }

            if (!cbCustomer.Checked && !cbSupply.Checked)
            {
                errorMsg += "Pasirinkite partnerio tipą\n";
            }

            int Exists = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidatePartner('{tPartnerName.Text}', '{tPartnerCode.Text}')"));

            if (Exists > 0 && PartnerId < 0)
            {
                errorMsg += "Partnerio kodo ir pavadinimo kombinacija nėra unikali\n";
            }

            if (Exists > 0 && PartnerId > 0)
            {
                if (NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.CheckIfPartnerIsUnique('{PartnerId}','{tPartnerName.Text}','{tPartnerCode.Text}')")) == 0)
                {
                    errorMsg += "Partnerio kodo ir pavadinimo kombinacija nėra unikali\n";
                }
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti partnerio:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@PartnerId", PartnerId });
            if (dt.Rows.Count > 0)
            {
                tPartnerCode.Text = NullCheck.IsNullString(dt.Rows[0]["PartnerCode"]);
                tPartnerName.Text = NullCheck.IsNullString(dt.Rows[0]["Partnername"]);
                cbCustomer.Checked = NullCheck.IsNullBoolean(dt.Rows[0]["IsCustomer"]);
                cbSupply.Checked = NullCheck.IsNullBoolean(dt.Rows[0]["IsSupplier"]);
                tCreated.Text = NullCheck.IsNullDate(dt.Rows[0]["Created"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["Updated"]).ToShortDateString();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (PartnerId != -1)
            {
                LoadData();
            }
        }

        private void LogAction(string Command)
        {
            Sql.LogAction(new object[] {
                "Procedure", Command,
                "@Obj1", PartnerId, "@Obj1Name", nameof(PartnerId),
                "@Obj2", tPartnerCode.Text, "@Obj2Name", nameof(tPartnerCode).Substring(1),
                "@Obj3", tPartnerName.Text, "@Obj3Name", nameof(tPartnerName).Substring(1),
                "@Obj4", cbSupply.Text, "@Obj4Name", nameof(cbSupply).Substring(2),
                "@Obj5", cbCustomer.Text, "@Obj5Name", nameof(cbCustomer).Substring(2),
                "@Obj6", DateTime.Now.ToShortDateString(), "@Obj6Name", nameof(DateTime),
                "@Obj7", DateTime.Now.ToShortDateString(), "@Obj7Name", nameof(DateTime)
            });
        }

        private void cbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCustomer.Checked)
            {
                cbSupply.Checked = false;
            }
        }

        private void cbSupply_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSupply.Checked)
            {
                cbCustomer.Checked = false;
            }
        }
    }
}
