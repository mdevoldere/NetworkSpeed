namespace Devoldere.NetSpeedTray
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lblSrLbl = new System.Windows.Forms.Label();
            this.lblSrUp = new System.Windows.Forms.Label();
            this.oTimer = new System.Windows.Forms.Timer(this.components);
            this.lblDlLbl = new System.Windows.Forms.Label();
            this.lblDl = new System.Windows.Forms.Label();
            this.lblUl = new System.Windows.Forms.Label();
            this.cbNotify = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.oMenu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInterfaces = new System.Windows.Forms.ToolStripMenuItem();
            this.oNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.oContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSrDown = new System.Windows.Forms.Label();
            this.lblSpeedLbl = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblUlLbl = new System.Windows.Forms.Label();
            this.LblBytesLbl = new System.Windows.Forms.Label();
            this.lblBytesUp = new System.Windows.Forms.Label();
            this.lblBytesDown = new System.Windows.Forms.Label();
            this.oMenu.SuspendLayout();
            this.oContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSrLbl
            // 
            this.lblSrLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblSrLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrLbl.Location = new System.Drawing.Point(3, 98);
            this.lblSrLbl.Name = "lblSrLbl";
            this.lblSrLbl.Size = new System.Drawing.Size(44, 16);
            this.lblSrLbl.TabIndex = 2;
            this.lblSrLbl.Text = "Packets";
            this.lblSrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSrUp
            // 
            this.lblSrUp.BackColor = System.Drawing.SystemColors.Info;
            this.lblSrUp.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSrUp.Location = new System.Drawing.Point(48, 98);
            this.lblSrUp.Name = "lblSrUp";
            this.lblSrUp.Size = new System.Drawing.Size(80, 16);
            this.lblSrUp.TabIndex = 4;
            this.lblSrUp.Text = "0";
            this.lblSrUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // oTimer
            // 
            this.oTimer.Enabled = true;
            this.oTimer.Interval = 1000;
            this.oTimer.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // lblDlLbl
            // 
            this.lblDlLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblDlLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDlLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDlLbl.Location = new System.Drawing.Point(129, 81);
            this.lblDlLbl.Name = "lblDlLbl";
            this.lblDlLbl.Size = new System.Drawing.Size(80, 16);
            this.lblDlLbl.TabIndex = 6;
            this.lblDlLbl.Text = "DL";
            this.lblDlLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDl
            // 
            this.lblDl.BackColor = System.Drawing.SystemColors.Info;
            this.lblDl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDl.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDl.Location = new System.Drawing.Point(129, 132);
            this.lblDl.Name = "lblDl";
            this.lblDl.Size = new System.Drawing.Size(80, 16);
            this.lblDl.TabIndex = 8;
            this.lblDl.Text = "0";
            this.lblDl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUl
            // 
            this.lblUl.BackColor = System.Drawing.SystemColors.Info;
            this.lblUl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUl.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUl.Location = new System.Drawing.Point(48, 132);
            this.lblUl.Name = "lblUl";
            this.lblUl.Size = new System.Drawing.Size(80, 16);
            this.lblUl.TabIndex = 9;
            this.lblUl.Text = "0";
            this.lblUl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbNotify
            // 
            this.cbNotify.AutoSize = true;
            this.cbNotify.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNotify.Location = new System.Drawing.Point(139, 2);
            this.cbNotify.Margin = new System.Windows.Forms.Padding(2);
            this.cbNotify.Name = "cbNotify";
            this.cbNotify.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbNotify.Size = new System.Drawing.Size(59, 19);
            this.cbNotify.TabIndex = 10;
            this.cbNotify.Text = "Notify";
            this.cbNotify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbNotify.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Location = new System.Drawing.Point(4, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(205, 57);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Network";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // oMenu
            // 
            this.oMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuInterfaces});
            this.oMenu.Location = new System.Drawing.Point(0, 0);
            this.oMenu.Name = "oMenu";
            this.oMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.oMenu.Size = new System.Drawing.Size(212, 24);
            this.oMenu.TabIndex = 12;
            this.oMenu.Text = "Menu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReload,
            this.menuExit,
            this.menuAbout});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuReload
            // 
            this.menuReload.Image = global::Devoldere.NetSpeedTray.Properties.Resources.Refresh;
            this.menuReload.Name = "menuReload";
            this.menuReload.Size = new System.Drawing.Size(110, 22);
            this.menuReload.Text = "Reload";
            this.menuReload.Click += new System.EventHandler(this.ReloadApp);
            // 
            // menuExit
            // 
            this.menuExit.Image = global::Devoldere.NetSpeedTray.Properties.Resources.Close;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(110, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.CloseApp);
            // 
            // menuAbout
            // 
            this.menuAbout.Image = global::Devoldere.NetSpeedTray.Properties.Resources._2bs;
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(110, 22);
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.AboutApp);
            // 
            // menuInterfaces
            // 
            this.menuInterfaces.Name = "menuInterfaces";
            this.menuInterfaces.Size = new System.Drawing.Size(70, 20);
            this.menuInterfaces.Text = "Interfaces";
            // 
            // oNotify
            // 
            this.oNotify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.oNotify.BalloonTipTitle = "Devoldere NetSpeed";
            this.oNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("oNotify.Icon")));
            this.oNotify.Text = "NetSpeedTray";
            this.oNotify.Visible = true;
            this.oNotify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // oContextMenu
            // 
            this.oContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit});
            this.oContextMenu.Name = "contextMenuStrip1";
            this.oContextMenu.Size = new System.Drawing.Size(163, 26);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(162, 22);
            this.Exit.Text = "contextMenuExit";
            // 
            // lblSrDown
            // 
            this.lblSrDown.BackColor = System.Drawing.SystemColors.Info;
            this.lblSrDown.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrDown.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSrDown.Location = new System.Drawing.Point(129, 98);
            this.lblSrDown.Name = "lblSrDown";
            this.lblSrDown.Size = new System.Drawing.Size(80, 16);
            this.lblSrDown.TabIndex = 13;
            this.lblSrDown.Text = "0";
            this.lblSrDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpeedLbl
            // 
            this.lblSpeedLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblSpeedLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedLbl.Location = new System.Drawing.Point(3, 132);
            this.lblSpeedLbl.Name = "lblSpeedLbl";
            this.lblSpeedLbl.Size = new System.Drawing.Size(44, 16);
            this.lblSpeedLbl.TabIndex = 14;
            this.lblSpeedLbl.Text = "Speed";
            this.lblSpeedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpace
            // 
            this.lblSpace.BackColor = System.Drawing.SystemColors.Info;
            this.lblSpace.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpace.Location = new System.Drawing.Point(3, 81);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(44, 16);
            this.lblSpace.TabIndex = 15;
            this.lblSpace.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUlLbl
            // 
            this.lblUlLbl.BackColor = System.Drawing.SystemColors.Info;
            this.lblUlLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUlLbl.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUlLbl.Location = new System.Drawing.Point(48, 81);
            this.lblUlLbl.Name = "lblUlLbl";
            this.lblUlLbl.Size = new System.Drawing.Size(80, 16);
            this.lblUlLbl.TabIndex = 7;
            this.lblUlLbl.Text = "UL";
            this.lblUlLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBytesLbl
            // 
            this.LblBytesLbl.BackColor = System.Drawing.SystemColors.Info;
            this.LblBytesLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBytesLbl.Location = new System.Drawing.Point(3, 115);
            this.LblBytesLbl.Name = "LblBytesLbl";
            this.LblBytesLbl.Size = new System.Drawing.Size(44, 16);
            this.LblBytesLbl.TabIndex = 18;
            this.LblBytesLbl.Text = "Bytes";
            this.LblBytesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBytesUp
            // 
            this.lblBytesUp.BackColor = System.Drawing.SystemColors.Info;
            this.lblBytesUp.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesUp.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblBytesUp.Location = new System.Drawing.Point(48, 115);
            this.lblBytesUp.Name = "lblBytesUp";
            this.lblBytesUp.Size = new System.Drawing.Size(80, 16);
            this.lblBytesUp.TabIndex = 17;
            this.lblBytesUp.Text = "0";
            this.lblBytesUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBytesDown
            // 
            this.lblBytesDown.BackColor = System.Drawing.SystemColors.Info;
            this.lblBytesDown.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesDown.ForeColor = System.Drawing.Color.DarkRed;
            this.lblBytesDown.Location = new System.Drawing.Point(129, 115);
            this.lblBytesDown.Name = "lblBytesDown";
            this.lblBytesDown.Size = new System.Drawing.Size(80, 16);
            this.lblBytesDown.TabIndex = 16;
            this.lblBytesDown.Text = "0";
            this.lblBytesDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 152);
            this.Controls.Add(this.LblBytesLbl);
            this.Controls.Add(this.lblBytesUp);
            this.Controls.Add(this.lblBytesDown);
            this.Controls.Add(this.lblSpace);
            this.Controls.Add(this.lblSpeedLbl);
            this.Controls.Add(this.lblSrDown);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbNotify);
            this.Controls.Add(this.lblUl);
            this.Controls.Add(this.lblDl);
            this.Controls.Add(this.lblUlLbl);
            this.Controls.Add(this.lblDlLbl);
            this.Controls.Add(this.lblSrUp);
            this.Controls.Add(this.lblSrLbl);
            this.Controls.Add(this.oMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Devoldere.NetSpeedTray.Properties.Resources.scroll;
            this.MainMenuStrip = this.oMenu;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devoldere NetSpeed";
            this.TopMost = true;
            this.oMenu.ResumeLayout(false);
            this.oMenu.PerformLayout();
            this.oContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSrLbl;
        private System.Windows.Forms.Label lblSrUp;
        private System.Windows.Forms.Timer oTimer;
        private System.Windows.Forms.Label lblDlLbl;
        private System.Windows.Forms.Label lblDl;
        private System.Windows.Forms.Label lblUl;
        private System.Windows.Forms.CheckBox cbNotify;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.MenuStrip oMenu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuReload;
        private System.Windows.Forms.ToolStripMenuItem menuInterfaces;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.NotifyIcon oNotify;
        private System.Windows.Forms.ContextMenuStrip oContextMenu;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.Label lblSrDown;
        private System.Windows.Forms.Label lblSpeedLbl;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblUlLbl;
        private System.Windows.Forms.Label LblBytesLbl;
        private System.Windows.Forms.Label lblBytesUp;
        private System.Windows.Forms.Label lblBytesDown;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}

