using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapi.Controllers;


namespace webapi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new DriversController();
            var driver = controller.Get();


        }


    }
}
