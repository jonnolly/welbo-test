using System;
using System.Collections.Generic;
using System.IO;
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
            string[] lines = File.ReadAllLines(@"../../Appointments.txt");

            return null;
        }
    }
}
