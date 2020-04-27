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

namespace Bakalauras_2020.Forms.Receiving
{
    public partial class ParcelsEditor : Form
    {
        public int ParcelId = -1;
        private int SelectedPartnerId = -1;
        public static readonly string SelectProcedure = "GetParcelById";
        public static readonly string SaveProcedure = "SaveParcel";
        public static readonly string UpdateProcedure = "UpdateParcel";    

        public ParcelsEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tCreateDate.Enabled = false;
            tUpdated.Enabled = false;
            tWarehouse.Enabled = false;
            tParcelId.Enabled = false;
            tPartner.ReadOnly = true;
            dView.MultiSelect = false;
            dView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dView.DoubleClick += DView_DoubleClick;
            dView.AllowUserToAddRows = false;
        }

        private void DView_DoubleClick(object sender, EventArgs e)
        {
            if (dView.DataSource != null && ((DataTable)dView.DataSource).Rows.Count > 0 && ParcelId > 0)
            {
                DataGridViewRow row = dView.SelectedRows[0];
                if (row != null)
                {
                    bool Deselect = NullCheck.IsNullInt(row.Cells["ParcelId"]) > 0 ? true : false;
                    Sql.ExecuteCmd("ChangeParcelAssign", new object[]
                    {
                        "@OutOrderId", NullCheck.IsNullInt(row.Cells["OutOrderId"].Value),
                        "@ParcelId", Deselect ? (int?)null : (int?)ParcelId
                    });

                    if (!Deselect)
                    {
                        row.DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }

                    dView.SelectedRows[0].Selected = false;

                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            DialogResult = DialogResult.OK;
        }

        private void Save()
        {
            if (ParcelId == -1)
            {
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@ParcelId", tParcelId.Text,
                    "@ParcelNo", tParcelNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@CreateDate", DateTime.Now.ToShortDateString(),
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
                ParcelId = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateSaveParcel('{tParcelNo.Text}')"));
                tParcelId.Text = NullCheck.IsNullString(ParcelId);
                if (ParcelId > 0)
                LoadData();
            }
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@ParcelId", tParcelId.Text,
                    "@ParcelNo", tParcelNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
            LogAction(ParcelId == -1 ? SaveProcedure : UpdateProcedure);
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
            if (string.IsNullOrEmpty(tPartner.Text))
            {
                errorMsg += "Negalima partnerio reikšmė";
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti siuntos:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@ParcelId", ParcelId });
            if (dt != null && dt.Rows.Count > 0)
            {
                tParcelId.Text = NullCheck.IsNullString(ParcelId);
                SelectedPartnerId = NullCheck.IsNullInt(dt.Rows[0]["CustomerId"]);
                tPartner.Text = NullCheck.IsNullString(dt.Rows[0]["PartnerName"]);
                tWarehouse.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseName"]);
                tParcelNo.Text = NullCheck.IsNullString(dt.Rows[0]["ParcelNo"]);
                tCreateDate.Text = NullCheck.IsNullDate(dt.Rows[0]["CreateDate"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["UpdateDate"]).ToShortDateString();
                LoadDView();
            }
        }

        private void LoadDView()
        {
            DataTable dt = Sql.GetTable("GetOutOrdersForParcelEditor", new object[]
            {
                "@ParcelId", ParcelId
            });

            dView.DataSource = dt;
            if (dt != null)
            {
                EditColumns();
                foreach (DataGridViewRow row in dView.Rows)
                {
                    if (NullCheck.IsNullInt(row.Cells["ParcelId"]) == ParcelId)
                    {
                        row.DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void EditColumns()
        {
            dView.Columns["DocumentNo"].HeaderText = "Dokumento numeris";
            dView.Columns["WarehouseName"].HeaderText = "Sandėlis";
            dView.Columns["Created"].HeaderText = "Sukūrimo data";
            dView.Columns["Updated"].HeaderText = "Atnaujinta";

            dView.Columns["OutOrderId"].Visible = false;
            dView.Columns["ParcelId"].Visible = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tWarehouse.Text = Sql.GetString($"SELECT dbo.GetWarehouseName({GlobalUser.CurrentWarehouseId})");
            if (ParcelId != -1)
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
                "@Obj1", ParcelId, "@Obj1Name", nameof(ParcelId),
                "@Obj2", tParcelId.Text, "@Obj2Name", nameof(tParcelId).Substring(1),
                "@Obj3", tWarehouse.Text, "@Obj3Name", nameof(tWarehouse).Substring(1),
                "@Obj4", DateTime.Now.ToShortDateString(), "@Obj4Name", nameof(DateTime),
                "@Obj5", DateTime.Now.ToShortDateString(), "@Obj5Name", nameof(DateTime)
            });
        }

        private void ShipmentEditor_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void tPartner_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedPartnerId = PartnerMapper.SelectPartnerId(Customer: true);
            tPartner.Text = Sql.GetString($"SELECT dbo.GetPartnerName('{SelectedPartnerId}')");
        }
    }
}
