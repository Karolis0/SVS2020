namespace Bakalauras_2020.Forms.Warehouse.Items
{
    partial class PalletTypeEditor
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
            this.lWarehouseCode = new System.Windows.Forms.Label();
            this.lWarehouseName = new System.Windows.Forms.Label();
            this.lCreateDate = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.lUpdateDate = new System.Windows.Forms.Label();
            this.tNumber = new System.Windows.Forms.TextBox();
            this.tHeight = new System.Windows.Forms.TextBox();
            this.tWidth = new System.Windows.Forms.TextBox();
            this.tVolume = new System.Windows.Forms.TextBox();
            this.tLength = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(68, 148);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(147, 148);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Atšaukti";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lWarehouseCode
            // 
            this.lWarehouseCode.AutoSize = true;
            this.lWarehouseCode.Location = new System.Drawing.Point(12, 11);
            this.lWarehouseCode.Name = "lWarehouseCode";
            this.lWarehouseCode.Size = new System.Drawing.Size(84, 13);
            this.lWarehouseCode.TabIndex = 2;
            this.lWarehouseCode.Text = "Paletės numeris:";
            // 
            // lWarehouseName
            // 
            this.lWarehouseName.AutoSize = true;
            this.lWarehouseName.Location = new System.Drawing.Point(12, 37);
            this.lWarehouseName.Name = "lWarehouseName";
            this.lWarehouseName.Size = new System.Drawing.Size(44, 13);
            this.lWarehouseName.TabIndex = 3;
            this.lWarehouseName.Text = "Aukštis:";
            // 
            // lCreateDate
            // 
            this.lCreateDate.AutoSize = true;
            this.lCreateDate.Location = new System.Drawing.Point(12, 89);
            this.lCreateDate.Name = "lCreateDate";
            this.lCreateDate.Size = new System.Drawing.Size(35, 13);
            this.lCreateDate.TabIndex = 9;
            this.lCreateDate.Text = "Plotis:";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(12, 63);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(28, 13);
            this.lType.TabIndex = 10;
            this.lType.Text = "Ilgis:";
            // 
            // lUpdateDate
            // 
            this.lUpdateDate.AutoSize = true;
            this.lUpdateDate.Location = new System.Drawing.Point(12, 115);
            this.lUpdateDate.Name = "lUpdateDate";
            this.lUpdateDate.Size = new System.Drawing.Size(33, 13);
            this.lUpdateDate.TabIndex = 11;
            this.lUpdateDate.Text = "Tūris:";
            // 
            // tNumber
            // 
            this.tNumber.Location = new System.Drawing.Point(122, 8);
            this.tNumber.Name = "tNumber";
            this.tNumber.Size = new System.Drawing.Size(100, 20);
            this.tNumber.TabIndex = 13;
            this.tNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNumber_KeyPress);
            // 
            // tHeight
            // 
            this.tHeight.Location = new System.Drawing.Point(122, 34);
            this.tHeight.Name = "tHeight";
            this.tHeight.Size = new System.Drawing.Size(100, 20);
            this.tHeight.TabIndex = 14;
            this.tHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tHeight_KeyPress);
            // 
            // tWidth
            // 
            this.tWidth.Location = new System.Drawing.Point(122, 86);
            this.tWidth.Name = "tWidth";
            this.tWidth.Size = new System.Drawing.Size(100, 20);
            this.tWidth.TabIndex = 19;
            this.tWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tWidth_KeyPress);
            // 
            // tVolume
            // 
            this.tVolume.Location = new System.Drawing.Point(122, 112);
            this.tVolume.Name = "tVolume";
            this.tVolume.Size = new System.Drawing.Size(100, 20);
            this.tVolume.TabIndex = 22;
            this.tVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tVolume_KeyPress);
            // 
            // tLength
            // 
            this.tLength.Location = new System.Drawing.Point(122, 60);
            this.tLength.Name = "tLength";
            this.tLength.Size = new System.Drawing.Size(100, 20);
            this.tLength.TabIndex = 23;
            this.tLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tLength_KeyPress);
            // 
            // PalletTypeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 183);
            this.Controls.Add(this.tLength);
            this.Controls.Add(this.tVolume);
            this.Controls.Add(this.tWidth);
            this.Controls.Add(this.tHeight);
            this.Controls.Add(this.tNumber);
            this.Controls.Add(this.lUpdateDate);
            this.Controls.Add(this.lType);
            this.Controls.Add(this.lCreateDate);
            this.Controls.Add(this.lWarehouseName);
            this.Controls.Add(this.lWarehouseCode);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "PalletTypeEditor";
            this.Text = "ItemEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lWarehouseCode;
        private System.Windows.Forms.Label lWarehouseName;
        private System.Windows.Forms.Label lCreateDate;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label lUpdateDate;
        private System.Windows.Forms.TextBox tNumber;
        private System.Windows.Forms.TextBox tHeight;
        private System.Windows.Forms.TextBox tWidth;
        private System.Windows.Forms.TextBox tVolume;
        private System.Windows.Forms.TextBox tLength;
    }
}