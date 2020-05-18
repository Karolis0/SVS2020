namespace Bakalauras_2020.Forms.Receiving
{
    partial class ReceivingDocEditor
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
            this.tWarehouse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tDocNo = new System.Windows.Forms.TextBox();
            this.tSupplier = new System.Windows.Forms.TextBox();
            this.tTruckNo = new System.Windows.Forms.TextBox();
            this.tTrailerNo = new System.Windows.Forms.TextBox();
            this.tDriver = new System.Windows.Forms.TextBox();
            this.tState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtArrivalPlanned = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(98, 283);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "Saugoti";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(177, 283);
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
            this.lCreateDate.Location = new System.Drawing.Point(12, 223);
            this.lCreateDate.Name = "lCreateDate";
            this.lCreateDate.Size = new System.Drawing.Size(47, 13);
            this.lCreateDate.TabIndex = 9;
            this.lCreateDate.Text = "Sukurta:";
            // 
            // lUpdateDate
            // 
            this.lUpdateDate.AutoSize = true;
            this.lUpdateDate.Location = new System.Drawing.Point(12, 249);
            this.lUpdateDate.Name = "lUpdateDate";
            this.lUpdateDate.Size = new System.Drawing.Size(57, 13);
            this.lUpdateDate.TabIndex = 11;
            this.lUpdateDate.Text = "Atnaujinta:";
            // 
            // tCreateDate
            // 
            this.tCreateDate.Location = new System.Drawing.Point(152, 220);
            this.tCreateDate.Name = "tCreateDate";
            this.tCreateDate.Size = new System.Drawing.Size(100, 20);
            this.tCreateDate.TabIndex = 19;
            // 
            // tUpdated
            // 
            this.tUpdated.Location = new System.Drawing.Point(152, 246);
            this.tUpdated.Name = "tUpdated";
            this.tUpdated.Size = new System.Drawing.Size(100, 20);
            this.tUpdated.TabIndex = 22;
            // 
            // tWarehouse
            // 
            this.tWarehouse.Location = new System.Drawing.Point(152, 194);
            this.tWarehouse.Name = "tWarehouse";
            this.tWarehouse.Size = new System.Drawing.Size(100, 20);
            this.tWarehouse.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Sandėlis:";
            // 
            // tDocNo
            // 
            this.tDocNo.Location = new System.Drawing.Point(152, 12);
            this.tDocNo.Name = "tDocNo";
            this.tDocNo.Size = new System.Drawing.Size(100, 20);
            this.tDocNo.TabIndex = 26;
            // 
            // tSupplier
            // 
            this.tSupplier.Location = new System.Drawing.Point(152, 38);
            this.tSupplier.Name = "tSupplier";
            this.tSupplier.Size = new System.Drawing.Size(100, 20);
            this.tSupplier.TabIndex = 27;
            // 
            // tTruckNo
            // 
            this.tTruckNo.Location = new System.Drawing.Point(152, 90);
            this.tTruckNo.Name = "tTruckNo";
            this.tTruckNo.Size = new System.Drawing.Size(100, 20);
            this.tTruckNo.TabIndex = 29;
            // 
            // tTrailerNo
            // 
            this.tTrailerNo.Location = new System.Drawing.Point(152, 116);
            this.tTrailerNo.Name = "tTrailerNo";
            this.tTrailerNo.Size = new System.Drawing.Size(100, 20);
            this.tTrailerNo.TabIndex = 30;
            // 
            // tDriver
            // 
            this.tDriver.Location = new System.Drawing.Point(152, 142);
            this.tDriver.Name = "tDriver";
            this.tDriver.Size = new System.Drawing.Size(100, 20);
            this.tDriver.TabIndex = 31;
            // 
            // tState
            // 
            this.tState.Location = new System.Drawing.Point(152, 168);
            this.tState.Name = "tState";
            this.tState.Size = new System.Drawing.Size(100, 20);
            this.tState.TabIndex = 32;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tiekėjas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Planuojamas atvykimas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Mašinos numeris:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Priekabos numeris:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Vairuotojas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Būsena:";
            // 
            // dtArrivalPlanned
            // 
            this.dtArrivalPlanned.Location = new System.Drawing.Point(152, 64);
            this.dtArrivalPlanned.Name = "dtArrivalPlanned";
            this.dtArrivalPlanned.Size = new System.Drawing.Size(99, 20);
            this.dtArrivalPlanned.TabIndex = 40;
            // 
            // ReceivingDocEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 316);
            this.Controls.Add(this.dtArrivalPlanned);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tState);
            this.Controls.Add(this.tDriver);
            this.Controls.Add(this.tTrailerNo);
            this.Controls.Add(this.tTruckNo);
            this.Controls.Add(this.tSupplier);
            this.Controls.Add(this.tDocNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tWarehouse);
            this.Controls.Add(this.tUpdated);
            this.Controls.Add(this.tCreateDate);
            this.Controls.Add(this.lUpdateDate);
            this.Controls.Add(this.lCreateDate);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "ReceivingDocEditor";
            this.Text = "Priėmimo užsakymų redagavimo langas";
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
        private System.Windows.Forms.TextBox tWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tDocNo;
        private System.Windows.Forms.TextBox tSupplier;
        private System.Windows.Forms.TextBox tTruckNo;
        private System.Windows.Forms.TextBox tTrailerNo;
        private System.Windows.Forms.TextBox tDriver;
        private System.Windows.Forms.TextBox tState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtArrivalPlanned;
    }
}