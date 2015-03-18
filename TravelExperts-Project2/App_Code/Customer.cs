/* CPRG214 Project 2 Website
 * Created/Modified By: John, Leisy and MB
 * February 2, 2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelExperts
{
    public class Customer
    {
        //constructor
        public Customer() { }

        //public properties
        public int CustomerID { get; set; }

        public string CustFirstName { get; set; }

        public string CustLastName { get; set; }

        public string CustAddress { get; set; }

        public string CustCity { get; set; }

        public string CustProv { get; set; }

        public string CustPostal { get; set; }

        public string CustCountry { get; set; }

        public string CustHomePhone { get; set; }

        public string CustBusPhone { get; set; }

        public string CustEmail { get; set; }

        public int AgentId { get; set; }

        public string CustPassword { get; set; }

    }
}