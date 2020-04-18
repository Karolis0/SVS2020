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
    public partial class ReceivingOrderEditor : Form
    {
        public int DocId = -1;
        public static readonly string SelectProcedure = "GetRcvOrdById";
        public static readonly string SaveProcedure = "SaveRcvOrd";
        public static readonly string UpdateProcedure = "UpdateRcvOrd";    

        public ReceivingOrderEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tCreateDate.Enabled = false;
            tUpdated.Enabled = false;
            tWarehouse.Enabled = false;
            dView.MultiSelect = false;
            dView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dView.DoubleClick += DView_DoubleClick;
            dView.AllowUserToAddRows = false;
        }

        private void DView_DoubleClick(object sender, EventArgs e)
        {
            if (dView.DataSource != null && ((DataTable)dView.DataSource).Rows.Count > 0 && DocId > 0)
            {
                DataGridViewRow row = dView.SelectedRows[0];
                if (row != null)
                {
                    bool Deselect = NullCheck.IsNullInt(row.Cells["RcvOrderId"]) > 0 ? true : false;
                    Sql.ExecuteCmd("ChangeRcvOrdAssign", new object[]
                    {
                        "@RcvDocId", NullCheck.IsNullInt(row.Cells["ReceivingDocId"].Value),
                        "@RcvOrdId", Deselect ? (int?)null : (int?)DocId
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
            if (DocId == -1)
            {
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@DocNo", tDocNo.Text,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@CreateDate", DateTime.Now.ToShortDateString(),
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
                DocId = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateSaveRcvOrd('{tDocNo.Text}')"));
                if (DocId > 0)
                LoadData();
            }
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@DocNo", tDocNo.Text,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@UpdateDate", DateTime.Now.ToShortDateString(),
                    "@RcvDocId", DocId
                });
            LogAction(DocId == -1 ? SaveProcedure : UpdateProcedure);
            
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
            if (string.IsNullOrEmpty(tDocNo.Text))
            {
                tDocNo.Text = NullCheck.IsNullString(Sql.GetTable("GenerateDocNoRcvOrd").Rows[0][0]);
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti dokumento:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@RcvOrdId", DocId });
            if (dt != null && dt.Rows.Count > 0)
            {
                tDocNo.Text = NullCheck.IsNullString(dt.Rows[0]["DocumentNo"]);
                tCreateDate.Text = NullCheck.IsNullDate(dt.Rows[0]["Created"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["Updated"]).ToShortDateString();
                LoadDView();
            }
        }

        private void LoadDView()
        {
            DataTable dt = Sql.GetTable("GetRcvDocsForOrderEditor", new object[]
            {
                "@RcvOrdId", DocId
            });

            dView.DataSource = dt;
            EditColumns();
            foreach (DataGridViewRow row in dView.Rows)
            {
                if (NullCheck.IsNullInt(row.Cells["RcvOrderId"]) == DocId)
                {
                    row.DefaultCellStyle.BackColor = Color.Cyan;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void EditColumns()
        {
            dView.Columns["DocCode"].HeaderText = "Dokumento numeris";
            dView.Columns["PartnerName"].HeaderText = "Tiekėjas";
            dView.Columns["IOStateName"].HeaderText = "Būsena";
            dView.Columns["CreateDate"].HeaderText = "Sukūrimo data";
            dView.Columns["UpdateDate"].HeaderText = "Atnaujinta";

            dView.Columns["ReceivingDocId"].Visible = false;
            dView.Columns["RcvOrderId"].Visible = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            tWarehouse.Text = Sql.GetString($"SELECT dbo.GetWarehouseName({GlobalUser.CurrentWarehouseId})");
            if (DocId != -1)
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
                "@Obj1", DocId, "@Obj1Name", nameof(DocId),
                "@Obj2", tDocNo.Text, "@Obj2Name", nameof(tDocNo).Substring(1),
                "@Obj3", tWarehouse.Text, "@Obj3Name", nameof(tWarehouse).Substring(1),
                "@Obj4", DateTime.Now.ToShortDateString(), "@Obj4Name", nameof(DateTime),
                "@Obj5", DateTime.Now.ToShortDateString(), "@Obj5Name", nameof(DateTime)
            });
        }
    }
}
