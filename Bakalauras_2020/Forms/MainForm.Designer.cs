namespace Bakalauras_2020.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tModuleButtons = new System.Windows.Forms.ToolStrip();
            this.tReceiving = new System.Windows.Forms.ToolStripSplitButton();
            this.pristatymaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priėmimoDokumentaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priėmimoUžsakymaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tDistOrders = new System.Windows.Forms.ToolStripSplitButton();
            this.išsiuntimoUžsakymaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siuntosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rūšiavimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surinkimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tWarehouses = new System.Windows.Forms.ToolStripSplitButton();
            this.sandėliaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prekėsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sandėlioZonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tActions = new System.Windows.Forms.ToolStripSplitButton();
            this.veiksmųIstorijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klaidųSąrašasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sep4 = new System.Windows.Forms.ToolStripSeparator();
            this.tConfig = new System.Windows.Forms.ToolStripButton();
            this.lUserInfo = new System.Windows.Forms.Label();
            this.tModuleButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tModuleButtons
            // 
            this.tModuleButtons.AutoSize = false;
            this.tModuleButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.tModuleButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tReceiving,
            this.toolStripSeparator1,
            this.tDistOrders,
            this.toolStripSeparator2,
            this.tWarehouses,
            this.toolStripSeparator3,
            this.tActions,
            this.sep4,
            this.tConfig});
            this.tModuleButtons.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tModuleButtons.Location = new System.Drawing.Point(0, 0);
            this.tModuleButtons.Name = "tModuleButtons";
            this.tModuleButtons.Size = new System.Drawing.Size(104, 645);
            this.tModuleButtons.TabIndex = 0;
            this.tModuleButtons.Text = "toolStrip1";
            // 
            // tReceiving
            // 
            this.tReceiving.AutoSize = false;
            this.tReceiving.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pristatymaiToolStripMenuItem,
            this.priėmimoDokumentaiToolStripMenuItem,
            this.priėmimoUžsakymaiToolStripMenuItem});
            this.tReceiving.Image = ((System.Drawing.Image)(resources.GetObject("tReceiving.Image")));
            this.tReceiving.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tReceiving.Name = "tReceiving";
            this.tReceiving.Size = new System.Drawing.Size(90, 90);
            this.tReceiving.Text = "Priėmimas";
            this.tReceiving.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // pristatymaiToolStripMenuItem
            // 
            this.pristatymaiToolStripMenuItem.Name = "pristatymaiToolStripMenuItem";
            this.pristatymaiToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.pristatymaiToolStripMenuItem.Text = "Pristatymai";
            this.pristatymaiToolStripMenuItem.Click += new System.EventHandler(this.pristatymaiToolStripMenuItem_Click);
            // 
            // priėmimoDokumentaiToolStripMenuItem
            // 
            this.priėmimoDokumentaiToolStripMenuItem.Name = "priėmimoDokumentaiToolStripMenuItem";
            this.priėmimoDokumentaiToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.priėmimoDokumentaiToolStripMenuItem.Text = "Priėmimo dokumentai";
            this.priėmimoDokumentaiToolStripMenuItem.Click += new System.EventHandler(this.priėmimoDokumentaiToolStripMenuItem_Click);
            // 
            // priėmimoUžsakymaiToolStripMenuItem
            // 
            this.priėmimoUžsakymaiToolStripMenuItem.Name = "priėmimoUžsakymaiToolStripMenuItem";
            this.priėmimoUžsakymaiToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.priėmimoUžsakymaiToolStripMenuItem.Text = "Priėmimo užsakymai";
            this.priėmimoUžsakymaiToolStripMenuItem.Click += new System.EventHandler(this.priėmimoUžsakymaiToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(102, 6);
            // 
            // tDistOrders
            // 
            this.tDistOrders.AutoSize = false;
            this.tDistOrders.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.išsiuntimoUžsakymaiToolStripMenuItem,
            this.siuntosToolStripMenuItem,
            this.rūšiavimasToolStripMenuItem,
            this.surinkimasToolStripMenuItem});
            this.tDistOrders.Image = ((System.Drawing.Image)(resources.GetObject("tDistOrders.Image")));
            this.tDistOrders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tDistOrders.Name = "tDistOrders";
            this.tDistOrders.Size = new System.Drawing.Size(90, 90);
            this.tDistOrders.Text = "Išsiuntimas";
            this.tDistOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // išsiuntimoUžsakymaiToolStripMenuItem
            // 
            this.išsiuntimoUžsakymaiToolStripMenuItem.Name = "išsiuntimoUžsakymaiToolStripMenuItem";
            this.išsiuntimoUžsakymaiToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.išsiuntimoUžsakymaiToolStripMenuItem.Text = "Išsiuntimo užsakymai";
            // 
            // siuntosToolStripMenuItem
            // 
            this.siuntosToolStripMenuItem.Name = "siuntosToolStripMenuItem";
            this.siuntosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.siuntosToolStripMenuItem.Text = "Siuntos";
            // 
            // rūšiavimasToolStripMenuItem
            // 
            this.rūšiavimasToolStripMenuItem.Name = "rūšiavimasToolStripMenuItem";
            this.rūšiavimasToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.rūšiavimasToolStripMenuItem.Text = "Rūšiavimas";
            // 
            // surinkimasToolStripMenuItem
            // 
            this.surinkimasToolStripMenuItem.Name = "surinkimasToolStripMenuItem";
            this.surinkimasToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.surinkimasToolStripMenuItem.Text = "Surinkimas";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(102, 6);
            // 
            // tWarehouses
            // 
            this.tWarehouses.AutoSize = false;
            this.tWarehouses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sandėliaiToolStripMenuItem,
            this.prekėsToolStripMenuItem,
            this.sandėlioZonosToolStripMenuItem});
            this.tWarehouses.Image = ((System.Drawing.Image)(resources.GetObject("tWarehouses.Image")));
            this.tWarehouses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tWarehouses.Name = "tWarehouses";
            this.tWarehouses.Size = new System.Drawing.Size(90, 90);
            this.tWarehouses.Text = "Sandėliai";
            this.tWarehouses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // sandėliaiToolStripMenuItem
            // 
            this.sandėliaiToolStripMenuItem.Name = "sandėliaiToolStripMenuItem";
            this.sandėliaiToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sandėliaiToolStripMenuItem.Text = "Sandėliai";
            this.sandėliaiToolStripMenuItem.Click += new System.EventHandler(this.sandėliaiToolStripMenuItem_Click);
            // 
            // prekėsToolStripMenuItem
            // 
            this.prekėsToolStripMenuItem.Name = "prekėsToolStripMenuItem";
            this.prekėsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.prekėsToolStripMenuItem.Text = "Prekės";
            this.prekėsToolStripMenuItem.Click += new System.EventHandler(this.prekėsToolStripMenuItem_Click);
            // 
            // sandėlioZonosToolStripMenuItem
            // 
            this.sandėlioZonosToolStripMenuItem.Name = "sandėlioZonosToolStripMenuItem";
            this.sandėlioZonosToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.sandėlioZonosToolStripMenuItem.Text = "Sandėlio zonos";
            this.sandėlioZonosToolStripMenuItem.Click += new System.EventHandler(this.sandėlioZonosToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(102, 6);
            // 
            // tActions
            // 
            this.tActions.AutoSize = false;
            this.tActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.veiksmųIstorijaToolStripMenuItem,
            this.klaidųSąrašasToolStripMenuItem});
            this.tActions.Image = ((System.Drawing.Image)(resources.GetObject("tActions.Image")));
            this.tActions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tActions.Name = "tActions";
            this.tActions.Size = new System.Drawing.Size(90, 90);
            this.tActions.Text = "Veiksmai";
            this.tActions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // veiksmųIstorijaToolStripMenuItem
            // 
            this.veiksmųIstorijaToolStripMenuItem.Name = "veiksmųIstorijaToolStripMenuItem";
            this.veiksmųIstorijaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.veiksmųIstorijaToolStripMenuItem.Text = "Veiksmų istorija";
            this.veiksmųIstorijaToolStripMenuItem.Click += new System.EventHandler(this.veiksmųIstorijaToolStripMenuItem_Click);
            // 
            // klaidųSąrašasToolStripMenuItem
            // 
            this.klaidųSąrašasToolStripMenuItem.Name = "klaidųSąrašasToolStripMenuItem";
            this.klaidųSąrašasToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.klaidųSąrašasToolStripMenuItem.Text = "Klaidų sąrašas";
            // 
            // sep4
            // 
            this.sep4.Name = "sep4";
            this.sep4.Size = new System.Drawing.Size(102, 6);
            // 
            // tConfig
            // 
            this.tConfig.AutoSize = false;
            this.tConfig.Image = ((System.Drawing.Image)(resources.GetObject("tConfig.Image")));
            this.tConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tConfig.Name = "tConfig";
            this.tConfig.Size = new System.Drawing.Size(90, 90);
            this.tConfig.Text = "Nustatymai";
            this.tConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tConfig.Click += new System.EventHandler(this.tConfig_Click);
            // 
            // lUserInfo
            // 
            this.lUserInfo.AutoSize = true;
            this.lUserInfo.Location = new System.Drawing.Point(2, 507);
            this.lUserInfo.Name = "lUserInfo";
            this.lUserInfo.Size = new System.Drawing.Size(102, 13);
            this.lUserInfo.TabIndex = 4;
            this.lUserInfo.Text = "Vartotojo informacija";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 645);
            this.Controls.Add(this.lUserInfo);
            this.Controls.Add(this.tModuleButtons);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tModuleButtons.ResumeLayout(false);
            this.tModuleButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tModuleButtons;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton tReceiving;
        private System.Windows.Forms.ToolStripSplitButton tDistOrders;
        private System.Windows.Forms.ToolStripSplitButton tWarehouses;
        private System.Windows.Forms.ToolStripSplitButton tActions;
        private System.Windows.Forms.ToolStripMenuItem priėmimoUžsakymaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pristatymaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem išsiuntimoUžsakymaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siuntosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rūšiavimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surinkimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sandėliaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prekėsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sandėlioZonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veiksmųIstorijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sep4;
        private System.Windows.Forms.ToolStripButton tConfig;
        private System.Windows.Forms.ToolStripMenuItem klaidųSąrašasToolStripMenuItem;
        private System.Windows.Forms.Label lUserInfo;
        private System.Windows.Forms.ToolStripMenuItem priėmimoDokumentaiToolStripMenuItem;
    }
}