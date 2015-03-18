/* CMPP248 Part 2 Workshop 2
 * Class for Agent
 * Created By: Leisy Moliner
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
    public class Agent
    {
        //Constructor --------------------------------
        public Agent() { }

        //Properties --------------------------------
        [DisplayName("ID")]
        public int AgentId { get; set; }

        [DisplayName("First Name")]
        public string AgtFirstName { get; set; }

        [DisplayName("Middle Initial")]
        public string AgtMiddleInitial { get; set; }

        [DisplayName("Last Name")]
        public string AgtLastName { get; set; }

        [DisplayName("Phone")]
        public string AgtBusPhone { get; set; }

        [DisplayName("Email")]
        public string AgtEmail { get; set; }

        [DisplayName("Position")]
        public string AgtPosition { get; set; }

        [DisplayName("Agency")]
        public int AgencyId { get; set; }

        [DisplayName("Password")]
        public string AgtPassword { get; set; }

    }
}
