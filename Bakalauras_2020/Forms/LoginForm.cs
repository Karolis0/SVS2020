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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            SetUpFormParams();
        }

        public void SetUpFormParams()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            lFailedLogin.Visible = false;
            tUsername.Focus();
            Bitmap map = new Bitmap(Properties.Resources.LoginImg);
            map.MakeTransparent(map.GetPixel(1,1));
            pictureBox1.Image = map;


#if DEBUG
            tUsername.Text = "ks";
            tPassword.Text = "ks";
#endif
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tUsername.Text) || string.IsNullOrEmpty(tPassword.Text))
            {
                return;
            }
            DataTable dt = Sql.GetTable("GetUserData", new string[]
            {
                "@Username", tUsername.Text,
                "@Password", tPassword.Text
            });

            if (dt == null || dt.Rows.Count == 0)
            {
                lFailedLogin.Visible = true;
                return;
            }
            this.ShowInTaskbar = false;
            this.Hide();
            GlobalUser.ParseDataTable(dt);
            MainForm mainFrm = new MainForm();
            mainFrm.Show();
        }

        private void tUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bLogin.PerformClick();
            }
        }

        private void tPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bLogin.PerformClick();
            }
        }
    }
}
