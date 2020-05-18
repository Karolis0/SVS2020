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
    public partial class ShipmentEditor : Form
    {
        public int ShipmentId = -1;
        private int SelectedPartnerId = -1;
        public static readonly string SelectProcedure = "GetShipmentById";
        public static readonly string SaveProcedure = "SaveShipment";
        public static readonly string UpdateProcedure = "UpdateShipment";    

        public ShipmentEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tCreateDate.Enabled = false;
            tUpdated.Enabled = false;
            tWarehouse.Enabled = false;
            tShipmentId.Enabled = false;
            tPartner.ReadOnly = true;
            dView.MultiSelect = false;
            dView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dView.DoubleClick += DView_DoubleClick;
            dView.AllowUserToAddRows = false;
        }

        private void DView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dView.DataSource != null && ((DataTable)dView.DataSource).Rows.Count > 0 && ShipmentId > 0)
                {
                    DataGridViewRow row = dView.SelectedRows[0];
                    if (row != null)
                    {
                        bool Deselect = NullCheck.IsNullInt(row.Cells["ShipmentId"].Value) > 0 ? true : false;
                        Sql.ExecuteCmd("ChangeShipmentAssign", new object[]
                        {
                        "@RcvOrdId", NullCheck.IsNullInt(row.Cells["RcvOrderId"].Value),
                        "@ShipmentId", Deselect ? 0 : ShipmentId
                        });

                        row.Cells["ShipmentId"].Value = Deselect ? 0 : ShipmentId;

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
            catch
            {

            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            DialogResult = DialogResult.OK;
        }

        private void Save()
        {
            if (ShipmentId == -1)
            {
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@ShipmentId", tShipmentId.Text,
                    "@ShipmentNo", tShipmentNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@CreateDate", DateTime.Now.ToShortDateString(),
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
                ShipmentId = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateSaveShipment('{tShipmentNo.Text}')"));
                tShipmentId.Text = NullCheck.IsNullString(ShipmentId);
                if (ShipmentId > 0)
                LoadData();
            }
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@ShipmentId", ShipmentId,
                    "@ShipmentNo", tShipmentNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
            LogAction(ShipmentId == -1 ? SaveProcedure : UpdateProcedure);
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@ShipmentId", ShipmentId });
            if (dt != null && dt.Rows.Count > 0)
            {
                tShipmentId.Text = NullCheck.IsNullString(ShipmentId);
                SelectedPartnerId = NullCheck.IsNullInt(dt.Rows[0]["PartnerId"]);
                tPartner.Text = NullCheck.IsNullString(dt.Rows[0]["PartnerName"]);
                tWarehouse.Text = NullCheck.IsNullString(dt.Rows[0]["WarehouseName"]);
                tShipmentNo.Text = NullCheck.IsNullString(dt.Rows[0]["ShipmentNo"]);
                tCreateDate.Text = NullCheck.IsNullDate(dt.Rows[0]["CreateDate"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["UpdateDate"]).ToShortDateString();
                LoadDView();
            }
        }

        private void LoadDView()
        {
            DataTable dt = Sql.GetTable("GetRcvOrdersForShipmentEditor", new object[]
            {
                "@ShipmentId", ShipmentId
            });

            dView.DataSource = dt;
            if (dt != null)
            {
                EditColumns();
                foreach (DataGridViewRow row in dView.Rows)
                {
                    if (NullCheck.IsNullInt(row.Cells["ShipmentId"].Value) == ShipmentId)
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
            dView.Columns["Created"].HeaderText = "Sukurta";
            dView.Columns["Updated"].HeaderText = "Atnaujinta";

            dView.Columns["RcvOrderId"].Visible = false;
            dView.Columns["ShipmentId"].Visible = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tWarehouse.Text = Sql.GetString($"SELECT dbo.GetWarehouseName({GlobalUser.CurrentWarehouseId})");
            if (ShipmentId != -1)
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
                "@Obj1", ShipmentId, "@Obj1Name", nameof(ShipmentId),
                "@Obj2", tShipmentId.Text, "@Obj2Name", nameof(tShipmentId).Substring(1),
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
            SelectedPartnerId = PartnerMapper.SelectPartnerId(Supplier: true);
            tPartner.Text = Sql.GetString($"SELECT dbo.GetPartnerName('{SelectedPartnerId}')");
        }

        public void AssignTextBoxes(string[] values)
        {
            tShipmentId.Text = values[0];
            tShipmentNo.Text = values[1];
            tPartner.Text = values[2];
            SelectedPartnerId = 1;
            GlobalUser.CurrentWarehouseId = 3;
        }

        public void PerformSave()
        {
            bSave_Click(null, null);
        }
    }
}
