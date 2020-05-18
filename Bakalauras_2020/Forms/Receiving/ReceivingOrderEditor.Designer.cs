namespace Bakalauras_2020.Forms.Receiving
{
    partial class ReceivingOrderEditor
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
            this.lCreateDate = new System.Windows.Forms.Label();
            this.lUpdateDate = new System.Windows.Forms.Label();
            this.tCreateDate = new System.Windows.Forms.TextBox();
            this.tUpdated = new System.Windows.Forms.TextBox();
            this.tDocNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tWarehouse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dView)).BeginInit();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(437, 318);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(516, 318);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Atšaukti";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lCreateDate
            // 
            this.lCreateDate.AutoSize = true;
            this.lCreateDate.Location = new System.Drawing.Point(12, 67);
            this.lCreateDate.Name = "lCreateDate";
            this.lCreateDate.Size = new System.Drawing.Size(78, 13);
            this.lCreateDate.TabIndex = 9;
            this.lCreateDate.Text = "Sūkurimo data:";
            // 
            // lUpdateDate
            // 
            this.lUpdateDate.AutoSize = true;
            this.lUpdateDate.Location = new System.Drawing.Point(12, 93);
            this.lUpdateDate.Name = "lUpdateDate";
            this.lUpdateDate.Size = new System.Drawing.Size(57, 13);
            this.lUpdateDate.TabIndex = 11;
            this.lUpdateDate.Text = "Atnaujinta:";
            // 
            // tCreateDate
            // 
            this.tCreateDate.Location = new System.Drawing.Point(125, 64);
            this.tCreateDate.Name = "tCreateDate";
            this.tCreateDate.Size = new System.Drawing.Size(466, 20);
            this.tCreateDate.TabIndex = 19;
            // 
            // tUpdated
            // 
            this.tUpdated.Location = new System.Drawing.Point(125, 90);
            this.tUpdated.Name = "tUpdated";
            this.tUpdated.Size = new System.Drawing.Size(466, 20);
            this.tUpdated.TabIndex = 22;
            // 
            // tDocNo
            // 
            this.tDocNo.Location = new System.Drawing.Point(125, 12);
            this.tDocNo.Name = "tDocNo";
            this.tDocNo.Size = new System.Drawing.Size(466, 20);
            this.tDocNo.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dokumento numeris :";
            // 
            // dView
            // 
            this.dView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dView.Location = new System.Drawing.Point(15, 116);
            this.dView.Name = "dView";
            this.dView.Size = new System.Drawing.Size(576, 135);
            this.dView.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Sandėlis:";
            // 
            // tWarehouse
            // 
            this.tWarehouse.Location = new System.Drawing.Point(125, 38);
            this.tWarehouse.Name = "tWarehouse";
            this.tWarehouse.Size = new System.Drawing.Size(466, 20);
            this.tWarehouse.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Desktop;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGreen;
            this.label3.Location = new System.Drawing.Point(12, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(411, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Šviesiai žalia - priėmimo užsakymas neturi priskirto priėmimo dokumento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Desktop;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Cyan;
            this.label4.Location = new System.Drawing.Point(12, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(348, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Cianas - priėmimo užsakymas priskirtas priėmimo dokumentui";
            // 
            // ReceivingOrderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 348);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tWarehouse);
            this.Controls.Add(this.dView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tDocNo);
            this.Controls.Add(this.tUpdated);
            this.Controls.Add(this.tCreateDate);
            this.Controls.Add(this.lUpdateDate);
            this.Controls.Add(this.lCreateDate);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "ReceivingOrderEditor";
            this.Text = "Priėmimo dokumentų redagavimo langas";
            ((System.ComponentModel.ISupportInitialize)(this.dView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lCreateDate;
        private System.Windows.Forms.Label lUpdateDate;
        private System.Windows.Forms.TextBox tCreateDate;
        private System.Windows.Forms.TextBox tUpdated;
        private System.Windows.Forms.TextBox tDocNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tWarehouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}