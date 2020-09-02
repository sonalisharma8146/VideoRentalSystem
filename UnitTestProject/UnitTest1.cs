using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRentalSystem;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //defining an object with in the class Database from VideoRentalSystem
        DatabaseClass Obj_Test = new DatabaseClass();
        [TestMethod]
        public void TestDBConection()
        {
            // Variable of actual and expected connection String 
            var ActualDBCon = Obj_Test.constring;
            var ExpexctedDBCon = @"Data Source=WT135-826LSW\SQLEXPRESS;Initial Catalog=VideoRentalDB;Integrated Security=True";
            //Assert - checking the output is which expected
            Assert.AreEqual(ExpexctedDBCon, ActualDBCon);
        }

        [TestMethod]
        public void RentCostUnitTest()
        {
            // Variable of actual and expected connection String 
            var Actualvalue = Obj_Test.rentCost(0,"2019");
            var Expexctedvalue = 5;
            //Assert - checking the output is which expected
            Assert.AreEqual(Expexctedvalue, Actualvalue);
        }
    }
}