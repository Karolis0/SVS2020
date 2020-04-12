namespace Bakalauras_2020.Forms.Warehouse.Items
{
    partial class ItemEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lItemCode = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lDescription = new System.Windows.Forms.Label();
            this.lNetWeight = new System.Windows.Forms.Label();
            this.lBrutoWeight = new System.Windows.Forms.Label();
            this.lItemVolume = new System.Windows.Forms.Label();
            this.lMU = new System.Windows.Forms.Label();
            this.lCreateDate = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.lUpdateDate = new System.Windows.Forms.Label();
            this.lWarehouseId = new System.Windows.Forms.Label();
            this.tItemCode = new System.Windows.Forms.TextBox();
            this.tItemName = new System.Windows.Forms.TextBox();
            this.tNetWeight = new System.Windows.Forms.TextBox();
            this.tItemDescription = new System.Windows.Forms.TextBox();
            this.tBrutoWeight = new System.Windows.Forms.TextBox();
            this.tCreateDate = new System.Windows.Forms.TextBox();
            this.tVolume = new System.Windows.Forms.TextBox();
            this.tUpdated = new System.Windows.Forms.TextBox();
            this.cItemType = new System.Windows.Forms.ComboBox();
            this.cMU = new System.Windows.Forms.ComboBox();
            this.tWarehouseId = new System.Windows.Forms.TextBox();
            this.tWidth = new System.Windows.Forms.TextBox();
            this.tHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBarcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(64, 389);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(143, 389);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Atšaukti";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lItemCode
            // 
            this.lItemCode.AutoSize = true;
            this.lItemCode.Location = new System.Drawing.Point(12, 15);
            this.lItemCode.Name = "lItemCode";
            this.lItemCode.Size = new System.Drawing.Size(75, 13);
            this.lItemCode.TabIndex = 2;
            this.lItemCode.Text = "Prekės kodas:";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(12, 41);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(105, 13);
            this.lName.TabIndex = 3;
            this.lName.Text = "Prekės pavadinimas:";
            // 
            // lDescription
            // 
            this.lDescription.AutoSize = true;
            this.lDescription.Location = new System.Drawing.Point(12, 67);
            this.lDescription.Name = "lDescription";
            this.lDescription.Size = new System.Drawing.Size(96, 13);
            this.lDescription.TabIndex = 4;
            this.lDescription.Text = "Prekės aprašymas:";
            // 
            // lNetWeight
            // 
            this.lNetWeight.AutoSize = true;
            this.lNetWeight.Location = new System.Drawing.Point(12, 119);
            this.lNetWeight.Name = "lNetWeight";
            this.lNetWeight.Size = new System.Drawing.Size(63, 13);
            this.lNetWeight.TabIndex = 5;
            this.lNetWeight.Text = "Neto svoris:";
            // 
            // lBrutoWeight
            // 
            this.lBrutoWeight.AutoSize = true;
            this.lBrutoWeight.Location = new System.Drawing.Point(12, 145);
            this.lBrutoWeight.Name = "lBrutoWeight";
            this.lBrutoWeight.Size = new System.Drawing.Size(65, 13);
            this.lBrutoWeight.TabIndex = 6;
            this.lBrutoWeight.Text = "Bruto svoris:";
            // 
            // lItemVolume
            // 
            this.lItemVolume.AutoSize = true;
            this.lItemVolume.Location = new System.Drawing.Point(12, 171);
            this.lItemVolume.Name = "lItemVolume";
            this.lItemVolume.Size = new System.Drawing.Size(30, 13);
            this.lItemVolume.TabIndex = 7;
            this.lItemVolume.Text = "Tūris";
            // 
            // lMU
            // 
            this.lMU.AutoSize = true;
            this.lMU.Location = new System.Drawing.Point(12, 197);
            this.lMU.Name = "lMU";
            this.lMU.Size = new System.Drawing.Size(99, 13);
            this.lMU.TabIndex = 8;
            this.lMU.Text = "Matavimo vienetas:";
            // 
            // lCreateDate
            // 
            this.lCreateDate.AutoSize = true;
            this.lCreateDate.Location = new System.Drawing.Point(12, 302);
            this.lCreateDate.Name = "lCreateDate";
            this.lCreateDate.Size = new System.Drawing.Size(78, 13);
            this.lCreateDate.TabIndex = 9;
            this.lCreateDate.Text = "Sūkurimo data:";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(12, 93);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(68, 13);
            this.lType.TabIndex = 10;
            this.lType.Text = "Prekės tipas:";
            // 
            // lUpdateDate
            // 
            this.lUpdateDate.AutoSize = true;
            this.lUpdateDate.Location = new System.Drawing.Point(12, 328);
            this.lUpdateDate.Name = "lUpdateDate";
            this.lUpdateDate.Size = new System.Drawing.Size(57, 13);
            this.lUpdateDate.TabIndex = 11;
            this.lUpdateDate.Text = "Atnaujinta:";
            // 
            // lWarehouseId
            // 
            this.lWarehouseId.AutoSize = true;
            this.lWarehouseId.Location = new System.Drawing.Point(12, 354);
            this.lWarehouseId.Name = "lWarehouseId";
            this.lWarehouseId.Size = new System.Drawing.Size(50, 13);
            this.lWarehouseId.TabIndex = 12;
            this.lWarehouseId.Text = "Sandėlis:";
            // 
            // tItemCode
            // 
            this.tItemCode.Location = new System.Drawing.Point(118, 12);
            this.tItemCode.Name = "tItemCode";
            this.tItemCode.Size = new System.Drawing.Size(100, 20);
            this.tItemCode.TabIndex = 13;
            // 
            // tItemName
            // 
            this.tItemName.Location = new System.Drawing.Point(118, 38);
            this.tItemName.Name = "tItemName";
            this.tItemName.Size = new System.Drawing.Size(100, 20);
            this.tItemName.TabIndex = 14;
            // 
            // tNetWeight
            // 
            this.tNetWeight.Location = new System.Drawing.Point(118, 116);
            this.tNetWeight.Name = "tNetWeight";
            this.tNetWeight.Size = new System.Drawing.Size(100, 20);
            this.tNetWeight.TabIndex = 15;
            this.tNetWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNetWeight_KeyPress);
            // 
            // tItemDescription
            // 
            this.tItemDescription.Location = new System.Drawing.Point(118, 64);
            this.tItemDescription.Name = "tItemDescription";
            this.tItemDescription.Size = new System.Drawing.Size(100, 20);
            this.tItemDescription.TabIndex = 16;
            // 
            // tBrutoWeight
            // 
            this.tBrutoWeight.Location = new System.Drawing.Point(118, 142);
            this.tBrutoWeight.Name = "tBrutoWeight";
            this.tBrutoWeight.Size = new System.Drawing.Size(100, 20);
            this.tBrutoWeight.TabIndex = 18;
            this.tBrutoWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBrutoWeight_KeyPress);
            // 
            // tCreateDate
            // 
            this.tCreateDate.Location = new System.Drawing.Point(118, 299);
            this.tCreateDate.Name = "tCreateDate";
            this.tCreateDate.Size = new System.Drawing.Size(100, 20);
            this.tCreateDate.TabIndex = 19;
            // 
            // tVolume
            // 
            this.tVolume.Location = new System.Drawing.Point(118, 168);
            this.tVolume.Name = "tVolume";
            this.tVolume.Size = new System.Drawing.Size(100, 20);
            this.tVolume.TabIndex = 21;
            this.tVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tVolume_KeyPress);
            // 
            // tUpdated
            // 
            this.tUpdated.Location = new System.Drawing.Point(119, 325);
            this.tUpdated.Name = "tUpdated";
            this.tUpdated.Size = new System.Drawing.Size(100, 20);
            this.tUpdated.TabIndex = 22;
            // 
            // cItemType
            // 
            this.cItemType.FormattingEnabled = true;
            this.cItemType.Location = new System.Drawing.Point(118, 89);
            this.cItemType.Name = "cItemType";
            this.cItemType.Size = new System.Drawing.Size(100, 21);
            this.cItemType.TabIndex = 23;
            // 
            // cMU
            // 
            this.cMU.Enabled = false;
            this.cMU.FormattingEnabled = true;
            this.cMU.Location = new System.Drawing.Point(118, 194);
            this.cMU.Name = "cMU";
            this.cMU.Size = new System.Drawing.Size(100, 21);
            this.cMU.TabIndex = 24;
            // 
            // tWarehouseId
            // 
            this.tWarehouseId.Location = new System.Drawing.Point(119, 351);
            this.tWarehouseId.Name = "tWarehouseId";
            this.tWarehouseId.Size = new System.Drawing.Size(100, 20);
            this.tWarehouseId.TabIndex = 25;
            // 
            // tWidth
            // 
            this.tWidth.Location = new System.Drawing.Point(118, 273);
            this.tWidth.Name = "tWidth";
            this.tWidth.Size = new System.Drawing.Size(100, 20);
            this.tWidth.TabIndex = 30;
            // 
            // tHeight
            // 
            this.tHeight.Location = new System.Drawing.Point(118, 247);
            this.tHeight.Name = "tHeight";
            this.tHeight.Size = new System.Drawing.Size(100, 20);
            this.tHeight.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Plotis (m):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Aukštis (m):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Barkodas:";
            // 
            // tBarcode
            // 
            this.tBarcode.Location = new System.Drawing.Point(118, 221);
            this.tBarcode.Name = "tBarcode";
            this.tBarcode.Size = new System.Drawing.Size(100, 20);
            this.tBarcode.TabIndex = 32;
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 420);
            this.Controls.Add(this.tBarcode);
            this.Controls.Add(this.tWidth);
            this.Controls.Add(this.tHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tWarehouseId);
            this.Controls.Add(this.cMU);
            this.Controls.Add(this.cItemType);
            this.Controls.Add(this.tUpdated);
            this.Controls.Add(this.tVolume);
            this.Controls.Add(this.tCreateDate);
            this.Controls.Add(this.tBrutoWeight);
            this.Controls.Add(this.tItemDescription);
            this.Controls.Add(this.tNetWeight);
            this.Controls.Add(this.tItemName);
            this.Controls.Add(this.tItemCode);
            this.Controls.Add(this.lWarehouseId);
            this.Controls.Add(this.lUpdateDate);
            this.Controls.Add(this.lType);
            this.Controls.Add(this.lCreateDate);
            this.Controls.Add(this.lMU);
            this.Controls.Add(this.lItemVolume);
            this.Controls.Add(this.lBrutoWeight);
            this.Controls.Add(this.lNetWeight);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lItemCode);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "ItemEditor";
            this.Text = "ItemEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lItemCode;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lDescription;
        private System.Windows.Forms.Label lNetWeight;
        private System.Windows.Forms.Label lBrutoWeight;
        private System.Windows.Forms.Label lItemVolume;
        private System.Windows.Forms.Label lMU;
        private System.Windows.Forms.Label lCreateDate;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label lUpdateDate;
        private System.Windows.Forms.Label lWarehouseId;
        private System.Windows.Forms.TextBox tItemCode;
        private System.Windows.Forms.TextBox tItemName;
        private System.Windows.Forms.TextBox tNetWeight;
        private System.Windows.Forms.TextBox tItemDescription;
        private System.Windows.Forms.TextBox tBrutoWeight;
        private System.Windows.Forms.TextBox tCreateDate;
        private System.Windows.Forms.TextBox tVolume;
        private System.Windows.Forms.TextBox tUpdated;
        private System.Windows.Forms.ComboBox cItemType;
        private System.Windows.Forms.ComboBox cMU;
        private System.Windows.Forms.TextBox tWarehouseId;
        private System.Windows.Forms.TextBox tWidth;
        private System.Windows.Forms.TextBox tHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBarcode;
    }
}