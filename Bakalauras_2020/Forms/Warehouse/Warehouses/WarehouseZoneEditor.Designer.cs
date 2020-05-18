namespace Bakalauras_2020.Forms.Warehouse.Items
{
    partial class WarehouseZoneEditor
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
            this.lFZoneCode = new System.Windows.Forms.Label();
            this.lCountry = new System.Windows.Forms.Label();
            this.lMiestas = new System.Windows.Forms.Label();
            this.tFZoneCode = new System.Windows.Forms.TextBox();
            this.tFZoneName = new System.Windows.Forms.TextBox();
            this.tUpdated = new System.Windows.Forms.TextBox();
            this.tCreated = new System.Windows.Forms.TextBox();
            this.lUpdated = new System.Windows.Forms.Label();
            this.lCreated = new System.Windows.Forms.Label();
            this.tWarehouse = new System.Windows.Forms.TextBox();
            this.tParent = new System.Windows.Forms.TextBox();
            this.lStreetName = new System.Windows.Forms.Label();
            this.tSpotHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tSpotWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tSpotLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tSpotVolume = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(112, 323);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(191, 323);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Atšaukti";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lFZoneCode
            // 
            this.lFZoneCode.AutoSize = true;
            this.lFZoneCode.Location = new System.Drawing.Point(12, 15);
            this.lFZoneCode.Name = "lFZoneCode";
            this.lFZoneCode.Size = new System.Drawing.Size(122, 13);
            this.lFZoneCode.TabIndex = 2;
            this.lFZoneCode.Text = "Funkcinės zonos kodas:";
            // 
            // lCountry
            // 
            this.lCountry.AutoSize = true;
            this.lCountry.Location = new System.Drawing.Point(12, 41);
            this.lCountry.Name = "lCountry";
            this.lCountry.Size = new System.Drawing.Size(152, 13);
            this.lCountry.TabIndex = 3;
            this.lCountry.Text = "Funkcinės zonos pavadinimas:";
            // 
            // lMiestas
            // 
            this.lMiestas.AutoSize = true;
            this.lMiestas.Location = new System.Drawing.Point(12, 70);
            this.lMiestas.Name = "lMiestas";
            this.lMiestas.Size = new System.Drawing.Size(50, 13);
            this.lMiestas.TabIndex = 10;
            this.lMiestas.Text = "Sandėlis:";
            // 
            // tFZoneCode
            // 
            this.tFZoneCode.AcceptsReturn = true;
            this.tFZoneCode.Location = new System.Drawing.Point(165, 12);
            this.tFZoneCode.Name = "tFZoneCode";
            this.tFZoneCode.Size = new System.Drawing.Size(100, 20);
            this.tFZoneCode.TabIndex = 13;
            // 
            // tFZoneName
            // 
            this.tFZoneName.Location = new System.Drawing.Point(165, 38);
            this.tFZoneName.Name = "tFZoneName";
            this.tFZoneName.Size = new System.Drawing.Size(100, 20);
            this.tFZoneName.TabIndex = 14;
            // 
            // tUpdated
            // 
            this.tUpdated.Location = new System.Drawing.Point(165, 253);
            this.tUpdated.Name = "tUpdated";
            this.tUpdated.Size = new System.Drawing.Size(100, 20);
            this.tUpdated.TabIndex = 27;
            // 
            // tCreated
            // 
            this.tCreated.Location = new System.Drawing.Point(165, 227);
            this.tCreated.Name = "tCreated";
            this.tCreated.Size = new System.Drawing.Size(100, 20);
            this.tCreated.TabIndex = 26;
            // 
            // lUpdated
            // 
            this.lUpdated.AutoSize = true;
            this.lUpdated.Location = new System.Drawing.Point(12, 256);
            this.lUpdated.Name = "lUpdated";
            this.lUpdated.Size = new System.Drawing.Size(57, 13);
            this.lUpdated.TabIndex = 25;
            this.lUpdated.Text = "Atnaujinta:";
            // 
            // lCreated
            // 
            this.lCreated.AutoSize = true;
            this.lCreated.Location = new System.Drawing.Point(12, 230);
            this.lCreated.Name = "lCreated";
            this.lCreated.Size = new System.Drawing.Size(47, 13);
            this.lCreated.TabIndex = 24;
            this.lCreated.Text = "Sukurta:";
            // 
            // tWarehouse
            // 
            this.tWarehouse.Location = new System.Drawing.Point(165, 67);
            this.tWarehouse.Name = "tWarehouse";
            this.tWarehouse.Size = new System.Drawing.Size(100, 20);
            this.tWarehouse.TabIndex = 28;
            // 
            // tParent
            // 
            this.tParent.Location = new System.Drawing.Point(165, 200);
            this.tParent.Name = "tParent";
            this.tParent.Size = new System.Drawing.Size(100, 20);
            this.tParent.TabIndex = 30;
            // 
            // lStreetName
            // 
            this.lStreetName.AutoSize = true;
            this.lStreetName.Location = new System.Drawing.Point(12, 203);
            this.lStreetName.Name = "lStreetName";
            this.lStreetName.Size = new System.Drawing.Size(39, 13);
            this.lStreetName.TabIndex = 29;
            this.lStreetName.Text = "Grupė:";
            // 
            // tSpotHeight
            // 
            this.tSpotHeight.Location = new System.Drawing.Point(165, 93);
            this.tSpotHeight.Name = "tSpotHeight";
            this.tSpotHeight.Size = new System.Drawing.Size(100, 20);
            this.tSpotHeight.TabIndex = 34;
            this.tSpotHeight.TextChanged += new System.EventHandler(this.tSpotHeight_TextChanged);
            this.tSpotHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tSpotHeight_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Vietos aukštis (m):";
            // 
            // tSpotWidth
            // 
            this.tSpotWidth.Location = new System.Drawing.Point(165, 120);
            this.tSpotWidth.Name = "tSpotWidth";
            this.tSpotWidth.Size = new System.Drawing.Size(100, 20);
            this.tSpotWidth.TabIndex = 32;
            this.tSpotWidth.TextChanged += new System.EventHandler(this.tSpotWidth_TextChanged);
            this.tSpotWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tSpotWidth_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Vietos plotis (m):";
            // 
            // tSpotLength
            // 
            this.tSpotLength.Location = new System.Drawing.Point(165, 146);
            this.tSpotLength.Name = "tSpotLength";
            this.tSpotLength.Size = new System.Drawing.Size(100, 20);
            this.tSpotLength.TabIndex = 40;
            this.tSpotLength.TextChanged += new System.EventHandler(this.tSpotLength_TextChanged);
            this.tSpotLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tSpotLength_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Vietos ilgis (m):";
            // 
            // tSpotVolume
            // 
            this.tSpotVolume.Location = new System.Drawing.Point(165, 173);
            this.tSpotVolume.Name = "tSpotVolume";
            this.tSpotVolume.Size = new System.Drawing.Size(100, 20);
            this.tSpotVolume.TabIndex = 37;
            this.tSpotVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tSpotVolume_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Vietos tūris (m3):";
            // 
            // WarehouseZoneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 358);
            this.Controls.Add(this.tSpotLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tSpotVolume);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tSpotHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tSpotWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tParent);
            this.Controls.Add(this.lStreetName);
            this.Controls.Add(this.tWarehouse);
            this.Controls.Add(this.tUpdated);
            this.Controls.Add(this.tCreated);
            this.Controls.Add(this.lUpdated);
            this.Controls.Add(this.lCreated);
            this.Controls.Add(this.tFZoneName);
            this.Controls.Add(this.tFZoneCode);
            this.Controls.Add(this.lMiestas);
            this.Controls.Add(this.lCountry);
            this.Controls.Add(this.lFZoneCode);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "WarehouseZoneEditor";
            this.Text = "Sandėlio zonų redagavimo langas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lFZoneCode;
        private System.Windows.Forms.Label lCountry;
        private System.Windows.Forms.Label lMiestas;
        private System.Windows.Forms.TextBox tFZoneCode;
        private System.Windows.Forms.TextBox tFZoneName;
        private System.Windows.Forms.TextBox tUpdated;
        private System.Windows.Forms.TextBox tCreated;
        private System.Windows.Forms.Label lUpdated;
        private System.Windows.Forms.Label lCreated;
        private System.Windows.Forms.TextBox tWarehouse;
        private System.Windows.Forms.TextBox tParent;
        private System.Windows.Forms.Label lStreetName;
        private System.Windows.Forms.TextBox tSpotHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tSpotWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tSpotLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tSpotVolume;
        private System.Windows.Forms.Label label5;
    }
}