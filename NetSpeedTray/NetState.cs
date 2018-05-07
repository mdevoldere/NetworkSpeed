using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;

namespace Devoldere.NetSpeedTray
{
    public class NetState
    {
        public string Text
        {
            get;
            protected set;
        }

        public bool Up
        {
            get;
            protected set;
        }

        public Color ForeColor
        {
            get;
            protected set;
        }

        public Bitmap Png
        {
            get;
            protected set;
        }

        public Icon Ico
        {
            get;
            protected set;
        }

        public NetState() : this(false)
        {

        }

        public NetState(bool _isUp)
        {
            SetState(_isUp);
        }

        public NetState(OperationalStatus _oStatus)
        {
            SetState(_oStatus);
        }

        public void SetState(OperationalStatus _oStatus)
        {
            SetState((_oStatus == OperationalStatus.Up));
        }

        public void SetState(bool _isUp)
        {
            Up = _isUp;

            if(Up)
            {
                ForeColor = Color.DarkGreen;
                Ico = Properties.Resources.scroll_up;
                Png = Properties.Resources.scroll_up_png;
                Text = "Up";
            }
            else
            {
                ForeColor = Color.DarkGray;
                Ico = Properties.Resources.scroll_down;
                Png = Properties.Resources.scroll_down_png;
                Text = "Down";
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
