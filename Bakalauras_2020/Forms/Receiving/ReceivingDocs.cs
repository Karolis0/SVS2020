using Bakalauras_2020.Forms.Mappers;
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
        private int? CurrentRcvDocId = -1;
        public readonly string GetRecDocItems = "GetOrderedItemsByReceivingDocId";
        public readonly string SaveRcvDocDet = "SaveOrderedItem";
        public readonly string UpdateRcvDocDet = "UpdateOrderedItem";

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
        }

        private void ModifyGridDet(DataGridView dView)
        {
            ResizeColumns(dView);
            ProcessGridControls(dView);
        }

        private void ProcessReadOnlyCells(DataGridView dView)
        {
            dView.Columns["Name"].ReadOnly = true;
            dView.Columns["Code"].ReadOnly = true;
            dView.Columns["Barcode"].ReadOnly = true;
            dView.Columns["Description"].ReadOnly = true;
            dView.Columns["ItemTypeName"].ReadOnly = true;
            dView.Columns["NetWeight"].ReadOnly = true;
            dView.Columns["TotalNetto"].ReadOnly = true;
            dView.Columns["BrutoWeight"].ReadOnly = true;
            dView.Columns["TotalBruto"].ReadOnly = true;
            dView.Columns["UnitName"].ReadOnly = true;
            dView.Columns["Volume"].ReadOnly = true;
            dView.Columns["Width"].ReadOnly = true;
            dView.Columns["Height"].ReadOnly = true;
            dView.Columns["Created"].ReadOnly = true;
            dView.Columns["Updated"].ReadOnly = true;
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
                    SaveRow(row);
                }
            }
        }

        public void SaveRow(DataGridViewRow row)
        {
            int rowAffected = Sql.ExecuteCmd(NullCheck.IsNullInt(row.Cells["OrderedItemsId"].Value) <= 0 ? SaveRcvDocDet : UpdateRcvDocDet, new object[]
            {
                "@OrderedItemId", NullCheck.IsNullInt(row.Cells["OrderedItemsId"].Value),
                "@Quantity", NullCheck.IsNullDecimal(row.Cells["Quantity"].Value),
                "@Created", DateTime.Now,
                "@Updated", DateTime.Now,
                "@ItemId", NullCheck.IsNullInt(row.Cells["ItemId"].Value),
                "@RcvDocId", CurrentRcvDocId
            });

            if (rowAffected > 0)
            {
                dataGridView2.Rows.Add();
            }
        }

        private bool ValidateRow(DataGridViewRow row)
        {
            if (NullCheck.IsNullDecimal(row.Cells["Quantity"].Value) <= 0)
            {
                return false;
            }

            decimal TotalNetto = NullCheck.IsNullDecimal(row.Cells["Quantity"].Value) * NullCheck.IsNullDecimal(row.Cells["NetWeight"].Value);
            decimal TotalBruto = NullCheck.IsNullDecimal(row.Cells["Quantity"].Value) * NullCheck.IsNullDecimal(row.Cells["BrutoWeight"].Value);
            row.Cells["TotalNetto"].Value = TotalNetto;
            row.Cells["TotalBruto"].Value = TotalBruto;

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
            if (AccessGrid().SelectedRows.Count > 0 && NullCheck.IsNullInt(AccessGrid().SelectedRows[0].Cells["ReceivingDocId"].Value) > 0)
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
            CurrentRcvDocId = RcvDocId;
            DataTable dt = Sql.GetTable(GetRecDocItems, new object[] { "@ReceivingDocId", RcvDocId});
            dataGridView2.DataSource = dt;
            dt.Rows.Add();
            ModifyGridDet(dataGridView2);
            TranslateColumnsDet(dataGridView2);
            HideColumnsDet(dataGridView2);
            ProcessReadOnlyCells(dataGridView2);
            dataGridView2.CellClick += DataGridView2_CellClick; ;
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                if (row.Cells["Name"].Selected || row.Cells["Code"].Selected)
                {
                    int SelectedItemId = ItemMapper.SelectItemId();
                    if (SelectedItemId > 0)
                    {
                        DataTable dt = Sql.GetTable("SelectItemList", new object[] { "@ItemId", SelectedItemId });
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            row.Cells["Name"].Value = NullCheck.IsNullString(dt.Rows[0]["Name"]);
                            row.Cells["Code"].Value = NullCheck.IsNullString(dt.Rows[0]["Code"]);
                            row.Cells["Barcode"].Value = NullCheck.IsNullString(dt.Rows[0]["Barcode"]);
                            row.Cells["Description"].Value = NullCheck.IsNullString(dt.Rows[0]["Description"]);
                            row.Cells["ItemTypeName"].Value = NullCheck.IsNullString(dt.Rows[0]["Name"]);
                            row.Cells["NetWeight"].Value = NullCheck.IsNullString(dt.Rows[0]["NetWeight"]);
                            row.Cells["BrutoWeight"].Value = NullCheck.IsNullString(dt.Rows[0]["BrutoWeight"]);
                            row.Cells["UnitName"].Value = NullCheck.IsNullString(dt.Rows[0]["UnitName"]);
                            row.Cells["Volume"].Value = NullCheck.IsNullString(dt.Rows[0]["Volume"]);
                            row.Cells["Width"].Value = NullCheck.IsNullString(dt.Rows[0]["Width"]);
                            row.Cells["Height"].Value = NullCheck.IsNullString(dt.Rows[0]["Height"]);
                        }
                    }
                }
            }
        }

        private void HideColumnsDet(DataGridView dView)
        {
            dView.Columns["OrderedItemId"].Visible = false;
            dView.Columns["ItemId"].Visible = false;
            dView.Columns["ReceivingDocId"].Visible = false;
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
            dView.Columns["Created"].HeaderText = "Sukūrimo data";
            dView.Columns["Updated"].HeaderText = "Atnaujinta";
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
            dView.Columns["IOStateName"].HeaderText = "Būsena";
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
