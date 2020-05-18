namespace Bakalauras_2020.Forms.Warehouse.Items
{
    partial class PartnerEditor
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
            this.tPartnerCode = new System.Windows.Forms.TextBox();
            this.tPartnerName = new System.Windows.Forms.TextBox();
            this.tUpdated = new System.Windows.Forms.TextBox();
            this.tCreated = new System.Windows.Forms.TextBox();
            this.lUpdated = new System.Windows.Forms.Label();
            this.lCreated = new System.Windows.Forms.Label();
            this.cbSupply = new System.Windows.Forms.CheckBox();
            this.cbCustomer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(71, 159);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(150, 159);
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
            this.lLocationCode.Size = new System.Drawing.Size(84, 13);
            this.lLocationCode.TabIndex = 2;
            this.lLocationCode.Text = "Partnerio kodas:";
            // 
            // lCountry
            // 
            this.lCountry.AutoSize = true;
            this.lCountry.Location = new System.Drawing.Point(12, 41);
            this.lCountry.Name = "lCountry";
            this.lCountry.Size = new System.Drawing.Size(114, 13);
            this.lCountry.TabIndex = 3;
            this.lCountry.Text = "Partnerio pavadinimas:";
            // 
            // tPartnerCode
            // 
            this.tPartnerCode.Location = new System.Drawing.Point(125, 12);
            this.tPartnerCode.Name = "tPartnerCode";
            this.tPartnerCode.Size = new System.Drawing.Size(100, 20);
            this.tPartnerCode.TabIndex = 13;
            // 
            // tPartnerName
            // 
            this.tPartnerName.Location = new System.Drawing.Point(125, 38);
            this.tPartnerName.Name = "tPartnerName";
            this.tPartnerName.Size = new System.Drawing.Size(100, 20);
            this.tPartnerName.TabIndex = 14;
            // 
            // tUpdated
            // 
            this.tUpdated.Location = new System.Drawing.Point(125, 90);
            this.tUpdated.Name = "tUpdated";
            this.tUpdated.Size = new System.Drawing.Size(100, 20);
            this.tUpdated.TabIndex = 27;
            // 
            // tCreated
            // 
            this.tCreated.Location = new System.Drawing.Point(125, 64);
            this.tCreated.Name = "tCreated";
            this.tCreated.Size = new System.Drawing.Size(100, 20);
            this.tCreated.TabIndex = 26;
            // 
            // lUpdated
            // 
            this.lUpdated.AutoSize = true;
            this.lUpdated.Location = new System.Drawing.Point(12, 93);
            this.lUpdated.Name = "lUpdated";
            this.lUpdated.Size = new System.Drawing.Size(57, 13);
            this.lUpdated.TabIndex = 25;
            this.lUpdated.Text = "Atnaujinta:";
            // 
            // lCreated
            // 
            this.lCreated.AutoSize = true;
            this.lCreated.Location = new System.Drawing.Point(12, 67);
            this.lCreated.Name = "lCreated";
            this.lCreated.Size = new System.Drawing.Size(47, 13);
            this.lCreated.TabIndex = 24;
            this.lCreated.Text = "Sukurta:";
            // 
            // cbSupply
            // 
            this.cbSupply.AutoSize = true;
            this.cbSupply.Location = new System.Drawing.Point(12, 133);
            this.cbSupply.Name = "cbSupply";
            this.cbSupply.Size = new System.Drawing.Size(66, 17);
            this.cbSupply.TabIndex = 28;
            this.cbSupply.Text = "Tiekėjas";
            this.cbSupply.UseVisualStyleBackColor = true;
            this.cbSupply.CheckedChanged += new System.EventHandler(this.cbSupply_CheckedChanged);
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoSize = true;
            this.cbCustomer.Location = new System.Drawing.Point(121, 133);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(79, 17);
            this.cbCustomer.TabIndex = 29;
            this.cbCustomer.Text = "Užsakovas";
            this.cbCustomer.UseVisualStyleBackColor = true;
            this.cbCustomer.CheckedChanged += new System.EventHandler(this.cbCustomer_CheckedChanged);
            // 
            // PartnerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 194);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.cbSupply);
            this.Controls.Add(this.tUpdated);
            this.Controls.Add(this.tCreated);
            this.Controls.Add(this.lUpdated);
            this.Controls.Add(this.lCreated);
            this.Controls.Add(this.tPartnerName);
            this.Controls.Add(this.tPartnerCode);
            this.Controls.Add(this.lCountry);
            this.Controls.Add(this.lLocationCode);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "PartnerEditor";
            this.Text = "Partnerių redagavimo langas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lLocationCode;
        private System.Windows.Forms.Label lCountry;
        private System.Windows.Forms.TextBox tPartnerCode;
        private System.Windows.Forms.TextBox tPartnerName;
        private System.Windows.Forms.TextBox tUpdated;
        private System.Windows.Forms.TextBox tCreated;
        private System.Windows.Forms.Label lUpdated;
        private System.Windows.Forms.Label lCreated;
        private System.Windows.Forms.CheckBox cbSupply;
        private System.Windows.Forms.CheckBox cbCustomer;
    }
}