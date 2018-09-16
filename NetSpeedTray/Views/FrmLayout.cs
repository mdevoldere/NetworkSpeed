using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class FrmLayout : Form
    {
        static Point p = new Point(5, 30);

        #region INIT
        /// <summary>
        /// Initialize
        /// </summary>
        public FrmLayout()
        {
            InitializeComponent();

            menuReload.Click += MenuEvents.ReloadApp_Click;
            menuAbout.Click += MenuEvents.AboutApp_Click;
            menuExit.Click += MenuEvents.CloseApp_Click;
            menuReloadNetwork.Click += MenuEvents.ReloadNetwork_Click;
            oContextMenuExit.Click += MenuEvents.CloseApp_Click;
        }

        private void FrmLayout_Load(object sender, EventArgs e)
        {
            menuReloadNetwork.Tag = new ToolStripMenuItem[] { menuNetworks, contextMenuNetworks };

            MenuEvents.ReloadNetwork_Click(menuReloadNetwork, new EventArgs());

            oNotify.ContextMenuStrip = oContextMenu;

            MenuEvents.BindViews(this, p);

            MenuViewSingle_Click(menuViewSingle, e);
        }

        #endregion

        #region EVENTS
        
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        { 
            if(e.Button == MouseButtons.Right)
            {
                oContextMenu.Show();
                return;
            }

            this.Visible = !this.Visible;
         }


        private void SetSize(UserControl uc)
        {
            Height = (uc.Height + 75);
            Width = (uc.Width + 30);
        }

        private void MenuViewSingle_Click(object sender, EventArgs e)
        {
            MenuEvents.ViewSingle();
            SetSize(MenuEvents.ViewNetInterface);
        }

        private void MenuViewList_Click(object sender, EventArgs e)
        {
            MenuEvents.ViewList();
            SetSize(MenuEvents.ViewNetInterfaceList);
        }

        private void FrmLayout_FormClosing(object sender, FormClosingEventArgs e)
        {
            oNotify.Visible = false;
        }

        #endregion
                
    }
}
