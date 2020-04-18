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
    public partial class Shipment : BTpl
    {
        private int? CurrentRcvDocId = -1;
        public readonly string GetRcvOrds = "GetShipmentReceivingOrders";

        public Shipment()
        {
            InitializeComponent();
            SetupForm();
        }

        public override void BeforeDataLoad()
        {
            base.BeforeDataLoad();
            SelectSql = "SelectShipments";
            DeleteSql = "DeleteShipments";
            FormMainId = "ShipmentId";
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
            for (int index = 0; index < dView.ColumnCount; index++)
            {
                dView.Columns[index].ReadOnly = true;
            }
        }

        private void ProcessGridControls(DataGridView dView)
        {
            dView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dView.AllowUserToAddRows = false;
        }

        private void ModifyGrid(DataGridView dView)
        {
            HideColumns(dView);
            TranslateColumns(dView);
            ResizeColumns(dView);
            dView.ReadOnly = true;
            dView.AllowUserToAddRows = false;
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
            if (AccessGrid().SelectedRows.Count > 0 && NullCheck.IsNullInt(AccessGrid().SelectedRows[0].Cells["ShipmentId"].Value) > 0)
            {
                dataGridView2.Visible = true;
                MapOrderedItemData(NullCheck.IsNullInt(AccessGrid().SelectedRows[0].Cells["ShipmentId"].Value));
            }
            else
            {
                dataGridView2.Visible = false;
            }
        }

        private void MapOrderedItemData(int ShipmentId)
        {
            CurrentRcvDocId = ShipmentId;
            DataTable dt = Sql.GetTable(GetRcvOrds, new object[] { "@ShipmentId", ShipmentId});
            dataGridView2.DataSource = dt;
            ModifyGridDet(dataGridView2);
            TranslateColumnsDet(dataGridView2);
            HideColumnsDet(dataGridView2);
            ProcessReadOnlyCells(dataGridView2);
        }

        private void HideColumnsDet(DataGridView dView)
        {
            dView.Columns["RcvOrderId"].Visible = false;
            dView.Columns["WarehouseId"].Visible = false;
            dView.Columns["ShipmentId"].Visible = false;
        }

        private void TranslateColumnsDet(DataGridView dView)
        {
            dView.Columns["DocumentNo"].HeaderText = "Dokumento numeris";
            dView.Columns["WarehouseName"].HeaderText = "Sandėlis";
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
            dView.Columns["PartnerId"].Visible = false;
            dView.Columns["WarehouseId"].Visible = false;
        }

        private void TranslateColumns(DataGridView dView)
        {
            dView.Columns["ShipmentId"].HeaderText = "Siuntos Id";
            dView.Columns["ShipmentNo"].HeaderText = "Siuntos numeris";
            dView.Columns["PartnerName"].HeaderText = "Tiekėjas";
            dView.Columns["WarehouseName"].HeaderText = "Sandėlis";
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
            ShipmentEditor iEdt = new ShipmentEditor();
            if (iEdt.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            };

        }

        public override void tUpdate_Click(object sender, EventArgs e)
        {
            base.tUpdate_Click(sender, e);
            ShipmentEditor iEdt = new ShipmentEditor();
            iEdt.ShipmentId = GetSelectedItemId(AccessGrid());
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
