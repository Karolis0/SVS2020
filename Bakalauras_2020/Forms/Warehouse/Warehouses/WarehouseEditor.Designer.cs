namespace Bakalauras_2020.Forms.Warehouse.Items
{
    partial class WarehouseEditor
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
            this.tCode = new System.Windows.Forms.TextBox();
            this.tName = new System.Windows.Forms.TextBox();
            this.tCreateDate = new System.Windows.Forms.TextBox();
            this.tUpdated = new System.Windows.Forms.TextBox();
            this.cWarehouseLocId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(98, 148);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(177, 148);
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
            this.lWarehouseCode.Location = new System.Drawing.Point(12, 15);
            this.lWarehouseCode.Name = "lWarehouseCode";
            this.lWarehouseCode.Size = new System.Drawing.Size(83, 13);
            this.lWarehouseCode.TabIndex = 2;
            this.lWarehouseCode.Text = "Sandėlio kodas:";
            // 
            // lWarehouseName
            // 
            this.lWarehouseName.AutoSize = true;
            this.lWarehouseName.Location = new System.Drawing.Point(12, 41);
            this.lWarehouseName.Name = "lWarehouseName";
            this.lWarehouseName.Size = new System.Drawing.Size(113, 13);
            this.lWarehouseName.TabIndex = 3;
            this.lWarehouseName.Text = "Sandėlio pavadinimas:";
            // 
            // lCreateDate
            // 
            this.lCreateDate.AutoSize = true;
            this.lCreateDate.Location = new System.Drawing.Point(12, 99);
            this.lCreateDate.Name = "lCreateDate";
            this.lCreateDate.Size = new System.Drawing.Size(78, 13);
            this.lCreateDate.TabIndex = 9;
            this.lCreateDate.Text = "Sūkurimo data:";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(12, 70);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(118, 13);
            this.lType.TabIndex = 10;
            this.lType.Text = "Sandėlio adreso kodas:";
            // 
            // lUpdateDate
            // 
            this.lUpdateDate.AutoSize = true;
            this.lUpdateDate.Location = new System.Drawing.Point(12, 125);
            this.lUpdateDate.Name = "lUpdateDate";
            this.lUpdateDate.Size = new System.Drawing.Size(57, 13);
            this.lUpdateDate.TabIndex = 11;
            this.lUpdateDate.Text = "Atnaujinta:";
            // 
            // tCode
            // 
            this.tCode.Location = new System.Drawing.Point(152, 8);
            this.tCode.Name = "tCode";
            this.tCode.Size = new System.Drawing.Size(100, 20);
            this.tCode.TabIndex = 13;
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(152, 38);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(100, 20);
            this.tName.TabIndex = 14;
            // 
            // tCreateDate
            // 
            this.tCreateDate.Location = new System.Drawing.Point(152, 96);
            this.tCreateDate.Name = "tCreateDate";
            this.tCreateDate.Size = new System.Drawing.Size(100, 20);
            this.tCreateDate.TabIndex = 19;
            // 
            // tUpdated
            // 
            this.tUpdated.Location = new System.Drawing.Point(152, 122);
            this.tUpdated.Name = "tUpdated";
            this.tUpdated.Size = new System.Drawing.Size(100, 20);
            this.tUpdated.TabIndex = 22;
            // 
            // cWarehouseLocId
            // 
            this.cWarehouseLocId.FormattingEnabled = true;
            this.cWarehouseLocId.Location = new System.Drawing.Point(152, 67);
            this.cWarehouseLocId.Name = "cWarehouseLocId";
            this.cWarehouseLocId.Size = new System.Drawing.Size(100, 21);
            this.cWarehouseLocId.TabIndex = 23;
            // 
            // WarehouseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 183);
            this.Controls.Add(this.cWarehouseLocId);
            this.Controls.Add(this.tUpdated);
            this.Controls.Add(this.tCreateDate);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.tCode);
            this.Controls.Add(this.lUpdateDate);
            this.Controls.Add(this.lType);
            this.Controls.Add(this.lCreateDate);
            this.Controls.Add(this.lWarehouseName);
            this.Controls.Add(this.lWarehouseCode);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "WarehouseEditor";
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
        private System.Windows.Forms.TextBox tCode;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.TextBox tCreateDate;
        private System.Windows.Forms.TextBox tUpdated;
        private System.Windows.Forms.ComboBox cWarehouseLocId;
    }
}