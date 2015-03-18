/* CPRG214 Project 2 Website
 * Created/Modified By: John and MB
 * January 22nd, 2015
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

        public string BookingNo { get; set; }

        public DateTime BookingDate { get; set; }
    }
}