/* CPRG214 ASP Workshop 2
 * Created By: John, and MB
 * January 22, 2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelExperts
{
    public class Package
    {
        //constructor
        public Package(){}

        //public properties
        public int PackageID { get; set; }

        public string PkgName { get; set; }

        public DateTime PkgStartDate { get; set; }

        public DateTime PkgEndDate { get; set; }

        public string PkgDesc { get; set; }

        public decimal PkgBasePrice { get; set; }

        public decimal PkgAgencyCommission { get; set; }
    }
}