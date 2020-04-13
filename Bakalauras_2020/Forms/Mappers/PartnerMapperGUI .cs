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
    public partial class PartnerMapperGUI : Form
    {
        public bool RequestSupplier = false;
        public bool RequestCustomer = false;

        public PartnerMapperGUI()
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
                PartnerMapper.selectedId = NullCheck.IsNullInt(dataGridView1.SelectedRows[0].Cells["PartnerId"].Value);
                this.Close();
            }
        }

        public void LoadData()
        {
            DataTable dt = Sql.GetTable("SelectPartnersForMapper", new object[]
                {
                    "@Customer", RequestCustomer,
                    "@Supplier", RequestSupplier
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
            dataGridView1.Columns["PartnerId"].Visible = false;
        }

        private void TranslateColumns()
        {
            dataGridView1.Columns["PartnerCode"].HeaderText = "Partnerio kodas";
            dataGridView1.Columns["PartnerName"].HeaderText = "Partnerio pavadinimas";
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
            PartnerEditor iEdt = new PartnerEditor();
            iEdt.PartnerId = GetSelectedItemId(dataGridView1);
            iEdt.ShowDialog();
            LoadData();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            PartnerEditor iEdt = new PartnerEditor();
            iEdt.ShowDialog();
            LoadData();
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
