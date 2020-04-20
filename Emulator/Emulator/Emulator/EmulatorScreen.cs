using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using Emulator.Enums;
using Emulator.Static_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emulator.Emulator
{
    public partial class EmulatorScreen : Form
    {
        private ActiveMenuTypes activeMenu;
        Action processMethod;
        string DataViewMainId = "";

        public EmulatorScreen()
        {
            InitializeComponent();
            DisableInfo();
            HideInput();
            PrepareScreen();
        }

        private void PrepareScreen()
        {
            Parameters.InitializeParams();
            activeMenu = ActiveMenuTypes.Login;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (GlobalUser.UserId == null)
            {
                dView.Visible = false;
                dViewDataShow.Visible = false;
                EnableRows(new string[] { "2", "t1", "t2" });
                EnableInput(true, true);
                SetTitle("Sandėlio valdymo sistema");
                SetRow2("Prisijunkite prie sistemos");
                row2.TextAlign = ContentAlignment.MiddleCenter;
                tBox1Desc.Text = "Vartotojas:";
                tBox2Desc.Text = "Slaptažodis:";
                tBoxInput1.Focus();
                tBoxInput1.KeyDown += TBoxInput_KeyDown;
                tBoxInput2.KeyDown += TBoxInput_KeyDown;
                processMethod = new Action(ValidateLogin);
            }
        }

        private void TBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processMethod();
            }
        }

        private void StoreParameters(string KeyId, string Value)
        {
            Parameters.AddParameter(KeyId, Value);
        }

        private void ValidateLogin()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text) || string.IsNullOrEmpty(tBoxInput2.Text))
            {
                EnableRows(6);
                row6.Text = "Neteisingas prisijungimas";
                row6.ForeColor = Color.Red;
                row6.TextAlign = ContentAlignment.MiddleCenter;
                return;
            }
            DataTable dt = Sql.GetTable("GetUserData", new string[]
            {
                "@Username", tBoxInput1.Text,
                "@Password", tBoxInput2.Text
            });

            if (dt == null || dt.Rows.Count == 0)
            {
                if (!row6.Visible)
                    EnableRows(6);
                row6.Text = "Neteisingas prisijungimas";
                row6.ForeColor = Color.Red;
                row6.TextAlign = ContentAlignment.MiddleCenter;
                return;
            }
            GlobalUser.ParseDataTable(dt);
            DisableInfo();
            ClearLabels();
            ClearInput();
            HideInput();
            SelectWarehouse();
            
        }


        private void SelectWarehouse()
        {
            DataTable dt = Sql.GetTable("GetWarehousesSelector");
            dViewDataShow.DataSource = dt;
            dViewDataShow.Columns["WarehouseName"].HeaderText = "Sandėlio pavadinimas";
            dViewDataShow.Columns["WarehouseCode"].HeaderText = "Sandėlio kodas";
            dViewDataShow.Columns["WarehouseId"].Visible = false;
            dViewDataShow.KeyDown += DViewDataShow_KeyDown;
            dViewDataShow.AllowUserToAddRows = false;
            dViewDataShow.RowHeadersVisible = false;
            dViewDataShow.Dock = DockStyle.Fill;
            dViewDataShow.Select();
            ActiveControl = dView;
            dViewDataShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dViewDataShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dViewDataShow.Visible = true;
            processMethod = new Action(AssignWarehouse);
        }

        private void DViewDataShow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                processMethod();
            }
        }

        private void AssignWarehouse()
        {
            GlobalUser.SetWarehouseId(NullCheck.IsNullInt(dViewDataShow.SelectedRows[0].Cells["WarehouseId"].Value));
            activeMenu = ActiveMenuTypes.MainMenu;
            ClearDataShow();
            HideDataShow();
            ShowMenu(new string[] { "Priėmimas", "Padėjimas", "Surinkimas", "Išvežimas" });
        }

        #region Receiving

        private void InitializeReceiving()
        {
            activeMenu = ActiveMenuTypes.Receiving;
            ResetMenu();
            ShowMenu(new string[] { "Priimti prekes" });
        }

        private void SelectDocument()
        {
            EmptyMenu();
            DataTable dt = Sql.GetTable("GetInProcessRcvDocs", new object[] { "@WhId", GlobalUser.CurrentWarehouseId });
            dView.DataSource = dt;
            dView.Columns["DocCode"].HeaderText = "DokumentoNr";
            dView.Columns["PartnerName"].HeaderText = "Tiekėjas";
            dView.Columns["CreateDate"].HeaderText = "Sukurtas";
            dView.Columns["ReceivingDocId"].Visible = false;
            dView.KeyDown -= DView_KeyDown;
            dView.KeyDown += DView_KeyDown1;
        }

        private void DView_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Parameters.AddParameter("@RcvDocId", NullCheck.IsNullString(dView.SelectedRows[0].Cells["ReceivingDocId"].Value));
                StartReceiving();
            }
        }

        private void StartReceiving()
        {
            dView.KeyDown -= DView_KeyDown1;
            ResetMenu();
            HideMenu();
            SetTitle("Priėmimas");
            EnableRows(3);
            SetRow3("Nuskenuokite barkodą", ContentAlignment.MiddleCenter);
            EnableInput(true, false);
            EnableRows(new string[] { "t1" });
            SetTextBoxLabel1("Barkodas");
            processMethod = new Action(ProcessBarcodeInput);
            FocusInput1();
        }

        private void ProcessBarcodeInput()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalimas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            Parameters.AddParameter("@Barcode", tBoxInput1.Text);
            processMethod = new Action(ProcessWarehouseSpotInput);
            ClearInput();
            SetRow3("Nuskenuokite vietos kodą, į kurią padėsite", ContentAlignment.MiddleCenter);
            SetTextBoxLabel1("Vieta:");
            EnableRows(5);
            SetRow5($"Siūloma vieta: {Sql.GetString($"SELECT dbo.GetFirstReceivingLocation('{GlobalUser.CurrentWarehouseId}')")}");
            DisableRow9();
            FocusInput1();
        }

        private void ProcessWarehouseSpotInput()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalima vieta", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            int Exists = NullCheck.IsNullInt(Sql.GetString($"SELECT dbo.ValidateReceivingLocation('{GlobalUser.CurrentWarehouseId}','{tBoxInput1.Text}')"));
            if (Exists <= 0)
            {
                EnableRows(9);
                SetRow9("Vieta neegzistuoja sandėlyje", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }

            if (!tBoxInput1.Text.Contains("RCV"))
            {
                EnableRows(9);
                SetRow9("Vieta neskirta priėmimui", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            Parameters.AddParameter("@Location", tBoxInput1.Text);
            DisableRow9();
            SetRow3("Nuskenuokite prekę", ContentAlignment.MiddleCenter);
            SetTextBoxLabel1("Barkodas");
            processMethod = new Action(ScanItem);
        }

        private void ScanItem()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalimas prekės barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            

        }
        #endregion

        #region DataShow setup

        private void HideDataShow()
        {
            dViewDataShow.Visible = false;
        }

        private void ShowDataShow()
        {
            dViewDataShow.Visible = true;
        }

        private void ResetDataShow()
        {
            dViewDataShow.DataSource = false;
        }

        private void ClearDataShow()
        {
            dViewDataShow = new DataGridView();
        }

        #endregion

        #region Label/Input setting

        private void FocusInput1()
        {
            tBoxInput1.Select();
            tBoxInput1.Focus();
        }

        private void FocusInput2()
        {
            tBoxInput2.Select();
            tBoxInput2.Focus();
        }

        private void SetTitle(string _title)
        {
            title.Text = _title;
        }

        private void SetRow1(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row1.Text = text;
            row1.TextAlign = alignment;
            row1.ForeColor = color ?? Color.Black;
        }

        private void SetRow2(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row2.Text = text;
            row2.TextAlign = alignment;
            row2.ForeColor = color ?? Color.Black;
        }

        private void SetRow3(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row3.Text = text;
            row3.TextAlign = alignment;
            row3.ForeColor = color ?? Color.Black;
        }

        private void SetRow4(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row4.Text = text;
            row4.TextAlign = alignment;
            row4.ForeColor = color ?? Color.Black;
        }

        private void SetRow5(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row5.Text = text;
            row5.TextAlign = alignment;
            row5.ForeColor = color ?? Color.Black;
        }

        private void SetRow6(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row6.Text = text;
            row6.TextAlign = alignment;
            row6.ForeColor = color ?? Color.Black;
        }

        private void SetRow7(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row7.Text = text;
            row7.TextAlign = alignment;
            row7.ForeColor = color ?? Color.Black;
        }

        private void SetRow8(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row8.Text = text;
            row8.TextAlign = alignment;
            row8.ForeColor = color ?? Color.Black;
        }

        private void SetRow9(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            row9.Text = text;
            row9.TextAlign = alignment;
            row9.ForeColor = color ?? Color.Black;
        }

        private void SetTextBoxLabel1(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            tBox1Desc.Text = text;
            tBox1Desc.TextAlign = alignment;
            tBox1Desc.ForeColor = color ?? Color.Black;
        }

        private void SetTextBoxLabel2(string text, ContentAlignment alignment = ContentAlignment.MiddleLeft, Color? color = null)
        {
            tBox2Desc.Text = text;
            tBox2Desc.TextAlign = alignment;
            tBox2Desc.ForeColor = color ?? Color.Black;
        }

        #endregion

        #region Menu actions

        private void HideMenu()
        {
            dView.Visible = false;
        }

        private void EmptyMenu()
        {
            dView.DataSource = null;
        }

        private void ResetMenu()
        {
            dView.Rows.Clear();
        }

        private void ShowMenu(string[] MenuOptions)
        {
            ResetMenu();
            if (dView.DataSource != null)
                EmptyMenu();
            dView.Dock = DockStyle.Fill;
            if (!dView.Columns.Contains("Menu"))
                dView.Columns.Add("Menu", "Menu");
            if (!dView.Columns.Contains("MenuId"))
                dView.Columns.Add("MenuId", "MenuId");
            dView.Rows.Add();
            dView.ColumnHeadersVisible = false;
            dView.MultiSelect = false;
            dView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < MenuOptions.Length; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dView.Rows[0].Clone();
                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = $"{i + 1}. {MenuOptions[i]}";
                dView.Rows.Add(row);
            }
            dView.Rows.RemoveAt(0);
            dView.AllowUserToAddRows = false;
            dView.RowHeadersVisible = false;
            dView.Columns[0].Visible = false;
            dView.Rows[0].Selected = true;
            dView.Select();
            ActiveControl = dView;
            dView.Visible = true;
            dView.KeyDown += DView_KeyDown;
        }

        private void DView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dView.Rows.Count > 0)
                {
                    if (activeMenu == ActiveMenuTypes.MainMenu)
                    {
                        if (dView?.SelectedRows[0] != null)
                        {
                            switch (NullCheck.IsNullInt(dView.SelectedRows[0].Cells[0].Value))
                            {
                                case 1:
                                    {
                                        InitializeReceiving();
                                        break;
                                    }
                                case 2:
                                    {
                                        break;
                                    }
                                case 3:
                                    {
                                        break;
                                    }
                                case 4:
                                    {
                                        break;
                                    }
                            }
                        }
                    }
                    else if (activeMenu == ActiveMenuTypes.Receiving)
                    {
                        if (dView?.SelectedRows[0] != null)
                        {
                            switch (NullCheck.IsNullInt(dView.SelectedRows[0].Cells[0].Value))
                            {
                                case 1:
                                    {
                                        SelectDocument();
                                        break;
                                    }
                            }
                        }
                    }
                    else if (activeMenu == ActiveMenuTypes.Shipping)
                    {
                        if (dView?.SelectedRows[0] != null)
                        {
                            //switch (NullCheck.)
                        }
                    }
                    else if (activeMenu == ActiveMenuTypes.Storing)
                    {
                        if (dView?.SelectedRows[0] != null)
                        {
                            //switch (NullCheck.)
                        }
                    }
                    else if (activeMenu == ActiveMenuTypes.Picking)
                    {
                        if (dView?.SelectedRows[0] != null)
                        {
                            //switch (NullCheck.)
                        }
                    }
                }
            }
        }
        #endregion

        #region Row enable

        private void EnableInput(bool input1 = false, bool input2 = false)
        {
            tBoxInput1.Visible = input1;
            tBoxInput2.Visible = input2;
        }

        private void EnableRows(int row)
        {
            EnableRows(new string[] { $"{row}" });
        }

        private void EnableRows(int row1, int row2)
        {
            EnableRows(new string[] { $"{row1}", $"{row2}" });
        }

        private void EnableRows(int row1, int row2, int row3)
        {
            EnableRows(new string[] { $"{row1}", $"{row2}", $"{row3}" });
        }

        private void EnableRows(int row1, int row2, int row3, int row4)
        {
            EnableRows(new string[] { $"{row1}", $"{row2}", $"{row3}", $"{row4}" });
        }

        private void EnableRows(int row1, int row2, int row3, int row4, int row5)
        {
            EnableRows(new string[] { $"{row1}", $"{row2}", $"{row3}", $"{row4}", $"{row5}" });
        }

        private void EnableRows(string[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                switch(rows[i])
                {
                    case "1":
                        {
                            row1.Visible = true;
                            break;
                        }
                    case "2":
                        {
                            row2.Visible = true;
                            break;
                        }
                    case "3":
                        {
                            row3.Visible = true;
                            break;
                        }
                    case "4":
                        {
                            row4.Visible = true;
                            break;
                        }
                    case "5":
                        {
                            row5.Visible = true;
                            break;
                        }
                    case "6":
                        {
                            row6.Visible = true;
                            break;
                        }
                    case "7":
                        {
                            row7.Visible = true;
                            break;
                        }
                    case "8":
                        {
                            row8.Visible = true;
                            break;
                        }
                    case "9":
                        {
                            row9.Visible = true;
                            break;
                        }
                    case "t1":
                        {
                            tBox1Desc.Visible = true;
                            break;
                        }
                    case "t2":
                        {
                            tBox2Desc.Visible = true;
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }
        }

        #endregion

        #region Input/Row disable

        public void HideInput()
        {
            tBoxInput1.Visible = false;
            tBoxInput2.Visible = false;
        }

        private void ClearLabels()
        {
            row1.Text = "";
            row2.Text = "";
            row3.Text = "";
            row4.Text = "";
            row5.Text = "";
            row6.Text = "";
            row7.Text = "";
            row8.Text = "";
            row9.Text = "";
        }

        private void ClearInput()
        {
            tBoxInput1.Text = "";
            tBoxInput2.Text = "";
        }

        private void DisableInfo()
        {
            row1.Visible = false;
            row2.Visible = false;
            row3.Visible = false;
            row4.Visible = false;
            row5.Visible = false;
            row6.Visible = false;
            row7.Visible = false;
            row8.Visible = false;
            row9.Visible = false;
            tBox1Desc.Visible = false;
            tBox2Desc.Visible = false;
        }

        private void DisableRow1()
        {
            row1.Visible = false;
        }

        private void DisableRow2()
        {
            row2.Visible = false;
        }

        private void DisableRow3()
        {
            row3.Visible = false;
        }

        private void DisableRow4()
        {
            row4.Visible = false;
        }

        private void DisableRow5()
        {
            row5.Visible = false;
        }

        private void DisableRow6()
        {
            row6.Visible = false;
        }

        private void DisableRow7()
        {
            row7.Visible = false;
        }

        private void DisableRow8()
        {
            row8.Visible = false;
        }

        private void DisableRow9()
        {
            row9.Visible = false;
        }

        #endregion
    }
}
