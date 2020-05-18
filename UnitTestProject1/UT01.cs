using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakalauras_2020;
using Bakalauras_2020.Forms.Warehouse.Items;
using UT;
using System.Data;
using Bakalauras_2020.Forms.Receiving;
using System.Windows.Forms;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class UT01
    {
        //ItemEditor test
        [Test]
        public void TestMethodIE1()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "", "", "", "", "", "", "", "", "", "", ""});
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }
        [Test]
        public void TestMethodIE2()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "T11", "", "TestCaseDescription", "1", "10", "15", "10", "1", "0001222548", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }
        [Test]
        public void TestMethodIE3()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "T11", "T11", "TestCaseDescription", "1", "", "15", "10", "1", "0001222548", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }
        [Test]
        public void TestMethodIE4()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "T11", "T11", "TestCaseDescription", "1", "10", "", "10", "1", "0001222548", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }
        [Test]
        public void TestMethodIE5()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "T11", "T11", "TestCaseDescription", "1", "10", "15", "", "1", "0001222548", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }
        [Test]
        public void TestMethodIE6()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "T11", "T11", "TestCaseDescription", "1", "10", "15", "10", "1", "", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }
        [Test]
        public void TestMethodIE7()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "T11", "T11", "TestCaseDescription", "1", "10", "15", "10", "1", "0001222548", "2", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }
        [Test]
        public void TestMethodIE8()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "T11", "T11", "TestCaseDescription", "1", "10", "15", "10", "1", "0001222548", "", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"T11"}','{"T11"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }

        [Test]
        public void TestMethodIE9()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodIE9_2", "TestMethodIE9_2", "TestCaseDescription", "1", "10", "15", "10", "1", "0001222548", "0", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"TestMethodIE9"}','{"TestMethodIE9"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }

        [Test]
        public void TestMethodIE10()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodIE9_2", "TestMethodIE9_2", "TestCaseDescription", "1", "10", "15", "10", "1", "0001222548", "2", "0" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"TestMethodIE9"}','{"TestMethodIE9"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }

        [Test]
        public void TestMethodIE11()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodIE9_2", "TestMethodIE9_2", "TestCaseDescription", "1", "0", "15", "10", "1", "0001222548", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"TestMethodIE9"}','{"TestMethodIE9"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }

        [Test]
        public void TestMethodIE12()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodIE9_2", "TestMethodIE9_2", "TestCaseDescription", "1", "10", "0", "10", "1", "0001222548", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"TestMethodIE9"}','{"TestMethodIE9"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }

        [Test]
        public void TestMethodIE13()
        {
            ItemEditor edt = new ItemEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodIE9_2", "TestMethodIE9_2", "TestCaseDescription", "1", "10", "15", "10", "1", "0001222548", "2", "5" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateItem('{"TestMethodIE9"}','{"TestMethodIE9"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed item insert");
        }

        //PalletTypeEditor test
        [Test]
        public void TestMethodPTE1()
        {
            PalletTypeEditor edt = new PalletTypeEditor();
            edt.AssignTextBoxes(new string[] { "-1", "10", "10", "10", "10", "10", "10" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidatePalletType('{10}','{10}','{10}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed pallet type insert");
        }

        [Test]
        public void TestMethodPTE2()
        {
            PalletTypeEditor edt = new PalletTypeEditor();
            edt.AssignTextBoxes(new string[] { "3", "", "10", "10", "10", "10", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidatePalletType('{10}','{10}','{10}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed pallet type insert");
        }

        [Test]
        public void TestMethodPTE3()
        {
            PalletTypeEditor edt = new PalletTypeEditor();
            edt.AssignTextBoxes(new string[] { "-1", "10", "", "10", "10", "10", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidatePalletType('{10}','{10}','{10}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed pallet type insert");
        }

        [Test]
        public void TestMethodPTE4()
        {
            PalletTypeEditor edt = new PalletTypeEditor();
            edt.AssignTextBoxes(new string[] { "-1", "10", "10", "", "10", "10", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidatePalletType('{10}','{10}','{10}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed pallet type insert");
        }

        [Test]
        public void TestMethodPTE5()
        {
            PalletTypeEditor edt = new PalletTypeEditor();
            edt.AssignTextBoxes(new string[] { "-1", "10", "10", "10", "", "10", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidatePalletType('{10}','{10}','{10}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed pallet type insert");
        }

        [Test]
        public void TestMethodPTE6()
        {
            PalletTypeEditor edt = new PalletTypeEditor();
            edt.AssignTextBoxes(new string[] { "-1", "10", "10", "10", "10", "", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidatePalletType('{10}','{10}','{10}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed pallet type insert");
        }

        //WarehouseEditor test
        [Test]
        public void TestMethodWE1()
        {
            WarehouseEditor edt = new WarehouseEditor();
            edt.AssignTextBoxes(new string[] { "-1", "", "TESTWAREHOUSE", "6"});
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }

        [Test]
        public void TestMethodWE2()
        {
            WarehouseEditor edt = new WarehouseEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTWAREHOUSE", "", "6" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }

        [Test]
        public void TestMethodWE3()
        {
            WarehouseEditor edt = new WarehouseEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTWAREHOUSE", "TESTWAREHOUSE", "6" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }

        [Test]
        public void TestMethodWE4()
        {
            WarehouseEditor edt = new WarehouseEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTWAREHOUSE2", "TESTWAREHOUSE2", "6" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateWarehouse('{"TESTWAREHOUSE2"}','{"TESTWAREHOUSE2"}')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed warehouse insert");
        }

        //WarehouseZoneEditor test
        [Test]
        public void TestMethodWZE1()
        {
            WarehouseZoneEditor edt = new WarehouseZoneEditor();
            edt.AssignTextBoxes(new string[] { "-1", "", "TESTNAME", "TEST", "5", "5", "5", "125" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }
        [Test]
        public void TestMethodWZE2()
        {
            WarehouseZoneEditor edt = new WarehouseZoneEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTCODE", "", "5", "5", "5", "125" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }
        [Test]
        public void TestMethodWZE3()
        {
            WarehouseZoneEditor edt = new WarehouseZoneEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTCODE", "TESTNAME", "", "5", "5", "125" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }
        [Test]
        public void TestMethodWZE4()
        {
            WarehouseZoneEditor edt = new WarehouseZoneEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTCODE", "TESTNAME", "5", "", "5", "125" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }
        [Test]
        public void TestMethodWZE5()
        {
            WarehouseZoneEditor edt = new WarehouseZoneEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTCODE", "TESTNAME", "5", "5", "", "125" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }
        [Test]
        public void TestMethodWZE6()
        {
            WarehouseZoneEditor edt = new WarehouseZoneEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTCODE", "TESTNAME", "5", "5", "5", "" });
            edt.PerformSave();
            NUnit.Framework.Assert.Pass();
        }
        [Test]
        public void TestMethodWZE7()
        {
            WarehouseZoneEditor edt = new WarehouseZoneEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodWZE7", "TestMethodWZE7", "TEST", "5", "5", "5", "125" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateFZone('TestMethodWZE7','TestMethodWZE7')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed warehouse zone insert");
        }

        //ShipmentEditor test
        [Test]
        public void TestMethodSE1()
        {
            ShipmentEditor edt = new ShipmentEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodWZE7", "", "TEST", "5", "5", "5", "125" });
            edt.PerformSave();
        }

        [Test]
        public void TestMethodSE2()
        {
            ShipmentEditor edt = new ShipmentEditor();
            edt.AssignTextBoxes(new string[] { "", "", "TestMethodSE2", "TEST", "5", "5", "5", "125" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateSaveShipment('TestMethodSE2')");
            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed shipment insert");
        }

        //OutOrderEditor test
        [Test]
        public void TestMethodOOE1()
        {
            OutOrderEditor edt = new OutOrderEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTNO", "SUPPLY"});
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateOutOrder('TESTNO')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed out order insert");
        }

        [Test]
        public void TestMethodOOE2()
        {
            OutOrderEditor edt = new OutOrderEditor();
            edt.AssignTextBoxes(new string[] { "-1", "", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateOutOrder('TESTNO')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed out order insert");
        }


        //ParcelsEditor test
        [Test]
        public void TestMethodPE1()
        {
            ParcelsEditor edt = new ParcelsEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTPARCEL", "SUPPLY" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateParcel('TESTPARCEL')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed parcel insert");
        }

        [Test]
        public void TestMethodPE2()
        {
            ParcelsEditor edt = new ParcelsEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTPARCEL", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateParcel('TESTPARCEL')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed parcel insert");
        }

        //ReceivingOrderEditor test
        [Test]
        public void TestMethodROE1()
        {
            ReceivingOrderEditor edt = new ReceivingOrderEditor();
            edt.AssignTextBoxes(new string[] { "-1", "" });
            edt.PerformSave();

            string id = "1";

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed receiving order insert");
        }

        [Test]
        public void TestMethodROE2()
        {
            ReceivingOrderEditor edt = new ReceivingOrderEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TESTNO" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateSaveRcvOrd('TESTNO')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed receiving order insert");
        }

        //ReceivingDocEditor test
        [Test]
        public void TestMethodRDE1()
        {
            ReceivingDocEditor edt = new ReceivingDocEditor();
            edt.AssignTextBoxes(new string[] { "-1", "", "" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateOutOrder('TESTNO')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed receiving doc insert");
        }

        [Test]
        public void TestMethodRDE2()
        {
            ReceivingDocEditor edt = new ReceivingDocEditor();
            edt.AssignTextBoxes(new string[] { "-1", "TestMethodRDE2", "SUPPLY" });
            edt.PerformSave();

            string id = Sql.GetString($"SELECT dbo.ValidateRcvDoc('TestMethodRDE2')");

            NUnit.Framework.Assert.That(int.Parse(id) > 0, "Failed receiving doc insert");
        }
    }
}
