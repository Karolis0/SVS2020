namespace Bakalauras_2020.Forms.Mappers
{
    partial class PartnerMapperGUI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bCreate = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(572, 146);
            this.dataGridView1.TabIndex = 0;
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(0, -2);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(86, 76);
            this.bCreate.TabIndex = 1;
            this.bCreate.Text = "Naujas";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(82, -2);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(86, 76);
            this.bEdit.TabIndex = 2;
            this.bEdit.Text = "Redaguoti";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // PartnerMapperGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 220);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PartnerMapperGUI";
            this.Text = "Partnerių sąrašas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Button bEdit;
    }
}