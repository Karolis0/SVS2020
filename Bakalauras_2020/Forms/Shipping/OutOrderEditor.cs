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
    public partial class OutOrderEditor : Form
    {
        public int DocId = -1;
        private int SelectedPartnerId = -1;
        private int StateId = 1;
        public static readonly string SelectProcedure = "GetOutOrderByID";
        public static readonly string SaveProcedure = "SaveOutOrder";
        public static readonly string UpdateProcedure = "UpdateOutOrder";    

        public OutOrderEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Load += ReceivingDocEditor_Load;
            tCreateDate.Enabled = false;
            tUpdated.Enabled = false;
            tWarehouse.Enabled = false;
            tState.Enabled = false;
            tCustomer.Enter += TSupplier_GotFocus;
            tCustomer.ReadOnly = true;
            dtPlannedShipment.Format = DateTimePickerFormat.Custom;
            dtPlannedShipment.CustomFormat = "dd-MM-yyyy";
        }

        private void ReceivingDocEditor_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void TSupplier_GotFocus(object sender, EventArgs e)
        {
            SelectedPartnerId = PartnerMapper.SelectPartnerId(Customer: true);
            tCustomer.Text = Sql.GetString($"SELECT dbo.GetPartnerName('{SelectedPartnerId}')");
        }

        private void Save()
        {
            if (DocId == -1)
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@DocNo", tDocNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@PlannedShipment", dtPlannedShipment.Value.ToShortDateString(),
                    "@State", 1,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@CreateDate", DateTime.Now.ToShortDateString(),
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@DocNo", tDocNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@PlannedShipment", dtPlannedShipment.Value.ToShortDateString(),
                    "@State", StateId,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@UpdateDate", DateTime.Now.ToShortDateString(),
                    "@OutOrderId", DocId
                });
            LogAction(DocId == -1 ? SaveProcedure : UpdateProcedure);
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
            if (string.IsNullOrEmpty(tDocNo.Text))
            {
                tDocNo.Text = NullCheck.IsNullString(Sql.GetTable("GenerateDocNoOutOrder").Rows[0][0]);
            }
            if (string.IsNullOrEmpty(tCustomer.Text))
            {
                tCustomer.Invalidate();
                errorMsg += "Negalimas partneris\n";
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti išsiuntimo užsakymo:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@OutOrderId", DocId });
            if (dt.Rows.Count > 0)
            {
                tDocNo.Text = NullCheck.IsNullString(dt.Rows[0]["DocumentNo"]);
                tCustomer.Text = NullCheck.IsNullString(dt.Rows[0]["PartnerName"]);
                dtPlannedShipment.Value = NullCheck.IsNullDate(dt.Rows[0]["ShippingPlanned"]);
                tState.Text = NullCheck.IsNullString(dt.Rows[0]["OOStateName"]);
                tCreateDate.Text = NullCheck.IsNullDate(dt.Rows[0]["Created"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["Updated"]).ToShortDateString();
                SelectedPartnerId = NullCheck.IsNullInt(dt.Rows[0]["PartnerId"]);
                StateId = NullCheck.IsNullInt(dt.Rows[0]["OOStateId"]);
            }
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
                "@Obj3", tCustomer.Text, "@Obj3Name", nameof(tCustomer).Substring(1),
                "@Obj4", dtPlannedShipment.Value.ToShortDateString(), "@Obj4Name", nameof(dtPlannedShipment).Substring(2),
                "@Obj5", tState.Text, "@Obj5Name", nameof(tState).Substring(1),
                "@Obj6", tWarehouse.Text, "@Obj6Name", nameof(tWarehouse).Substring(1),
                "@Obj7", DateTime.Now.ToShortDateString(), "@Obj7Name", nameof(DateTime),
                "@Obj8", DateTime.Now.ToShortDateString(), "@Obj8Name", nameof(DateTime)
            });
        }
    }
}
