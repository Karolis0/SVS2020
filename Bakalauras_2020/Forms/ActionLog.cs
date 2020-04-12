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
    public partial class ActionLog : BTpl
    {
        public ActionLog()
        {
            InitializeComponent();
            SetupForm();
        }

        public override void BeforeDataLoad()
        {
            base.BeforeDataLoad();
            SelectSql = "GetActionLogData";
            ApplyWarehouseFilter = false;
        }

        private void SetupForm()
        {
            ModifyGrid(AccessGrid());
            ModifyPanel(AccessPanel());
            ModifyToolStrip(AccessToolStrip());
        }

        private void ModifyGrid(DataGridView dView)
        {
            HideColumns(dView);
            TranslateColumns(dView);
            ResizeColumns(dView);
            dView.ReadOnly = true;
        }

        private void HideColumns(DataGridView dView)
        {
            dView.Columns["LogId"].Visible = false; 
        }

        private void TranslateColumns(DataGridView dView)
        {
            dView.Columns["Procedure"].HeaderText = "Procedūra";
            string columnSubString = "Obj";
            for (int index = 1; index < 15; index++)
            {
                dView.Columns[columnSubString + index.ToString()].HeaderText = "Objektas " + index.ToString();
                dView.Columns[columnSubString + index.ToString()+"Name"].HeaderText = "Objekto " + index.ToString() + " pavadinimas";
            }
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

        private void ModifyToolStrip(ToolStrip tStrip)
        {
            tStrip.Hide();
        }
    }
}
