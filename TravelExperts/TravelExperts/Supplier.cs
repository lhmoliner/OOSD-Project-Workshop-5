/*
 * Travel Experts Project #2 - C#, ASP.NET, SQL Server
 * Class for Suppliers
 * Created By: John Nguyen (Team 3)
 * Created On: December 9, 2004
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{
    // Author: Garina Yadav & John Nguyen
    // Date Created: January 5, 2015
    // Purpose: This console was written to test the "Supplier" class for Workshop 1

    public class Supplier
    {
        public Supplier() { }
        [DisplayName("Supplier ID")]
        public int SupplierId { get; set; }
        [DisplayName("Supplier Name")]
        public string SupName { get; set; }

        public override string ToString()
        {
            return SupName;
        }
    }
}
