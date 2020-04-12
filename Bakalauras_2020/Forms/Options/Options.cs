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

namespace Bakalauras_2020.Forms.Options
{
    public partial class Options : Form
    {

        public static readonly string WarehouseComboSql = "GetWarehousesComboBox";
        bool ValueChanged = false;

        public Options()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            DataTable dt = Sql.GetTable(WarehouseComboSql);
            cWarehouses.DataSource = dt;
            cWarehouses.DisplayMember = "WarehouseCode";
            cWarehouses.ValueMember = "WarehouseId";

            cWarehouses.SelectedValue = GlobalUser.CurrentWarehouseId;
            cWarehouses.SelectedValueChanged += CWarehouses_SelectedValueChanged;
        }

        private void CWarehouses_SelectedValueChanged(object sender, EventArgs e)
        {
            if (GlobalUser.CurrentWarehouseId != NullCheck.IsNullInt(cWarehouses.SelectedValue))
            {
                ValueChanged = true;
            }
            else
            {
                ValueChanged = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValueChanged)
            {
                GlobalUser.CurrentWarehouseId = NullCheck.IsNullInt(cWarehouses.SelectedValue);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
