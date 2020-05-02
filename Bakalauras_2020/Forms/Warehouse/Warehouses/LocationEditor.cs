using Bakalauras_2020.Forms.Mappers;
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

namespace Bakalauras_2020.Forms.Warehouse.Items
{
    public partial class LocationEditor : Form
    {
        public int LocationId = -1;
        public static readonly string SelectProcedure = "SelectLocationById";
        public static readonly string SaveProcedure = "SaveLocation";
        public static readonly string UpdateProcedure = "UpdateLocation";    

        public LocationEditor()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            tCreated.Enabled = false;
            tUpdated.Enabled = false;
        }

        private void Save()
        {
            if (LocationId == -1)
                Sql.ExecuteCmd(SaveProcedure, new object[] {
                    "@Country", tCountry.Text,
                    "@City", tCity.Text,
                    "@StreetName", tStreetName.Text,
                    "@BuildingNo", tBuildingNo.Text,
                    "@FlatNo", tFlatNo.Text,
                    "@CreateDate", DateTime.Now.ToShortDateString(),
                    "@UpdateDate", DateTime.Now.ToShortDateString(),
                    "@LocationCode", tLocationCode.Text
                });
            else
                Sql.ExecuteCmd(UpdateProcedure, new object[] {
                    "@LocationId", LocationId,
                    "@Country", tCountry.Text,
                    "@City", tCity.Text,
                    "@StreetName", tStreetName.Text,
                    "@BuildingNo", tBuildingNo.Text,
                    "@FlatNo", tFlatNo.Text,
                    "@UpdateDate", DateTime.Now.ToShortDateString(),
                    "@LocationCode", tLocationCode.Text
                });
            LogAction(LocationId == -1 ? SaveProcedure : UpdateProcedure);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (!ValidInput())
                return;
            Save();
        }

        private bool ValidInput()
        {
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(tLocationCode.Text))
            {
                tCountry.Invalidate();
                errorMsg += "Negalimas vietovės kodas\n";
            }

            if (string.IsNullOrEmpty(tCountry.Text))
            {
                tCountry.Invalidate();
                errorMsg += "Negalimas šalies pavadinimas\n";
            }

            if (string.IsNullOrEmpty(tCity.Text))
            {
                tCountry.Invalidate();
                errorMsg += "Negalimas miesto pavadinimas\n";
            }
            if (string.IsNullOrEmpty(tStreetName.Text))
            {
                tCountry.Invalidate();
                errorMsg += "Negalimas gatvės pavadinimas\n";
            }
            if (string.IsNullOrEmpty(tBuildingNo.Text))
            {
                tCountry.Invalidate();
                errorMsg += "Negalimas pastato numeris\n";
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show("Negalima išsaugoti vietovės:\n" + errorMsg, "Klaida", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadData()
        {
            DataTable dt = Sql.GetTable(SelectProcedure, new object[] { "@LocationID", LocationId });
            if (dt.Rows.Count > 0)
            {
                tLocationCode.Text = NullCheck.IsNullString(dt.Rows[0]["LocationCode"]);
                tCountry.Text = NullCheck.IsNullString(dt.Rows[0]["Country"]);
                tCity.Text = NullCheck.IsNullString(dt.Rows[0]["City"]);
                tStreetName.Text = NullCheck.IsNullString(dt.Rows[0]["StreetName"]);
                tBuildingNo.Text = NullCheck.IsNullString(dt.Rows[0]["BuildingNumber"]);
                tFlatNo.Text = NullCheck.IsNullString(dt.Rows[0]["FlatNumber"]);
                tCreated.Text = NullCheck.IsNullDate(dt.Rows[0]["CreateDate"]).ToShortDateString();
                tUpdated.Text = NullCheck.IsNullDate(dt.Rows[0]["UpdateDate"]).ToShortDateString();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (LocationId != -1)
            {
                LoadData();
            }
        }

        private void tVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void LogAction(string Command)
        {
            Sql.LogAction(new object[] {
                "Procedure", Command,
                "@Obj1", LocationId, "@Obj1Name", nameof(LocationId),
                "@Obj2", tLocationCode.Text, "@Obj2Name", nameof(tLocationCode).Substring(1),
                "@Obj3", tCity.Text, "@Obj3Name", nameof(tCity).Substring(1),
                "@Obj4", tStreetName.Text, "@Obj4Name", nameof(tStreetName).Substring(1),
                "@Obj5", tStreetName.Text, "@Obj5Name", nameof(tStreetName).Substring(1),
                "@Obj6", tStreetName.Text, "@Obj6Name", nameof(tStreetName).Substring(1),
                "@Obj7", DateTime.Now.ToShortDateString(), "@Obj7Name", nameof(DateTime),
                "@Obj8", DateTime.Now.ToShortDateString(), "@Obj8Name", nameof(DateTime)
            });
        }

        private void LocationEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
