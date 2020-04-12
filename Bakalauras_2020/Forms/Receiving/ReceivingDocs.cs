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
    public partial class ReceivingDocs : BTpl
    {
        public readonly string GetRecDocItems = "GetOrderedItemsByReceivingDocId";

        public ReceivingDocs()
        {
            InitializeComponent();
            SetupForm();
        }

        public override void BeforeDataLoad()
        {
            base.BeforeDataLoad();
            SelectSql = "SelectReceivingDocs";
            DeleteSql = "DeleteReceivingDoc";
            FormMainId = "ReceivingDocId";
        }

        private void SetupForm()
        {
            dataGridView2.Visible = false;
            ModifyGrid(AccessGrid());
            ModifyGridDet(dataGridView2);
        }

        private void ModifyGridDet(DataGridView dView)
        {
            ResizeColumns(dView);
            ProcessGridControls(dView);
            ProcessReadOnlyCells(dView);
        }

        private void ProcessReadOnlyCells(DataGridView dView)
        {

        }

        private void ProcessGridControls(DataGridView dView)
        {
            dView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dView.Columns["Name"].Frozen = true;
            dView.Columns["Code"].Frozen = true;
            dView.Columns["Barcode"].Frozen = true;
            dView.CellValueChanged += DView_CellValueChanged;
        }

        private void DView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                if (row != null)
                {
                    if (!ValidateRow(row))
                        return;
                    SaveRow();
                }
            }
        }

        private bool ValidateRow(DataGridViewRow row)
        {
            return true;
        }

        private void ModifyGrid(DataGridView dView)
        {
            HideColumns(dView);
            TranslateColumns(dView);
            ResizeColumns(dView);
            dView.ReadOnly = true;
            dView.SelectionChanged += DView_SelectionChanged;
            dView.DoubleClick += DView_DoubleClick;
        }

        private void DView_DoubleClick(object sender, EventArgs e)
        {
            AccessToolStrip().Items["bUpdate"].PerformClick();
        }

        private void DView_SelectionChanged(object sender, EventArgs e)
        {
            ChangeButtonBehaviour(AccessGrid());
            if (AccessGrid().SelectedRows.Count > 0)
            {
                dataGridView2.Visible = true;
                MapOrderedItemData(NullCheck.IsNullInt(AccessGrid().SelectedRows[0].Cells["ReceivingDocId"].Value));
            }
            else
            {
                dataGridView2.Visible = false;
            }
        }

        private void MapOrderedItemData(int RcvDocId)
        {
            DataTable dt = Sql.GetTable(GetRecDocItems, new object[] { "@ReceivingDocId", RcvDocId});
            dataGridView2.DataSource = dt;
            TranslateColumnsDet(dataGridView2);
        }

        private void TranslateColumnsDet(DataGridView dView)
        {
            dView.Columns["Name"].HeaderText = "Prekės pavadinimas";
            dView.Columns["Code"].HeaderText = "Prekės kodas";
            dView.Columns["Barcode"].HeaderText = "Barkodas";
            dView.Columns["Description"].HeaderText = "Prekės aprašymas";
            dView.Columns["ItemTypeName"].HeaderText = "Prekės tipas";
            dView.Columns["Quantity"].HeaderText = "Užsakytas kiekis";
            dView.Columns["NetWeight"].HeaderText = "Neto kiekis";
            dView.Columns["TotalNetto"].HeaderText = "Bendras neto kiekis";
            dView.Columns["BrutoWeight"].HeaderText = "Bruto kiekis";
            dView.Columns["TotalBruto"].HeaderText = "Bendras bruto kiekis";
            dView.Columns["UnitName"].HeaderText = "Mato vienetas";
            dView.Columns["Volume"].HeaderText = "Tūris";
            dView.Columns["Width"].HeaderText = "Plotis";
            dView.Columns["Height"].HeaderText = "Aukštis";
            dView.Columns["CreateDate"].HeaderText = "Sukūrimo data";
            dView.Columns["UpdateDate"].HeaderText = "Atnaujinta";
        }

        private void ChangeButtonBehaviour(DataGridView dView)
        {
            if (dView.SelectedRows.Count > 0)
            {
                AccessToolStrip().Items["bUpdate"].Enabled = true;
            }
            else
            {
                AccessToolStrip().Items["bUpdate"].Enabled = false;
            }
        }

        private void HideColumns(DataGridView dView)
        {
            dView.Columns["ReceivingDocId"].Visible = false;
            dView.Columns["PartnerCode"].Visible = false;
            dView.Columns["WarehouseCode"].Visible = false;
        }

        private void TranslateColumns(DataGridView dView)
        {
            dView.Columns["DocCode"].HeaderText = "Dokumento numeris";
            dView.Columns["PartnerName"].HeaderText = "Tiekėjas";
            dView.Columns["WarehouseName"].HeaderText = "Sandėlis";
            dView.Columns["ArrivalPlaned"].HeaderText = "Numatomas atvykimas";
            dView.Columns["TruckNo"].HeaderText = "Transporto priemonės numeris";
            dView.Columns["TrailerNo"].HeaderText = "Priekabos numeris";
            dView.Columns["Driver"].HeaderText = "Vairuotojas";
            dView.Columns["CreateDate"].HeaderText = "Sukūrimo data";
            dView.Columns["UpdateDate"].HeaderText = "Atnaujinta";
        }

        private void ResizeColumns(DataGridView dView)
        {
            for (int index = 0; index < dView.ColumnCount; index++)
            {
                dView.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public override void bAdd_Click(object sender, EventArgs e)
        {
            base.bAdd_Click(sender, e);
            ReceivingDocEditor iEdt = new ReceivingDocEditor();
            if (iEdt.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            };

        }

        public override void tUpdate_Click(object sender, EventArgs e)
        {
            base.tUpdate_Click(sender, e);
            ReceivingDocEditor iEdt = new ReceivingDocEditor();
            iEdt.DocId = GetSelectedItemId(AccessGrid());
            if (iEdt.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            };
        }

        private int GetSelectedItemId(DataGridView dView)
        {
            if (dView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Pasirinkite eilutę, kurią norite redaguoti!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return NullCheck.IsNullInt(dView.SelectedRows[0].Cells[FormMainId].Value);
        }
    }
}
