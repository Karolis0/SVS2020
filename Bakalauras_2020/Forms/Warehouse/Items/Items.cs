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
    public partial class Items : BTpl
    {
        public Items()
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
            dView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dView.Columns["ItemId"].Visible = false;
        }

        private void TranslateColumns(DataGridView dView)
        {
            dView.Columns["Code"].HeaderText = "Prekės kodas";
            dView.Columns["Name"].HeaderText = "Prekės pavadinimas";
            dView.Columns["Description"].HeaderText = "Prekės aprašymas";
            dView.Columns["ItemTypeName"].HeaderText = "Prekės tipas";
            dView.Columns["NetWeight"].HeaderText = "Neto svoris";
            dView.Columns["BrutoWeight"].HeaderText = "Bruto svoris";
            dView.Columns["UnitCode"].HeaderText = "Matavimo vienetas";
            dView.Columns["Volume"].HeaderText = "Tūris";
            dView.Columns["WarehouseCode"].HeaderText = "Sandėlio kodas";
            dView.Columns["CreateDate"].HeaderText = "Sukurta";
            dView.Columns["UpdateDate"].HeaderText = "Atnaujinta";   
            dView.Columns["Barcode"].HeaderText = "Barkodas";   
            dView.Columns["Height"].HeaderText = "Aukštis";   
            dView.Columns["Width"].HeaderText = "Plotis";   

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
            SelectSql = "GetItemsByWarehouse";
            DeleteSql = "DeleteItem";
            FormMainId = "ItemId";
        }

        public override void bAdd_Click(object sender, EventArgs e)
        {
            base.bAdd_Click(sender, e);
            ItemEditor iEdt = new ItemEditor();
            if (iEdt.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            };

        }

        public override void tUpdate_Click(object sender, EventArgs e)
        {
            base.tUpdate_Click(sender, e);
            ItemEditor iEdt = new ItemEditor();
            iEdt.ItemId = GetSelectedItemId(AccessGrid());
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
