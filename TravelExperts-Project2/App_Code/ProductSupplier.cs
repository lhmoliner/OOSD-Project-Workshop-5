/* CPRG214 Project 2 Website
 * Created/Modified By: MB
 * January 22nd, 2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelExperts
{
    public class ProductSupplier
    {
        //constructor
        public ProductSupplier(){}

        //public properties
        public int ProductSupplierId { get; set; }

        public string ProdName { get; set; }

        public string SupName { get; set; }

        public decimal BasePrice { get; set; }
    }
}
