using CoreAutomationGeneration.DBConnections.DataAccess;
using NUnit.Framework;
using System;

namespace CoreAutomationGeneration.BusinessObjects
{
    /// <summary>
    /// CustomerBO
    /// </summary>
    public class CustomerBO
    {
        [Test]
        public void ExecuteTestCustomerBO()
        {
            Console.WriteLine("Execution");
            //var customers = CustomerAccess.GetCustomersInfoFromDB();
            //CustomerAccess.GetMappedCustomersInfoFromDB();
            //CustomerAccess.InsertNewCustomer(7, "Adrian", "Perez", "(331)-123456", "adrian.perez@gmail.com");
        }
    }
}
