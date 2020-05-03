using Bakalauras_2020.StaticClass;
using Bakalauras_2020.Utility;
using Emulator.Emulator.Picking;
using Emulator.Emulator.Receiving;
using Emulator.Emulator.Shipping;
using Emulator.Emulator.Storing;
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
        DataTable ItemList;
        decimal TotalVolume = 0;

        public EmulatorScreen()
        {
            InitializeComponent();
            DisableInfo();
            HideInput();
            PrepareScreen();
        }

        #region Entry point

        private void PrepareScreen()
        {
            Cache.InitializeParams();
            activeMenu = ActiveMenuTypes.Login;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyDown += EmulatorScreen_KeyDown;
            this.tBoxInput2.PasswordChar = '*';
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
                tBoxInput2.UseSystemPasswordChar = true;
                processMethod = new Action(ValidateLogin);
            }
            else
            {
                BackToMainMenu();
            }
        }

        #endregion

        #region Method processing 

        private void EmulatorScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processMethod();
            }
            if (e.KeyCode == Keys.Escape)
            {
                if(GlobalUser.UserId == null)
                {
                    PrepareScreen();
                }
                else
                {
                    BackToMainMenu();
                }
            }
        }

        private void TBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processMethod();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (GlobalUser.UserId == null)
                {
                    PrepareScreen();
                }
                else
                {
                    BackToMainMenu();
                }
            }

        }

        private void DViewDataShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                processMethod();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (GlobalUser.UserId == null)
                {
                    PrepareScreen();
                }
                else
                {
                    BackToMainMenu();
                }
            }
        }

        #endregion

        #region Login processing and warehouse assignment

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
            this.tBoxInput2.UseSystemPasswordChar = true;
            this.tBoxInput2.PasswordChar = '\0';
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
            dViewDataShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dViewDataShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dViewDataShow.Visible = true;
            processMethod = new Action(AssignWarehouse);
        }

        private void AssignWarehouse()
        {
            GlobalUser.SetWarehouseId(NullCheck.IsNullInt(dViewDataShow.SelectedRows[0].Cells["WarehouseId"].Value));
            activeMenu = ActiveMenuTypes.MainMenu;
            HideDataShow();
            ShowMenu(new string[] { "Priėmimas", "Padėjimas", "Surinkimas", "Išvežimas" });
        }

        #endregion

        #region Storing

        private void InitializeStoring()
        {
            activeMenu = ActiveMenuTypes.Storing;
            ResetMenu();
            ShowMenu(new string[] { "Padėti paletes" });
        }

        private void InputPalletBarcode()
        {
            EmptyMenu();
            HideMenu();
            DisableInfo();
            EnableInput(true);
            EnableRows(5);
            EnableRows(new string[] { "t1" });
            SetTitle("Perkėlimas");
            SetRow5("Įveskite norimos paletės barkodą", ContentAlignment.MiddleCenter);
            SetTextBoxLabel1("Barkodas:");
            processMethod = new Action(ProcessMovePalletBarcode);
            FocusInput1();
        }

        private void ProcessMovePalletBarcode()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalimas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            if(StoringActions.ValidatePallet(tBoxInput1.Text) <= 0)
            {
                EnableRows(9);
                SetRow9("Paletė neegzistuoja sandėlyje", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            Cache.AddParameter("@Barcode", tBoxInput1.Text);
            CreateSelection();
        }

        private void CreateSelection()
        {
            DisableRows(9);
            EnableInput();
            DisableInfo();
            SetTitle("Pasirinkite vietą");
            DataTable dt = StoringActions.GetStoringZones();
            dViewDataShow.DataSource = dt;
            dViewDataShow.Columns[1].HeaderText = "Zonos kodas";
            dViewDataShow.Columns[2].HeaderText = "Zonos pavadinimas";
            dViewDataShow.Columns[0].Visible = false;
            dViewDataShow.Select();
            ShowDataShow();
            processMethod = new Action(ProcessSelection);
        }

        private void ProcessSelection()
        {
            ResetMenu();
            HideMenu();
            try
            {
                Cache.AddParameter("@Location", dViewDataShow.SelectedRows[0].Cells[0].Value);
            }
            catch
            {
                CreateSelection();
                    return;
            }
            HideDataShow();
            SetTitle("Perkėlimas");
            EnableRows(5);
            EnableInput(true);
            EnableRows(9);
            SetRow9("T / N", ContentAlignment.MiddleCenter, Color.Red);
            SetRow5($"Ar tikrai norite perkelti į zoną: {dViewDataShow.SelectedRows[0].Cells[2].Value} ({dViewDataShow.SelectedRows[0].Cells[1].Value})?", ContentAlignment.MiddleCenter, Color.Red);
            ClearInput();
            FocusInput1();
            processMethod = new Action(ProcessYesNoStoringSelection);
        }

        private void ProcessYesNoStoringSelection()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text) && (tBoxInput1.Text.ToUpper().Equals("T".ToUpper()) || tBoxInput1.Text.ToUpper().Equals("N".ToUpper())))
            {
                ClearInput();
                return;
            }

            if (tBoxInput1.Text.ToUpper() == "N")
            {
                CreateSelection();
            }
            else
            {
                FinalizeStoring();
            }
        }

        private void FinalizeStoring()
        {
            ClearInput();
            ClearLabels();
            DisableInfo();
            StoringActions.MovePallet();
            EnableRows(5);
            SetRow5("Paletės perkėlimas baigtas", ContentAlignment.MiddleCenter, Color.Red);
            EnableInput();
            this.Select();
        }

        #endregion

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
            DisableInfo();
            DataTable dt = ReceivingActions.GetReceivingDocuments();
            SetTitle("Pasirinkite dokumentą");
            dViewDataShow.DataSource = dt;
            dViewDataShow.Columns[1].HeaderText = "Dokumento Nr";
            dViewDataShow.Columns[2].HeaderText = "Tiekėjas";
            dViewDataShow.Columns[3].HeaderText = "Sukurtas";
            dViewDataShow.Columns[0].Visible = false;
            dViewDataShow.Select();
            ShowDataShow();
            processMethod = new Action(StartReceiving);
        }

        private void StartReceiving()
        {
            ResetMenu();
            HideMenu();
            try
            {
                Cache.AddParameter("@RcvDocId", dViewDataShow.SelectedRows[0].Cells[0].Value);
            }
            catch
            {
                SelectDocument();
                return;
            }
            HideDataShow();
            SetTitle("Priėmimas");
            EnableRows(3);
            SetRow3("Nuskenuokite barkodą", ContentAlignment.MiddleCenter);
            EnableInput(input1: true);
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
            Cache.AddParameter("@Barcode", tBoxInput1.Text);
            EmptyMenu();
            DataTable dt = PickingActions.GetPalletTypes();
            SetTitle("Pasirinkite paletės tipą");
            dViewDataShow.DataSource = dt;
            dViewDataShow.Columns[0].HeaderText = "Paletės tipo nr";
            dViewDataShow.Columns[1].HeaderText = "Ilgis";
            dViewDataShow.Columns[2].HeaderText = "Plotis";
            dViewDataShow.Columns[3].HeaderText = "Aukštis";
            dViewDataShow.Columns[4].Visible = false;
            dViewDataShow.Focus();
            dViewDataShow.Select();
            ShowDataShow();
            processMethod = new Action(ProcessPalletTypeForReceive);
        }

        private void ProcessPalletTypeForReceive()
        {
            try
            {
                Cache.AddParameter("@PalletType", dViewDataShow.SelectedRows[0].Cells[4].Value);
            }
            catch
            {
                ProcessBarcodeInput();
            }
            ResetMenu();
            HideMenu();
            DisableInfo();
            HideDataShow();
            ProcessLocationInput();
        }

        private void ProcessLocationInput()
        { 
            processMethod = new Action(ProcessWarehouseSpotInput);
            SetTitle("Priėmimas");
            ClearInput();
            EnableBoxDescriptionRows(row1: true);
            SetRow3("Nuskenuokite vietos kodą, į kurią padėsite", ContentAlignment.MiddleCenter);
            SetTextBoxLabel1("Vieta:");
            EnableRows(5);
            SetRow5($"Siūloma vieta: {ReceivingActions.GetSuggestedReceivingZone()}");
            DisableRows(9);
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
            int Exists = ReceivingActions.ZoneExists(tBoxInput1.Text);
            if (Exists <= 0)
            {
                EnableRows(9);
                SetRow9("Vieta neegzistuoja sandėlyje", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            Cache.AddParameter("@Location", tBoxInput1.Text);
            ClearInput();
            DisableRows(9,5);
            ItemList = ReceivingActions.GetReceivingItemList();
            TotalVolume = ReceivingActions.CalculateTotalVolume(ItemList);
            if (ItemList != null && ItemList.Rows.Count > 0)
            {
                CheckItemScan();
            }
            else
            {
                DisableInfo();
                EnableRows(5);
                SetRow5("Nėra užsakytu prekių", ContentAlignment.MiddleCenter, Color.Red);
                processMethod = new Action(BackToMainMenu);
            }
        }

        private void CheckItemScan()
        {
            if (ItemList.Rows.Count > 0)
            {
                SetScanItem();
                processMethod = new Action(ProcessItemScan);
            }
            else
                FinalizeReceiving();

        }

        private void SetScanItem()
        {
            ClearInput();
            ClearLabels();
            DisableInfo();
            EnableRows(new string[] { "5", "8" });
            SetRow5("Įrašykite gautą kiekį", ContentAlignment.MiddleCenter);
            SetRow8($"Prekė: [{NullCheck.IsNullString(ItemList.Rows[0]["Name"])}]     Barkodas: [{NullCheck.IsNullString(ItemList.Rows[0]["Barcode"])}]", ContentAlignment.MiddleCenter, Color.Chocolate);
            EnableRows(new string[] { "t1" });
            SetTextBoxLabel1("Kiekis:");
            Cache.AddParameter("@ScanBarcode", NullCheck.IsNullString(ItemList.Rows[0]["Barcode"]));
            EnableInput(input1:true);
            FocusInput1();
        }

        private void ProcessItemScan()
        {
            decimal ScannedAmount = NullCheck.IsNullDecimal(tBoxInput1.Text);
            if (ScannedAmount == Decimal.Zero)
            {
                EnableRows(9);
                SetRow9("Netinkama įvestis", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            DataRow row = ItemList.AsEnumerable().Where(x => x.Field<string>("Barcode") == Cache.ReturnValueByKey("@ScanBarcode")).FirstOrDefault();
            decimal RequestedAmount = NullCheck.IsNullDecimal(row["Quantity"]);
            if (ScannedAmount > RequestedAmount)
            {
                EnableRows(9);
                SetRow9("Nuskenuotas didesnis kiekis nei užsakyta", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            DisableRows(9);
            decimal LeftQty = NullCheck.IsNullDecimal(row["Quantity"]) - ScannedAmount;
            if (LeftQty == Decimal.Zero)
            {
                ItemList.Rows.Remove(row);
            }
            else
            {
                row["Quantity"] = LeftQty;
            }
            ClearInput();
            if (ItemList.Rows.Count > 0)
            {
                if (LeftQty == Decimal.Zero)
                {
                    SetScanItem();
                }
                processMethod = new Action(ProcessItemScan);
            }
            else
            {
                CheckItemScan();
            }
        }

        private void FinalizeReceiving()
        {
            ClearInput();
            ClearLabels();
            DisableInfo();
            EnableRows(4);
            ReceivingActions.SavePalletToZone();
            ReceivingActions.SaveItemsToZoneAndPallet(Sql.GetTable("GetItemIdByRcvDocIdForStore", new object[] { "@RcvDocId", Cache.ReturnValueByKey("@RcvDocId") }));
            ReceivingActions.DeductSpotVolume(TotalVolume, Cache.ReturnValueByKey("@Location"));
            ReceivingActions.FinishReceivingDoc();
            SetRow4("Prekių priėmimas baigtas", ContentAlignment.MiddleCenter, Color.Red);
            EnableInput();
            this.Select();
        }
        #endregion

        #region Picking

        private void InitializePicking()
        {
            activeMenu = ActiveMenuTypes.Picking;
            ResetMenu();
            ShowMenu(new string[] { "Surinkti prekes" });
        }

        private void SelectOutOrder()
        {
            EmptyMenu();
            DisableInfo();
            DataTable dt = PickingActions.GetOutOrderDocuments();
            SetTitle("Pasirinkite dokumentą");
            dViewDataShow.DataSource = dt;
            dViewDataShow.Columns[1].HeaderText = "Dokumento Nr";
            dViewDataShow.Columns[2].HeaderText = "Tiekėjas";
            dViewDataShow.Columns[3].HeaderText = "Sukurtas";
            dViewDataShow.Columns[0].Visible = false;
            dViewDataShow.Select();
            ShowDataShow();
            processMethod = new Action(StartPicking);
        }

        private void StartPicking()
        {
            ResetMenu();
            HideMenu();
            DisableInfo();
            try
            { 
                Cache.AddParameter("@OutOrderId", dViewDataShow.SelectedRows[0].Cells[0].Value);
            }
            catch
            {
                SelectOutOrder();
                return;
            }
            HideDataShow();
            SetTitle("Surinkimas");
            EnableRows(3);
            SetRow3("Nuskenuokite paletės barkodą", ContentAlignment.MiddleCenter);
            EnableInput(input1: true);
            EnableRows(new string[] { "t1" });
            SetTextBoxLabel1("Barkodas");
            processMethod = new Action(ProcessPalletBarcode);
            FocusInput1();
        }

        private void ProcessPalletBarcode()
        {
            //@TODO: Add pallet type select procedure + implement save pattern in receiving
            if (string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalimas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            Cache.AddParameter("@Barcode", tBoxInput1.Text);
            EmptyMenu();
            DataTable dt = PickingActions.GetPalletTypes();
            SetTitle("Pasirinkite paletės tipą");
            dViewDataShow.DataSource = dt;
            dViewDataShow.Columns[0].HeaderText = "Paletės tipo nr";
            dViewDataShow.Columns[1].HeaderText = "Ilgis";
            dViewDataShow.Columns[2].HeaderText = "Plotis";
            dViewDataShow.Columns[3].HeaderText = "Aukštis";
            dViewDataShow.Columns[4].Visible = false;
            dViewDataShow.Select();
            ShowDataShow();
            processMethod = new Action(ProcessPalletTypeForPick);
        }

        private void ProcessPalletTypeForPick()
        {
            try
            {
                Cache.AddParameter("@PalletType", dViewDataShow.SelectedRows[0].Cells[4].Value);
            }
            catch
            {
                ProcessPalletBarcode();
                return;
            }
            ResetMenu();
            HideMenu();
            DisableInfo();
            HideDataShow();
            ProcessPicking();
        }

        private void ProcessPicking()
        { 
            DisableInfo();
            ClearLabels();
            EnableRows(3);
            ItemList = PickingActions.GetWorkOrdersByOutOrder();
            TotalVolume = PickingActions.CalculateTotalVolume(ItemList);
            if (ItemList != null && ItemList.Rows.Count > 0)
            {
                ProcessWO();
            }
            else
            {
                DisableInfo();
                EnableRows(5);
                SetRow5("Nėra priskirtų surinkimo užsakymų", ContentAlignment.MiddleCenter, Color.Red);
                processMethod = new Action(BackToMainMenu);
            }
        }

        private void ProcessWO()
        {
            if (ItemList.Rows.Count > 0)
            {
                SetScanWO();
                processMethod = new Action(ProcessWOScan);
            }
            else
            {
                FinalizePicking();
            }
        }

        private void SetScanWO()
        {   
            ClearInput();
            EnableInput(true);
            ClearLabels();
            DisableInfo();
            EnableRows(new string[] { "4", "5", "8" });
            SetRow4("Nuskenuokite prekę", ContentAlignment.MiddleCenter);
            SetRow5($"Prekė: [{NullCheck.IsNullString(ItemList.Rows[0]["Name"])}]     Kodas: [{NullCheck.IsNullString(ItemList.Rows[0]["Code"])}]", ContentAlignment.MiddleCenter, Color.Chocolate);
            EnableRows(new string[] { "t1" });
            SetTextBoxLabel1("Barkodas:");
            EnableInput(input1: true);
            FocusInput1();
        }

        private void ProcessWOScan()
        {
            if(string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalimas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            else if (NullCheck.IsNullString(ItemList.Rows[0]["Barcode"]) != tBoxInput1.Text)
            {
                EnableRows(9);
                SetRow9("Netinkamas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            DisableRows(9);
            ProcessPickAmount();
        }

        private void ProcessPickAmount()
        {
            EnableBoxDescriptionRows(true, true);
            SetTextBoxLabel2("Kiekis:");
            EnableInput(true, true);
            ReadOnlyInput(input1: true);
            processMethod = new Action(ProcessPickQuantity);
            FocusInput2();
        }

        private void ProcessPickQuantity()
        {
            decimal ScannedAmount = NullCheck.IsNullDecimal(tBoxInput2.Text);
            if (ScannedAmount == Decimal.Zero)
            {
                EnableRows(9);
                SetRow9("Netinkama įvestis", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            DataRow row = ItemList.AsEnumerable().Where(x => x.Field<string>("Barcode") == tBoxInput1.Text).FirstOrDefault();
            decimal RequestedAmount = NullCheck.IsNullDecimal(row["Quantity"]);
            if (ScannedAmount > RequestedAmount)
            {
                EnableRows(9);
                SetRow9("Surinktas didesnis kiekis nei reikia surinkti", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            PickingActions.SetWOInProcess(NullCheck.IsNullInt(row["WOrderId"]));
            DisableRows(9);
            decimal LeftQty = RequestedAmount - ScannedAmount;
            if (LeftQty == decimal.Zero)
            {
                PickingActions.CloseWO(NullCheck.IsNullInt(row["WOrderId"]));
                ItemList.Rows.Remove(row);
            }
            else
            {
                row["Quantity"] = LeftQty;
            }
            ClearInput();
            if (ItemList.Rows.Count > 0)
            {
                if (LeftQty == Decimal.Zero)
                {
                    SetScanWO();
                }
                processMethod = new Action(ProcessWOScan);
            }
            else
            {
                ClearInput();
                EnableInput();
                ProcessWO();
            }
        }

        private void FinalizePicking()
        {
            ScanPutLocation();
        }

        private void ScanPutLocation()
        {
            DisableInfo();
            ClearInput();
            EnableInput(input1: true);
            EnableRows(3);
            SetRow3("Nuskenuokite vietą kur norite padėti paletę", ContentAlignment.MiddleCenter);
            EnableRows(5);
            SetRow5($"Siūloma vieta: {Sql.GetString($"SELECT dbo.GetSuggestedStaging('{TotalVolume + NullCheck.IsNullDecimal(Cache.ReturnValueByKey("@PalletType"))}')")}");
            EnableBoxDescriptionRows(row1: true);
            SetTextBoxLabel1("Vieta:");
            FocusInput1();
            processMethod = new Action(PutCU);
        }

        private void PutCU()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalimas vietos kodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            else if (PickingActions.ZoneExists(tBoxInput1.Text) <= 0)
            {
                EnableRows(9);
                SetRow9("Netinkamas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            Cache.AddParameter("@StageLocation", tBoxInput1.Text);
            PickingActions.PutAwayCU();
            PickingActions.PutAwayItems(Sql.GetTable("GetItemIdByOutOrderIdForStore", new object[] { "@OutOrderId", Cache.ReturnValueByKey("@OutOrderId") }));
            PickingActions.DeductSpotVolume(TotalVolume, tBoxInput1.Text);
            PickingActions.FinishOutOrderStatus();
            DisableInfo();
            EnableRows(5);
            SetRow5("Baigtas prekių surinkimas", ContentAlignment.MiddleCenter);
            ClearInput();
            EnableInput();
            this.Select();
        }

        #endregion

        #region Shipping

        private void InitializeLoading()
        {
            activeMenu = ActiveMenuTypes.Shipping;
            ResetMenu();
            ShowMenu(new string[] { "Pakrauti paletes" });
        }

        private void StartLoad()
        {
            EmptyMenu();
            DisableInfo();
            DataTable dt = ShippingActions.GetShipping();
            SetTitle("Pasirinkite siuntą");
            dViewDataShow.DataSource = dt;
            dViewDataShow.Columns[0].HeaderText = "Siuntos Id";
            dViewDataShow.Columns[1].HeaderText = "Siuntos numeris";
            dViewDataShow.Columns[2].HeaderText = "Sukurtas";
            dViewDataShow.Select();
            ShowDataShow();
            processMethod = new Action(StartLoading);
        }

        private void StartLoading()
        {
            ResetMenu();
            HideMenu();
            try
            { 
            Cache.AddParameter("@ShippingId", dViewDataShow.SelectedRows[0].Cells[0].Value);
            Cache.AddParameter("@ShippingNo", dViewDataShow.SelectedRows[0].Cells[1].Value);
            }
            catch
            {
                StartLoad();
                return;
            }
            HideDataShow();
            SetTitle("Pakrovimas");
            ItemList = ShippingActions.GetRelatedCU();
            EnableRows(3, 6);
            SetRow3($"Siunta: {Cache.ReturnValueByKey("@ShippingNo")}", ContentAlignment.MiddleLeft);
            SetRow6($"Nuskenuokite paletės barkodą", ContentAlignment.MiddleCenter);
            EnableInput(true);
            EnableBoxDescriptionRows(row1: true);
            SetTextBoxLabel1("Barkodas:");
            FocusInput1();
            if (ItemList != null && ItemList.Rows.Count > 0)
            {
                ProcessLoading();
            }
            else
            {
                DisableInfo();
                EnableRows(5);
                SetRow5("Nėra nepakrautų palečių", ContentAlignment.MiddleCenter, Color.Red);
                HideInput();
                this.Select();
                processMethod = new Action(StartLoad);
            }
        }

        private void ProcessLoading()
        {
            if (ItemList.Rows.Count > 0)
            {
                ProcessCULoading();
            }
            else
            {
                FinalizeLoading();
            }
        }

        private void ProcessCULoading()
        {
            EnableRows(4);
            SetRow4($"Barkodas: {ItemList.Rows[0]["Barcode"]}");
            processMethod = new Action(ProcessCUScan);
        }

        private void ProcessCUScan()
        {
            if (string.IsNullOrEmpty(tBoxInput1.Text))
            {
                EnableRows(9);
                SetRow9("Negalimas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            else if (tBoxInput1.Text != NullCheck.IsNullString(ItemList.Rows[0]["Barcode"]))
            {
                EnableRows(9);
                SetRow9("Blogas barkodas", ContentAlignment.MiddleCenter, Color.Red);
                return;
            }
            DisableRows(9);
            LoadUnloadBarcode();
        }

        private void LoadUnloadBarcode()
        {
            string ScannedBarcode = NullCheck.IsNullString(tBoxInput1.Text);
            DataRow row = ItemList.AsEnumerable().Where(x => x.Field<string>("Barcode") == ScannedBarcode).FirstOrDefault();
            ShippingActions.LoadCU(NullCheck.IsNullInt(row["StoredPalletId"]));
            ItemList.Rows.Remove(row);
            ClearInput();
            if (ItemList.Rows.Count > 0)
            {
                ProcessCULoading();
            }
            else
            {
                ProcessLoading();
            }
        }

        private void FinalizeLoading()
        {
            ClearInput();
            ClearLabels();
            DisableInfo();
            EnableRows(4);
            SetRow4("Palečių krovimas baigtas", ContentAlignment.MiddleCenter, Color.Red);
            EnableInput();
            processMethod = new Action(StartLoad);
            this.Select();
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
            this.Controls.Add(dViewDataShow);
        }

        #endregion

        #region Label/Input setting

        private void FocusInput1()
        {
            tBoxInput1.ReadOnly = false;
            tBoxInput1.Select();
            tBoxInput1.Focus();
        }

        private void FocusInput2()
        {
            tBoxInput2.ReadOnly = false;
            tBoxInput2.Select();
            tBoxInput2.Focus();
        }

        private void SetInput1(string text)
        {
            tBoxInput1.ReadOnly = true;
            tBoxInput1.Text = text;
        }

        private void SetInput2(string text)
        {
            tBoxInput2.ReadOnly = true;
            tBoxInput2.Text = text;
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

        private void BackToMainMenu()
        {
            SetTitle("Sandėlio valdymo sistema");
            activeMenu = ActiveMenuTypes.MainMenu;
            HideDataShow();
            ShowMenu(new string[] { "Priėmimas", "Padėjimas", "Surinkimas", "Išvežimas" });
        }

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

        #endregion

        #region Menu navigation

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
                                        InitializeStoring();
                                        break;
                                    }
                                case 3:
                                    {
                                        InitializePicking();
                                        break;
                                    }
                                case 4:
                                    {
                                        InitializeLoading();
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
                            switch (NullCheck.IsNullInt(dView.SelectedRows[0].Cells[0].Value))
                            {
                                case 1:
                                    {
                                        StartLoad();
                                        break;
                                    }
                            }
                        }
                    }
                    else if (activeMenu == ActiveMenuTypes.Storing)
                    {
                        if (dView?.SelectedRows[0] != null)
                        {
                            switch (NullCheck.IsNullInt(dView.SelectedRows[0].Cells[0].Value))
                            {
                                case 1:
                                    {
                                        InputPalletBarcode();
                                        break;
                                    }
                            }
                        }
                    }
                    else if (activeMenu == ActiveMenuTypes.Picking)
                    {
                        if (dView?.SelectedRows[0] != null)
                        {
                            switch (NullCheck.IsNullInt(dView.SelectedRows[0].Cells[0].Value))
                            {
                                case 1:
                                    {
                                        SelectOutOrder();
                                        break;
                                    }
                            }
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

        private void EnableBoxDescriptionRows(bool row1 = false, bool row2 = false)
        {
            tBox1Desc.Visible = row1;
            tBox2Desc.Visible = row2;
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

        public void ReadOnlyInput(bool input1 = false, bool input2 = false)
        {
            tBoxInput1.ReadOnly = input1;
            tBoxInput2.ReadOnly = input2;
        }

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

        private void DisableRows(int row)
        {
            DisableRows(new string[] { $"{row}" });
        }

        private void DisableRows(int row1, int row2)
        {
            DisableRows(new string[] { $"{row1}", $"{row2}" });
        }

        private void DisableRows(int row1, int row2, int row3)
        {
            DisableRows(new string[] { $"{row1}", $"{row2}", $"{row3}" });
        }

        private void DisableRows(int row1, int row2, int row3, int row4)
        {
            DisableRows(new string[] { $"{row1}", $"{row2}", $"{row3}", $"{row4}" });
        }

        private void DisableRows(int row1, int row2, int row3, int row4, int row5)
        {
            DisableRows(new string[] { $"{row1}", $"{row2}", $"{row3}", $"{row4}", $"{row5}" });
        }

        private void DisableRows(string[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                switch (rows[i])
                {
                    case "1":
                        {
                            row1.Visible = false;
                            break;
                        }
                    case "2":
                        {
                            row2.Visible = false;
                            break;
                        }
                    case "3":
                        {
                            row3.Visible = false;
                            break;
                        }
                    case "4":
                        {
                            row4.Visible = false;
                            break;
                        }
                    case "5":
                        {
                            row5.Visible = false;
                            break;
                        }
                    case "6":
                        {
                            row6.Visible = false;
                            break;
                        }
                    case "7":
                        {
                            row7.Visible = false;
                            break;
                        }
                    case "8":
                        {
                            row8.Visible = false;
                            break;
                        }
                    case "9":
                        {
                            row9.Visible = false;
                            break;
                        }
                    case "t1":
                        {
                            tBox1Desc.Visible = false;
                            break;
                        }
                    case "t2":
                        {
                            tBox2Desc.Visible = false;
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
    }
}
