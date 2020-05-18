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

                Tip.SetToolTip(lUserInfo, $"ID: {GlobalUser.UserId}\nVartotojas: {GlobalUser.Username}\nVardas: {GlobalUser.Name}\nPavardė: {GlobalUser.Surname}\nSandėlio ID: {GlobalUser.CurrentWarehouseId}\nSandėlio pavadinimas: {GlobalUser.CurrentWarehouseName}");
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

        private void ShowChild(Form frm)
        {
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void veiksmųIstorijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.SuperUser)
                ShowChild(new ActionLog());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void prekėsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new Items());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sandėliaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 5 || GlobalUser.SuperUser)
                ShowChild(new Warehouses());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void sandėlioZonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 5 || GlobalUser.SuperUser)
                ShowChild(new WarehouseZones());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void priėmimoUžsakymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new ReceivingDocs());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void priėmimoDokumentaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new ReceivingOrder());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pristatymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new Shipment());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void išsiuntimoUžsakymaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new OutOrder());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void siuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new Parcels());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void surinkimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new WorkOrders());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tipaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new PalletType());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void paletėsSandėlyjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new StoredPallets());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void prekėsAntPalečiųToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUser.UserLevel >= 3 || GlobalUser.SuperUser)
                ShowChild(new StoredItems());
            else
                MessageBox.Show("Jūs neturite teisės peržiūrėti šio sąrašo!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
