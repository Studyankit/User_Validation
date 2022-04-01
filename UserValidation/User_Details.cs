using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserValidation
{
    internal class User_Details
    {

        public string Username
        {
            get { return Username; }
            set
            {
                string pattern = "^[A-Z]{1}[a-z]{2,} ^[A-Z]{1}[a-z]{2,}$";
                if (Regex.IsMatch(value, pattern))
                {
                    Email = value;
                }
                else
                {
                    Console.WriteLine("Invalid username");
                }
            }
        }
        public string Password
        {
            get { return Password; }
            set
            {
                string pattern = "^(?=.*?[0-9])(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[@#$&*.!?]).{8,}";
                if (Regex.IsMatch(value, pattern))
                {
                    Email = value;
                }
                else
                {
                    Console.WriteLine("Invalid pattern");
                }
            }
        }
        public string Name { get; set; }
        public string Email
        {
            get { return Email; }
            set
            {
                string pattern = " ^[0-9a-zA-Z]+[.+-_]{0,1}[0-9a-zA-Z]+([@]cstech.in)$";
                if (Regex.IsMatch(value, pattern))
                {
                    Email = value;
                }
                else
                {
                    Console.WriteLine("didn't match" );
                }
            }
        }
            
        public long PhoneNumber { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string Course { get; set; }
        
    }
}
