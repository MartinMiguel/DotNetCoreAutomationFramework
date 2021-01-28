using System.ComponentModel;

namespace CoreAutomationGeneration.DataConnections.DataModels
{
    /// <summary>
    /// Customer data model
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// The customer id
        /// </summary>
        [Description("customer_id")]
        public int CustomerID { get; set; }

        /// <summary>
        /// The first name
        /// </summary>
        [Description("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name
        /// </summary>
        [Description("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        [Description("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// The email address
        /// </summary>
        [Description("email_address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The full info
        /// </summary>
        [Description("FullInfo")]
        public string FullInfo
        {
            get
            {
                return $"{CustomerID} {FirstName} {LastName} ({Phone}) ({EmailAddress}))";
            }
        }
    }
}
