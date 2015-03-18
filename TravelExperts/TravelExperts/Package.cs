/*
 * Class for Packages
 * Created By: MB Jae Camacho
 * December 9, 2014
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts
{
    public class Package
    {
        // properties
        public int ID { get; set; } //11
        public string Name { get; set; } //max of 50 char
        [DisplayName("Start Date")]
        public DateTime Start_Date { get; set; }
        [DisplayName("End Date")]
        public DateTime End_Date { get; set; }
        public string Description { get; set; }//max of 50 char
        public decimal Base_Price { get; set; } //19.4
        public decimal Agency_Commission { get; set; } //19.4
        public string Products { get; set; }


        private string price;
        public string Price
        {
            get
            {
                price = Base_Price.ToString("c");
                return price;
            }
        }

        private string commission;
        public string Commission
        {
            get
            {
                commission = Agency_Commission.ToString("c");
                return commission;
            }
        }

        //constructors
        public Package() {}

        //methods
        public override string ToString()
        {
            return "\nID: " + ID +
                "\nName: " + Name +
                "\nStart Date: " + Start_Date +
                "\nEnd Date: " + End_Date +
                "\nDescritpion: " + Description +
                "\nBase Price: " + Base_Price.ToString("c") +
                "\nAgency Commission: " + Agency_Commission.ToString("c");
        }
    }
}