using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devoldere.NetSpeedTray;

namespace NetSpeedTest
{
    class Test_Observer : INetObserver
    {
        public int i = 0;

        public Test_Observer()
        {
            NetListener.NetRegister(this);
        }

        public void NetUpdate()
        {
            i++;
        }
    }
}
