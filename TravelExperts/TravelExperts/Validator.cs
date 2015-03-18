/* CMPP248 Part 2 Workshop 2
 * Class for Packages
 * Created by: MB, Leisy, and John
 * January 12, 2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    public static class Validator
    {
        private static string title = "Entry Error";
        //The title that will appear in dialog boxes.
        public static string Title
        {
            get { return title; }
            set { title = value; }
        }
        //Checks whether the user entered data into a text box.
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }

            return true;
        }

        //check if the string is an int
        public static bool inputIsInteger(string input, out string msg)
        {
            int value;
            msg = "";
            if (int.TryParse(input, out value))
            { //input is an integer
                return true;
            }
            //input is not an integer
            msg = "Please use whole numbers";
            return false;
        }
        //check if  min <= input <= max
        public static bool inputRangeIsValid(int input, int min, int max, out string msg)
        {
            if (input >= min && input <= max) //input is in range
            {
                msg = "";
                return true;
            }
            //input is out of range
            msg = "Please use numbers between "+min +" and "+ max;
            return false;
        }
        //checks if string is not empty
        public static bool notEmpty(TextBox txtBox, out string msg)
        {
            string input = txtBox.Text;

            if (input.Length != 0 && input.Trim().Length != 0)//input is not empty
            {
                msg = "";
                return true;
            }
            //input is empty
            msg = "Empty Field";
            txtBox.Focus();
            txtBox.SelectAll();
            return false;
        }
        //check if positive
        public static bool inputIsPositive(TextBox txtBox, out string msg)
        {
            string input = txtBox.Text;
            decimal value;
            if (decimal.TryParse(input, out value))//input is greater than 0
            {
                msg = "";
                return true;
            }
            //input is negative
            msg = "Input is Negative";
            txtBox.Focus();
            txtBox.SelectAll();
            return false;
        }
        //check if the string is decimal
        public static bool InputIsDecimal(TextBox txtBox, out string msg)
        {
            string input = txtBox.Text;
            decimal value;
            msg = "";
            if (decimal.TryParse(input, out value))
            { //input is decimal
                return true;
            }
            //input is not decimal
            msg = "Not Decimal";
            txtBox.Focus();
            txtBox.SelectAll();
            return false;
        }
        //check if  min <= input <= max
        public static bool inputRangeIsValid(TextBox txtBox, decimal min, decimal max, out string msg)
        {
            decimal input = Convert.ToDecimal(txtBox.Text);

            if (input >= min && input <= max) //input is in range
            {
                msg = "";
                return true;
            }
            //input is out of range
            msg = "Please use numbers " + min + " to " + max;
            txtBox.Focus();
            txtBox.SelectAll();
            return false;
        }
        public static bool DateIsValid(DateTimePicker dtpBox, out string msg)
        {
            DateTime date = dtpBox.Value;
            if (DateTime.Compare(date, DateTime.Now) > 0)
            {
                msg = "";
                return true;
            }
            msg = "Please use dates after today";
            dtpBox.Focus();
            return false;
        }
        public static bool StartAndEndDateIsValid(DateTimePicker startDate, DateTimePicker endDate, out string msg)
        {
            if (DateTime.Compare(endDate.Value, startDate.Value) > 0)
            {
                msg = "";
                return true;
            }
            msg = "Start Date is Later than End Date";
            startDate.Focus();
            return false;
        }
    }
}
