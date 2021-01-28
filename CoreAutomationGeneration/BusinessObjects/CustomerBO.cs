using CoreAutomationGeneration.DBConnections.DataAccess;
using NUnit.Framework;

namespace CoreAutomationGeneration.BusinessObjects
{
    /// <summary>
    /// CustomerBO
    /// </summary>
    public class CustomerBO
    {
        static void Main(string[] args)
        {
        }

        [Test]
        public void ExecuteTest()
        {
            var customers = CustomerAccess.GetCustomersInfoFromDB();
            //CustomerAccess.GetMappedCustomersInfoFromDB();
            //CustomerAccess.InsertNewCustomer(7, "Adrian", "Perez", "(331)-123456", "adrian.perez@gmail.com");

            //foreach (var customer in customers)
            //{
            //    Console.WriteLine($"{ customer.FullInfo }");
            //}
            //Console.ReadLine();
        }
    }
}
