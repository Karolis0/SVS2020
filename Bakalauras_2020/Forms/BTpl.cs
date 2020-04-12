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

namespace Bakalauras_2020.Forms
{
    public partial class BTpl : Form
    {

        public static string SelectSql = string.Empty;
        public static string DeleteSql = string.Empty;
        public static string UpdateSql = string.Empty;
        public static string FormMainId = string.Empty;
        public bool ApplyWarehouseFilter = true;
        public bool CustomDelete = false;

        public BTpl()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            BeforeDataLoad();
            FetchData();
            AfterDataLoad();
        }

        public virtual void BeforeDataLoad()
        {}

        private void FetchData()
        {
            if (string.IsNullOrEmpty(SelectSql))
            {
                MessageBox.Show("Nenurodyta duomenų krovimo procedūra", "Įspėjimas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataTable dtable = null;
            if (ApplyWarehouseFilter)
            {
                dtable = Sql.GetTable(SelectSql, new object[] {

                "@Whid", GlobalUser.CurrentWarehouseId
                });
            }
            else
            {
                dtable = Sql.GetTable(SelectSql);
            }

            dataGridView1.DataSource = dtable;
            ProcessDGrid();
        }

        public void ProcessDGrid()
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public virtual void AfterDataLoad()
        {}

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!CustomDelete)
            {
                if (string.IsNullOrEmpty(DeleteSql))
                {
                    MessageBox.Show("Nenurodyta duomenų trynimo procedūra", "Įspėjimas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dataGridView1.SelectedCells.Count <= 0)
                {
                    MessageBox.Show("Nepasirinkta duomenų eilutė", "Įspėjimas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(FormMainId))
                {
                    MessageBox.Show("Nenurodytas formos ID", "Įspėjimas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = NullCheck.IsNullInt(NullCheck.IsNullString(dataGridView1.SelectedRows[0].Cells[FormMainId].Value));

                if (id > 0)
                {
                    Sql.ExecuteCmd(DeleteSql, new object[]
                    {
                    $"@{FormMainId}", id
                    });
                }
                RefreshGrid();
            }
        }

        public virtual void bAdd_Click(object sender, EventArgs e)
        { }

        public virtual void tUpdate_Click(object sender, EventArgs e)
        { }

        public DataGridView AccessGrid()
        {
            return this.dataGridView1;
        }

        public ToolStrip AccessToolStrip()
        {
            return this.toolStrip1;
        }

        public Panel AccessPanel()
        {
            return this.panel1;
        }

        public void RefreshGrid() => FetchData();
    }
}
