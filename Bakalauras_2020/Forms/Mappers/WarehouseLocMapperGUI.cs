using Bakalauras_2020.Forms.Warehouse.Items;
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
    public partial class WarehouseLocMapperGUI : Form
    {
        public WarehouseLocMapperGUI()
        {
            InitializeComponent();
            SetupGrid();
            LoadData();
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
                WarehouseLocMapper.selectedId = NullCheck.IsNullInt(dataGridView1.SelectedRows[0].Cells["LocationId"].Value);
                this.Close();
            }
        }

        public void LoadData()
        {
            DataTable dt = Sql.GetTable("SelectLocationsForMapper");
            dataGridView1.DataSource = dt;
            ProcessGrid();
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
            dataGridView1.Columns["LocationId"].Visible = false;
        }

        private void TranslateColumns()
        {
            dataGridView1.Columns["BuildingNumber"].HeaderText = "Pastato numeris";
            dataGridView1.Columns["City"].HeaderText = "Miestas";
            dataGridView1.Columns["Country"].HeaderText = "Šalis";
            dataGridView1.Columns["FlatNumber"].HeaderText = "Buto numeris";
            dataGridView1.Columns["LocationId"].HeaderText = "Vietovės ID";
            dataGridView1.Columns["StreetName"].HeaderText = "Gatvės pavadinimas";
            dataGridView1.Columns["CreateDate"].HeaderText = "Sukūrimo data";
            dataGridView1.Columns["UpdateDate"].HeaderText = "Atnaujinta";
        }

        private void ResizeColumns()
        {
            for (int index = 0; index < dataGridView1.ColumnCount; index++)
            {
                dataGridView1.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            LocationEditor iEdt = new LocationEditor();
            iEdt.LocationId = GetSelectedItemId(dataGridView1);
            iEdt.ShowDialog();
            LoadData();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            LocationEditor iEdt = new LocationEditor();
            iEdt.ShowDialog();
            LoadData();
        }

        private int GetSelectedItemId(DataGridView dView)
        {
            if (dView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Pasirinkite eilutę, kurią norite redaguoti!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return NullCheck.IsNullInt(dView.SelectedRows[0].Cells["LocationId"].Value);
        }
    }
}
