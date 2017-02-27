namespace Sahira_Hotel_Travel
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaWisataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paketWisataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listPaketWisataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jadwalPaketWisataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingPaketWisataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 56);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(651, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sahira Hotel and Travelling Package";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.hotelToolStripMenuItem,
            this.areaWisataToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // hotelToolStripMenuItem
            // 
            this.hotelToolStripMenuItem.Name = "hotelToolStripMenuItem";
            this.hotelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hotelToolStripMenuItem.Text = "Hotel";
            this.hotelToolStripMenuItem.Click += new System.EventHandler(this.hotelToolStripMenuItem_Click);
            // 
            // areaWisataToolStripMenuItem
            // 
            this.areaWisataToolStripMenuItem.Name = "areaWisataToolStripMenuItem";
            this.areaWisataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.areaWisataToolStripMenuItem.Text = "Area Wisata";
            this.areaWisataToolStripMenuItem.Click += new System.EventHandler(this.areaWisataToolStripMenuItem_Click);
            // 
            // paketWisataToolStripMenuItem
            // 
            this.paketWisataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listPaketWisataToolStripMenuItem,
            this.jadwalPaketWisataToolStripMenuItem});
            this.paketWisataToolStripMenuItem.Name = "paketWisataToolStripMenuItem";
            this.paketWisataToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.paketWisataToolStripMenuItem.Text = "Paket Wisata";
            // 
            // listPaketWisataToolStripMenuItem
            // 
            this.listPaketWisataToolStripMenuItem.Name = "listPaketWisataToolStripMenuItem";
            this.listPaketWisataToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.listPaketWisataToolStripMenuItem.Text = "List Paket Wisata";
            // 
            // jadwalPaketWisataToolStripMenuItem
            // 
            this.jadwalPaketWisataToolStripMenuItem.Name = "jadwalPaketWisataToolStripMenuItem";
            this.jadwalPaketWisataToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.jadwalPaketWisataToolStripMenuItem.Text = "Jadwal Paket Wisata";
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookingPaketWisataToolStripMenuItem,
            this.bookingHotelToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // bookingPaketWisataToolStripMenuItem
            // 
            this.bookingPaketWisataToolStripMenuItem.Name = "bookingPaketWisataToolStripMenuItem";
            this.bookingPaketWisataToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.bookingPaketWisataToolStripMenuItem.Text = "Booking Paket Wisata";
            // 
            // bookingHotelToolStripMenuItem
            // 
            this.bookingHotelToolStripMenuItem.Name = "bookingHotelToolStripMenuItem";
            this.bookingHotelToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.bookingHotelToolStripMenuItem.Text = "Booking Hotel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.paketWisataToolStripMenuItem,
            this.transaksiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(651, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 10);
            this.panel2.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 353);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Master Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaWisataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paketWisataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listPaketWisataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jadwalPaketWisataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingPaketWisataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingHotelToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel2;
    }
}

