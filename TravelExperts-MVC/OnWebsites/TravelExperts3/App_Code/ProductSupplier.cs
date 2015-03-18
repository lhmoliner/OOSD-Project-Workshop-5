using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductSupplier
/// </summary>
/// 
namespace TravelExperts
{
    public class ProductSupplier
    {
        //constructor
        public ProductSupplier() { }

        //public properties
        public int ProductSupplierId { get; set; }

        public string ProdName { get; set; }

        public string SupName { get; set; }

        public decimal BasePrice { get; set; }
    }
}
