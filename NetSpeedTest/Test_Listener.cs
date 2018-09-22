using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Devoldere.NetSpeedTray;


namespace NetSpeedTest
{
    /// <summary>
    /// Required: at least 1 up network interface 
    /// </summary>
    [TestClass]
    public class Test_Listener
    {

        private Test_Observer obs = new Test_Observer();

        private NetAdapter CurrentInterface;
        
        [TestMethod]
        public void GetInterfaces_Test()
        {
            NetListener.AdapterList.GetFirstUpInterface();

            CurrentInterface = NetListener.AdapterList.SelectedItem;

            Assert.IsNotNull(CurrentInterface);

            NetListener.Start();

            Assert.IsTrue(CurrentInterface.State.Up);

            Assert.AreEqual(CurrentInterface.State.Text, "Up");
        }
    }
}
