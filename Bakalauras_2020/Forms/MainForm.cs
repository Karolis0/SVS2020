using Bakalauras_2020.Forms.Warehouse.Items;
using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using Bakalauras_2020.Forms.Receiving;
using System.Threading.Tasks;

namespace Bakalauras_2020.Forms
{
    public partial class MainForm : Form
    {

        public static readonly string WarehouseComboSql = "GetWarehousesComboBox";

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            DataTable dt = Sql.GetTable(WarehouseComboSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.AsEnumerable().Where(x => x.Field<string>("WarehouseCode") == "TEST").FirstOrDefault() != null)
                {
                    GlobalUser.SetWarehouseId(NullCheck.IsNullInt(dt.AsEnumerable().Where(x => x.Field<string>("WarehouseCode") == "TEST").FirstOrDefault()["WarehouseId"]));
                }
                else
                {
                    GlobalUser.SetWarehouseId(NullCheck.IsNullInt(dt.Rows[0]["WarehouseId"]));
                }
            }
            else
            {
                MessageBox.Show("Nerastas registruotas sandėlys sistemoje.", "Ispėjimas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.MinimizeBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            SetupUserInfo();
        }
        

        private void SetupUserInfo()
        {
            if (GlobalUser.UserLevel > 3 || GlobalUser.SuperUser)
            {
                ToolTip Tip = new ToolTip();
                Tip.ToolTipIcon = ToolTipIcon.Info;
                Tip.IsBalloon = true;
                Tip.ShowAlways = true;

                Tip.SetToolTip(lUserInfo, $"ID: {GlobalUser.UserId}\nVartotojas: {GlobalUser.Username}\nVardas: {GlobalUser.Name}\nPavardė: {GlobalUser.Surname}\nSandėlio ID: {GlobalUser.CurrentWarehouseName}");
            }
            else
            {
                lUserInfo.Visible = false;
            }
        }

        private void tConfig_Click(object sender, EventArgs e)
        {
            Options.Options options = new Options.Options();
            if (options.ShowDialog() == DialogResult.OK)
            {
                SetupUserInfo();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void veiksmųIstorijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionLog frm = new ActionLog();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            
        }

        private void prekėsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items frm = new Items();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void sandėliaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Warehouses frm = new Warehouses();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void sandėlioZonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarehouseZones frm = new WarehouseZones();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void priėmimoUžsakymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceivingDocs frm = new ReceivingDocs();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void priėmimoDokumentaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceivingOrder frm = new ReceivingOrder();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void pristatymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shipment frm = new Shipment();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void išsiuntimoUžsakymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shipment frm = new Shipment();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void siuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shipment frm = new Shipment();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void surinkimasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tipaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PalletType frm = new PalletType();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
