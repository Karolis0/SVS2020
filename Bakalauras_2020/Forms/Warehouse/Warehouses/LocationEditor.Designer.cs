namespace Bakalauras_2020.Forms.Warehouse.Items
{
    partial class LocationEditor
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
            this.lLocationCode = new System.Windows.Forms.Label();
            this.lCountry = new System.Windows.Forms.Label();
            this.lBuildingNumber = new System.Windows.Forms.Label();
            this.lMiestas = new System.Windows.Forms.Label();
            this.lFlatNumber = new System.Windows.Forms.Label();
            this.tLocationCode = new System.Windows.Forms.TextBox();
            this.tCountry = new System.Windows.Forms.TextBox();
            this.tBuildingNo = new System.Windows.Forms.TextBox();
            this.tFlatNo = new System.Windows.Forms.TextBox();
            this.tUpdated = new System.Windows.Forms.TextBox();
            this.tCreated = new System.Windows.Forms.TextBox();
            this.lUpdated = new System.Windows.Forms.Label();
            this.lCreated = new System.Windows.Forms.Label();
            this.tCity = new System.Windows.Forms.TextBox();
            this.tStreetName = new System.Windows.Forms.TextBox();
            this.lStreetName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(65, 238);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(144, 238);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Atšaukti";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lLocationCode
            // 
            this.lLocationCode.AutoSize = true;
            this.lLocationCode.Location = new System.Drawing.Point(12, 15);
            this.lLocationCode.Name = "lLocationCode";
            this.lLocationCode.Size = new System.Drawing.Size(83, 13);
            this.lLocationCode.TabIndex = 2;
            this.lLocationCode.Text = "Vietovės kodas:";
            // 
            // lCountry
            // 
            this.lCountry.AutoSize = true;
            this.lCountry.Location = new System.Drawing.Point(12, 41);
            this.lCountry.Name = "lCountry";
            this.lCountry.Size = new System.Drawing.Size(32, 13);
            this.lCountry.TabIndex = 3;
            this.lCountry.Text = "Šalis:";
            // 
            // lBuildingNumber
            // 
            this.lBuildingNumber.AutoSize = true;
            this.lBuildingNumber.Location = new System.Drawing.Point(12, 122);
            this.lBuildingNumber.Name = "lBuildingNumber";
            this.lBuildingNumber.Size = new System.Drawing.Size(85, 13);
            this.lBuildingNumber.TabIndex = 9;
            this.lBuildingNumber.Text = "Pastato numeris:";
            // 
            // lMiestas
            // 
            this.lMiestas.AutoSize = true;
            this.lMiestas.Location = new System.Drawing.Point(12, 70);
            this.lMiestas.Name = "lMiestas";
            this.lMiestas.Size = new System.Drawing.Size(103, 13);
            this.lMiestas.TabIndex = 10;
            this.lMiestas.Text = "Miesto pavadinimas:";
            // 
            // lFlatNumber
            // 
            this.lFlatNumber.AutoSize = true;
            this.lFlatNumber.Location = new System.Drawing.Point(12, 148);
            this.lFlatNumber.Name = "lFlatNumber";
            this.lFlatNumber.Size = new System.Drawing.Size(71, 13);
            this.lFlatNumber.TabIndex = 11;
            this.lFlatNumber.Text = "Buto numeris:";
            // 
            // tLocationCode
            // 
            this.tLocationCode.Location = new System.Drawing.Point(119, 12);
            this.tLocationCode.Name = "tLocationCode";
            this.tLocationCode.Size = new System.Drawing.Size(100, 20);
            this.tLocationCode.TabIndex = 13;
            // 
            // tCountry
            // 
            this.tCountry.Location = new System.Drawing.Point(119, 38);
            this.tCountry.Name = "tCountry";
            this.tCountry.Size = new System.Drawing.Size(100, 20);
            this.tCountry.TabIndex = 14;
            // 
            // tBuildingNo
            // 
            this.tBuildingNo.Location = new System.Drawing.Point(119, 119);
            this.tBuildingNo.Name = "tBuildingNo";
            this.tBuildingNo.Size = new System.Drawing.Size(100, 20);
            this.tBuildingNo.TabIndex = 19;
            // 
            // tFlatNo
            // 
            this.tFlatNo.Location = new System.Drawing.Point(119, 145);
            this.tFlatNo.Name = "tFlatNo";
            this.tFlatNo.Size = new System.Drawing.Size(100, 20);
            this.tFlatNo.TabIndex = 22;
            // 
            // tUpdated
            // 
            this.tUpdated.Location = new System.Drawing.Point(119, 197);
            this.tUpdated.Name = "tUpdated";
            this.tUpdated.Size = new System.Drawing.Size(100, 20);
            this.tUpdated.TabIndex = 27;
            // 
            // tCreated
            // 
            this.tCreated.Location = new System.Drawing.Point(119, 171);
            this.tCreated.Name = "tCreated";
            this.tCreated.Size = new System.Drawing.Size(100, 20);
            this.tCreated.TabIndex = 26;
            // 
            // lUpdated
            // 
            this.lUpdated.AutoSize = true;
            this.lUpdated.Location = new System.Drawing.Point(12, 200);
            this.lUpdated.Name = "lUpdated";
            this.lUpdated.Size = new System.Drawing.Size(57, 13);
            this.lUpdated.TabIndex = 25;
            this.lUpdated.Text = "Atnaujinta:";
            // 
            // lCreated
            // 
            this.lCreated.AutoSize = true;
            this.lCreated.Location = new System.Drawing.Point(12, 174);
            this.lCreated.Name = "lCreated";
            this.lCreated.Size = new System.Drawing.Size(47, 13);
            this.lCreated.TabIndex = 24;
            this.lCreated.Text = "Sukurta:";
            // 
            // tCity
            // 
            this.tCity.Location = new System.Drawing.Point(119, 67);
            this.tCity.Name = "tCity";
            this.tCity.Size = new System.Drawing.Size(100, 20);
            this.tCity.TabIndex = 28;
            // 
            // tStreetName
            // 
            this.tStreetName.Location = new System.Drawing.Point(119, 93);
            this.tStreetName.Name = "tStreetName";
            this.tStreetName.Size = new System.Drawing.Size(100, 20);
            this.tStreetName.TabIndex = 30;
            // 
            // lStreetName
            // 
            this.lStreetName.AutoSize = true;
            this.lStreetName.Location = new System.Drawing.Point(10, 96);
            this.lStreetName.Name = "lStreetName";
            this.lStreetName.Size = new System.Drawing.Size(106, 13);
            this.lStreetName.TabIndex = 29;
            this.lStreetName.Text = "Gatvės pavadinimas:";
            // 
            // LocationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 294);
            this.Controls.Add(this.tStreetName);
            this.Controls.Add(this.lStreetName);
            this.Controls.Add(this.tCity);
            this.Controls.Add(this.tUpdated);
            this.Controls.Add(this.tCreated);
            this.Controls.Add(this.lUpdated);
            this.Controls.Add(this.lCreated);
            this.Controls.Add(this.tFlatNo);
            this.Controls.Add(this.tBuildingNo);
            this.Controls.Add(this.tCountry);
            this.Controls.Add(this.tLocationCode);
            this.Controls.Add(this.lFlatNumber);
            this.Controls.Add(this.lMiestas);
            this.Controls.Add(this.lBuildingNumber);
            this.Controls.Add(this.lCountry);
            this.Controls.Add(this.lLocationCode);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "LocationEditor";
            this.Text = "Vietovės redagavimo langas";
            this.Load += new System.EventHandler(this.LocationEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lLocationCode;
        private System.Windows.Forms.Label lCountry;
        private System.Windows.Forms.Label lBuildingNumber;
        private System.Windows.Forms.Label lMiestas;
        private System.Windows.Forms.Label lFlatNumber;
        private System.Windows.Forms.TextBox tLocationCode;
        private System.Windows.Forms.TextBox tCountry;
        private System.Windows.Forms.TextBox tBuildingNo;
        private System.Windows.Forms.TextBox tFlatNo;
        private System.Windows.Forms.TextBox tUpdated;
        private System.Windows.Forms.TextBox tCreated;
        private System.Windows.Forms.Label lUpdated;
        private System.Windows.Forms.Label lCreated;
        private System.Windows.Forms.TextBox tCity;
        private System.Windows.Forms.TextBox tStreetName;
        private System.Windows.Forms.Label lStreetName;
    }
}