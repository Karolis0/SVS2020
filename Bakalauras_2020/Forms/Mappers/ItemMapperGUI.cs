using Bakalauras_2020.Forms.Warehouse.Items;
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

namespace Bakalauras_2020.Forms.Mappers
{
    public partial class ItemMapperGUI : Form
    {
        public ItemMapperGUI()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ItemMapper.selectedId = NullCheck.IsNullInt(dataGridView1.SelectedRows[0].Cells["ItemId"].Value);
                this.Close();
            }
        }

        public void LoadData()
        {
            DataTable dt = Sql.GetTable("GetItemsByWarehouse", new object[]
                {
                    "@WhId", GlobalUser.CurrentWarehouseId
                });
            dataGridView1.DataSource = dt;
            ProcessGrid();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadData();
        }

        private void ProcessGrid()
        {
            HideColumns();
            TranslateColumns();
            ResizeColumns();
            dataGridView1.ReadOnly = true;
        }

        private void HideColumns()
        {
            dataGridView1.Columns["ItemId"].Visible = false;
        }

        private void TranslateColumns()
        {
            dataGridView1.Columns["Code"].HeaderText = "Prekės kodas";
            dataGridView1.Columns["Name"].HeaderText = "Prekės pavadinimas";
            dataGridView1.Columns["Description"].HeaderText = "Prekės aprašymas";
            dataGridView1.Columns["ItemTypeName"].HeaderText = "Prekės tipas";
            dataGridView1.Columns["NetWeight"].HeaderText = "Neto svoris";
            dataGridView1.Columns["BrutoWeight"].HeaderText = "Bruto svoris";
            dataGridView1.Columns["UnitCode"].HeaderText = "Matavimo vienetas";
            dataGridView1.Columns["Volume"].HeaderText = "Tūris";
            dataGridView1.Columns["WarehouseCode"].HeaderText = "Sandėlio kodas";
            dataGridView1.Columns["CreateDate"].HeaderText = "Sukūrimo data";
            dataGridView1.Columns["UpdateDate"].HeaderText = "Atnaujinta";
            dataGridView1.Columns["Barcode"].HeaderText = "Barkodas";
            dataGridView1.Columns["Height"].HeaderText = "Aukštis";
            dataGridView1.Columns["Width"].HeaderText = "Plotis";
        }

        private void ResizeColumns()
        {
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private int GetSelectedItemId(DataGridView dView)
        {
            if (dView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Pasirinkite eilutę, kurią norite redaguoti!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return NullCheck.IsNullInt(dView.SelectedRows[0].Cells["PartnerId"].Value);
        }
    }
}
