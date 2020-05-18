namespace Bakalauras_2020.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.bLogin = new System.Windows.Forms.Button();
            this.lUsername = new System.Windows.Forms.Label();
            this.lPassword = new System.Windows.Forms.Label();
            this.tUsername = new System.Windows.Forms.TextBox();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.lFailedLogin = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(115, 353);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(149, 23);
            this.bLogin.TabIndex = 0;
            this.bLogin.Text = "Prisijungti";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(76, 301);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(100, 13);
            this.lUsername.TabIndex = 1;
            this.lUsername.Text = "Prisijungimo vardas:";
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Location = new System.Drawing.Point(112, 330);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(64, 13);
            this.lPassword.TabIndex = 2;
            this.lPassword.Text = "Slaptažodis:";
            // 
            // tUsername
            // 
            this.tUsername.Location = new System.Drawing.Point(182, 298);
            this.tUsername.Name = "tUsername";
            this.tUsername.Size = new System.Drawing.Size(148, 20);
            this.tUsername.TabIndex = 3;
            this.tUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tUsername_KeyDown);
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(182, 327);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(148, 20);
            this.tPassword.TabIndex = 4;
            this.tPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tPassword_KeyDown);
            // 
            // lTitle
            // 
            this.lTitle.Font = new System.Drawing.Font("Monotype Corsiva", 27F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(12, 9);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(369, 90);
            this.lTitle.TabIndex = 5;
            this.lTitle.Text = "Sandėlio valdymo sistema „Lynx“";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFailedLogin
            // 
            this.lFailedLogin.AutoSize = true;
            this.lFailedLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFailedLogin.ForeColor = System.Drawing.Color.Red;
            this.lFailedLogin.Location = new System.Drawing.Point(49, 271);
            this.lFailedLogin.Name = "lFailedLogin";
            this.lFailedLogin.Size = new System.Drawing.Size(281, 13);
            this.lFailedLogin.TabIndex = 6;
            this.lFailedLogin.Text = "Neteisingas prisijungimo vardas arba slaptažodis\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bakalauras_2020.Properties.Resources.LoginImg;
            this.pictureBox1.Location = new System.Drawing.Point(124, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 145);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 388);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lFailedLogin);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.tUsername);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.lUsername);
            this.Controls.Add(this.bLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prisijungimas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TextBox tUsername;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lFailedLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}