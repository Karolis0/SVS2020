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
    public partial class ReceivingDocEditor : Form
    {
        public int DocId = -1;
        private int SelectedPartnerId = -1;
        private int StateId = 1;
        public static readonly string SelectProcedure = "GetRcvDocByID";
        public static readonly string SaveProcedure = "SaveRcvDoc";
        public static readonly string UpdateProcedure = "UpdateRcvDoc";    

        public ReceivingDocEditor()
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
            tSupplier.Enter += TSupplier_GotFocus;
            tSupplier.ReadOnly = true;
            dtArrivalPlanned.Format = DateTimePickerFormat.Custom;
            dtArrivalPlanned.CustomFormat = "dd-MM-yyyy";
        }

        private void ReceivingDocEditor_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void TSupplier_GotFocus(object sender, EventArgs e)
        {
            SelectedPartnerId = PartnerMapper.SelectPartnerId(Supplier: true);
            tSupplier.Text = Sql.GetString($"SELECT dbo.GetPartnerName('{SelectedPartnerId}')");
        }

        private void Save()
        {
            if (DocId == -1)
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@DocNo", tDocNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@PlannedArrival", dtArrivalPlanned.Value.ToShortDateString(),
                    "@TruckNo", tTruckNo.Text,
                    "@TrailerNo", tTrailerNo.Text,
                    "@Driver", tDriver.Text,
                    "@State", 1,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@CreateDate", DateTime.Now.ToShortDateString(),
                    "@UpdateDate", DateTime.Now.ToShortDateString()
                });
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@DocNo", tDocNo.Text,
                    "@PartnerId", SelectedPartnerId,
                    "@PlannedArrival", dtArrivalPlanned.Value.ToShortDateString(),
                    "@TruckNo", tTruckNo.Text,
                    "@TrailerNo", tTrailerNo.Text,
                    "@Driver", tDriver.Text,
                    "@State", StateId,
                    "@WarehouseId", GlobalUser.CurrentWarehouseId,
                    "@UpdateDate", DateTime.Now.ToShortDateString(),
                    "@RcvDocId", DocId
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
                tDocNo.Text = NullCheck.IsNullString(Sql.GetTable("GenerateDocNo").Rows[0][0]);
            }
            if (string.IsNullOrEmpty(tSupplier.Text))
            {
                tSupplier.Invalidate();
                errorMsg += "Negalimas partneris\n";
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
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@RcvDocId", DocId });
            if (dt.Rows.Count > 0)
            {
                tDocNo.Text = NullCheck.IsNullString(dt.Rows[0]["DocCode"]);
                tSupplier.Text = NullCheck.IsNullString(dt.Rows[0]["PartnerName"]);
                dtArrivalPlanned.Value = NullCheck.IsNullDate(dt.Rows[0]["ArrivalPlaned"]);
                tTruckNo.Text = NullCheck.IsNullString(dt.Rows[0]["TruckNo"]);
                tTrailerNo.Text = NullCheck.IsNullString(dt.Rows[0]["TrailerNo"]);
                tDriver.Text = NullCheck.IsNullString(dt.Rows[0]["Driver"]);
                tState.Text = NullCheck.IsNullString(dt.Rows[0]["IOStateName"]);
                tCreateDate.Text = NullCheck.IsNullDate(dt.Rows[0]["CreateDate"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["UpdateDate"]).ToShortDateString();
                SelectedPartnerId = NullCheck.IsNullInt(dt.Rows[0]["SupplierId"]);
                StateId = NullCheck.IsNullInt(dt.Rows[0]["StateId"]);
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
                "@Obj3", tSupplier.Text, "@Obj3Name", nameof(tSupplier).Substring(1),
                "@Obj4", dtArrivalPlanned.Value.ToShortDateString(), "@Obj4Name", nameof(dtArrivalPlanned).Substring(2),
                "@Obj5", tTruckNo.Text, "@Obj5Name", nameof(tTruckNo).Substring(1),
                "@Obj6", tTrailerNo.Text, "@Obj6Name", nameof(tTrailerNo).Substring(1),
                "@Obj7", tDriver.Text, "@Obj7Name", nameof(tDriver).Substring(1),
                "@Obj8", tState.Text, "@Obj8Name", nameof(tState).Substring(1),
                "@Obj9", tWarehouse.Text, "@Obj9Name", nameof(tWarehouse).Substring(1),
                "@Obj10", DateTime.Now.ToShortDateString(), "@Obj10Name", nameof(DateTime),
                "@Obj11", DateTime.Now.ToShortDateString(), "@Obj11Name", nameof(DateTime)
            });
        }
    }
}
