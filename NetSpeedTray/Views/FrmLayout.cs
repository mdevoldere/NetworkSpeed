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
        public static Point P = new Point(5, 30);

        public static UCViewSingle ViewNetInterface { get; private set; } = new UCViewSingle() { Location = P };

        public static UCViewList ViewNetInterfaceList { get; private set; } = new UCViewList() { Location = P };

        public static UCViewMini ViewNetInterfaceMini { get; private set; } = new UCViewMini() { Location = P };

        public static UCViewSingleGraph ViewNetInterfaceGraph { get; private set; } = new UCViewSingleGraph() { Location = P };

        protected static UserControl CurrentView;

        #region INIT
        /// <summary>
        /// Initialize
        /// </summary>
        public FrmLayout()
        {
            InitializeComponent();

            Controls.Add(ViewNetInterface);
            Controls.Add(ViewNetInterfaceList);
            Controls.Add(ViewNetInterfaceMini);
            Controls.Add(ViewNetInterfaceGraph);

            ViewNetInterface.Hide();
            ViewNetInterfaceList.Hide();
            ViewNetInterfaceMini.Hide();
            ViewNetInterfaceGraph.Hide();

            menuViewMini.Tag = new FrmLayoutMini(this);
            menuViewSingle.Tag = ViewNetInterface;
            menuViewList.Tag = ViewNetInterfaceList;
            menuViewChart.Tag = ViewNetInterfaceGraph;

            menuReload.Click += AppEvents.ReloadApp_Click;
            menuAbout.Click += AppEvents.AboutApp_Click;
            menuExit.Click += AppEvents.CloseApp_Click;
            menuReloadNetwork.Click += AppEvents.ReloadNetwork_Click;
            oContextMenuExit.Click += AppEvents.CloseApp_Click;

            menuReloadNetwork.Tag = new ToolStripMenuItem[] { menuNetworks, contextMenuNetworks };

            AppEvents.ReloadNetwork_Click(menuReloadNetwork, new EventArgs());

            oNotify.ContextMenuStrip = oContextMenu;

            MenuViewSelect_Click(menuViewSingle, new EventArgs());
        }

        private void FrmLayout_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region menuView EVENTS
        
        private void MenuViewSelect_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem oItem)
            {
                if(oItem.Tag is UserControl u)
                {
                    if(CurrentView != null)
                    {
                        CurrentView.Hide();
                    }

                    CurrentView = u;
                    CurrentView.Show();
                    Height = (CurrentView.Height + 75);
                    Width = (CurrentView.Width + 30);
                }
            }
        }

        private void MenuViewSelectMini_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem oItem)
            {
                if (oItem.Tag is FrmLayoutMini u)
                {
                    u.Display();
                    contextMenuView.Text = "Switch to Normal Window";
                }
            }
        }

        #endregion

        #region NotifyIcon EVENTS

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                oContextMenu.Show();
                return;
            }

            //this.Visible = !this.Visible;
        }

        private void OContextMenuStartStop_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripItem o)
            {
                o.Enabled = false;

                switch (o.Text)
                {
                    case "Start":
                        NetListener.Start();
                        oContextMenuStop.Enabled = true;
                        break;
                    default:
                        NetListener.Stop();
                        oContextMenuStart.Enabled = true;
                        break;
                }
            }
        }

        private void OContextMenuView_Click(object sender, EventArgs e)
        {
            if(sender is ToolStripItem o)
            {
                if (menuViewMini.Tag is FrmLayoutMini u)
                {
                    switch (o.Text)
                    {
                        case "Switch to Mini Window":
                            u.Display();
                            o.Text = "Switch to Normal Window";
                            break;
                        default:
                            u.GoToLayout();
                            o.Text = "Switch to Mini Window";
                            break;
                    }
                }

                
            }
        }

        #endregion


    }
}
