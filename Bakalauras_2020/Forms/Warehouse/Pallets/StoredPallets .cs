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
    public partial class StoredPallets : BTpl
    {
        public StoredPallets()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            ModifyPanel(AccessPanel());
            ModifyToolStrip(AccessToolStrip());
            ModifyGrid(AccessGrid());
        }

        private void ModifyGrid(DataGridView dView)
        {
            HideColumns(dView);
            TranslateColumns(dView);
            ResizeColumns(dView);
            dView.ReadOnly = true;
            dView.Dock = DockStyle.Fill;
            dView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dView.AllowUserToAddRows = false;
        }

        private void HideColumns(DataGridView dView)
        {
            dView.Columns["StoredPalletId"].Visible = false;
            dView.Columns["ZoneLocationId"].Visible = false;
        }

        private void TranslateColumns(DataGridView dView)
        {
            dView.Columns["Barcode"].HeaderText = "Paletės barkodas";
            dView.Columns["ZoneCode"].HeaderText = "Vietos kodas";
            dView.Columns["ZoneName"].HeaderText = "Vietos pavadinimas";
            dView.Columns["WarehouseName"].HeaderText = "Sandėlio pavadinimas";
            dView.Columns["Created"].HeaderText = "Sukurta";
            dView.Columns["Updated"].HeaderText = "Atnaujinta";
        }

        private void ResizeColumns(DataGridView dView)
        {
            for (int index = 0; index < dView.ColumnCount; index++)
            {
                dView.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void ModifyPanel(Panel panel)
        {
            panel.Hide();
        }

        private void ModifyToolStrip(ToolStrip strip)
        {
            strip.Hide();
        }

        public override void BeforeDataLoad()
        {
            base.BeforeDataLoad();
            SelectSql = "SelectStoredPallets";
            FormMainId = "StoredPalletId";
        }
    }
}
