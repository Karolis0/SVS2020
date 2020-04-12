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
    public partial class Warehouses : BTpl
    {
        public Warehouses()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            ModifyGrid(AccessGrid());
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
            dView.Columns["LocationId"].Visible = false;
            dView.Columns["WarehouseId"].Visible = false;
        }

        private void TranslateColumns(DataGridView dView)
        {
            dView.Columns["BuildingNumber"].HeaderText = "Pastato numeris";
            dView.Columns["City"].HeaderText = "Miestas";
            dView.Columns["Country"].HeaderText = "Šalis";
            dView.Columns["CreateDate"].HeaderText = "Sukurta";
            dView.Columns["LocationId"].HeaderText = "Lokacijos ID";
            dView.Columns["StreetName"].HeaderText = "Gatvės pavadinimas";
            dView.Columns["UpdateDate"].HeaderText = "Atnaujinta";
            dView.Columns["WarehouseCode"].HeaderText = "Sandėlio kodas";
            dView.Columns["WarehouseId"].HeaderText = "Sandėlio ID";
            dView.Columns["WarehouseName"].HeaderText = "Sandėlio pavadinimas";
        }

        private void ResizeColumns(DataGridView dView)
        {
            for (int index = 0; index < dView.ColumnCount; index++)
            {
                dView.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public override void BeforeDataLoad()
        {
            base.BeforeDataLoad();
            SelectSql = "GetWarehouses";
            DeleteSql = "DeleteWarehouse";
            FormMainId = "WarehouseId";
            ApplyWarehouseFilter = false;
        }

        public override void bAdd_Click(object sender, EventArgs e)
        {
            base.bAdd_Click(sender, e);
            WarehouseEditor iEdt = new WarehouseEditor();
            if (iEdt.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            };

        }

        public override void tUpdate_Click(object sender, EventArgs e)
        {
            base.tUpdate_Click(sender, e);
            WarehouseEditor iEdt = new WarehouseEditor();
            iEdt.WarehouseId = GetSelectedItemId(AccessGrid());
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
