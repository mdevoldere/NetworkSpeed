using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Devoldere.NetSpeedTray.Views
{
    public class AppEvents
    {
        private static StringBuilder sb;

        #region MenuNetworks

        public static void ReloadNetwork_Click(object sender, EventArgs e)
        {
            if(sender is ToolStripItem oItem)
            {
                ToolStripMenuItem[] oMenus = (oItem.Tag as ToolStripMenuItem[]);

                if (oMenus != null)
                {
                    NetListener.Stop();

                    NetListener.AdapterList.UpdateList();

                    foreach (ToolStripMenuItem oMenu in oMenus)
                    {
                        SetMenuInterfaces(oMenu);
                    }

                    NetListener.AdapterList.GetFirstUpInterface();

                    NetListener.Start();
                }
            }
        }

        public static void SetMenuInterfaces(ToolStripMenuItem m)
        {
            m.DropDownItems.Clear();

            foreach (NetAdapter ni in NetListener.AdapterList)
            {
                ToolStripMenuItem oItem = new ToolStripMenuItem(ni.Name)
                {
                    ForeColor = ni.State.ForeColor,
                    Tag = ni.Id,
                    Image = ni.State.Png,
                };

                oItem.Click += SelectInterface_Click;

                m.DropDownItems.Add(oItem);
            }

            m.Text = NetListener.AdapterList.ToString();
        }

        /// <summary>
        /// MenuClick : Select an interface
        /// </summary>
        /// <param name="sender">a ToolStripMenuItem</param>
        /// <param name="e">EventArgs</param>
        public static void SelectInterface_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripItem oItem)
                {
                    NetListener.AdapterList.GetInterface((int)oItem.Tag);
                }
            }
            catch
            {
            } 
        }

        #endregion

        #region MenuFile

        public static void ReloadApp_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public static void CloseApp_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public static void AboutApp_Click(object sender, EventArgs e)
        {
            if (sb == null)
            {
                sb = new StringBuilder(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name).Append(" ");
                sb.Append(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
                sb.Append(" (").Append(Properties.Settings.Default.PublishDate).Append(")\r");
                sb.Append(Properties.Settings.Default.Author).Append("\r");
                sb.Append(Properties.Settings.Default.Url).Append("\r\r");
                sb.Append("Do you wish to visit ").Append(Properties.Settings.Default.UrlLabel).Append(" ?");
            }

            DialogResult mResult = MessageBox.Show
            (
                sb.ToString(),
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Name,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.None
             );

            if (mResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.Url);
            }
        }

        #endregion
    }
}
