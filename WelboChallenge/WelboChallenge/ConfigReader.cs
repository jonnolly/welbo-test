using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WelboChallenge
{
    public class ConfigReader
    {
        public static List<Appointment> GetAppointments()
        {
            string regexMatch = "(a-zA-Z) (\\d)";
            var test = Regex.IsMatch("numberOfAppointments 3", regexMatch);


            return null;
        }
    }
}
