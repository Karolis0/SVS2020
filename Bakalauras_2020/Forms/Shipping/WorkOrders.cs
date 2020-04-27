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
    public partial class WorkOrders : BTpl
    {
        public WorkOrders()
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
            dView.Columns["WOrderId"].Visible = false;
            dView.Columns["WOrderTypeId"].Visible = false;
            dView.Columns["WOrderStatusId"].Visible = false;
            dView.Columns["OutOrderId"].Visible = false;
            dView.Columns["ItemId"].Visible = false;
            dView.Columns["WarehouseId"].Visible = false;
            dView.Columns["WarehouseCode"].Visible = false;
        }

        private void TranslateColumns(DataGridView dView)
        {
            dView.Columns["WOrderType"].HeaderText = "Surinkimo tipas";
            dView.Columns["WOrderStatus"].HeaderText = "Būsena";
            dView.Columns["DocumentNo"].HeaderText = "Išsiuntimo dokumento nr.";
            dView.Columns["Name"].HeaderText = "Prekės pavadinimas";
            dView.Columns["Code"].HeaderText = "Paletės kodas";
            dView.Columns["Barcode"].HeaderText = "Prekės barkodas";
            dView.Columns["Description"].HeaderText = "Prekės aprašymas";
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
            SelectSql = "SelectWorkOrders";
        }
    }
}
