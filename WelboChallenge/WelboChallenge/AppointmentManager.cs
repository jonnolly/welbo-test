using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WelboChallenge
{
    public class AppointmentManager
    {
        // Assume that the structure is
        // with each appointment starting with "appointmentId" and containing any number of
        // visitorName and employeeName with any arrangement

        // Appointment 1
        // appointmentId 1
        // visitorName Guest One
        // employeeName Host One
        // employeeName Host Wwo
        // visitorName Guest Two
        public static bool GetAppointment(ref string employeeName, string guestName)
        {
            string[] lines = File.ReadAllLines(@"../../../Appointments.txt");
            // every time we have an appointmentId, go down until the next appointmentId or the end

            for (int i = 0; i < lines.Length; i++)
            {
                if(lines[i].Contains(guestName))
                {



                    return true;
                }
                // check line contains visitorName
                // if so, create appointment and store in _currentlyEvaluatedAppointment
                // check previous line & next line that they match appointmentId & employeeName.
                // if so, create new currentlyEveluatedAppointment and return employeeName
            }

            return false;
        }

        public static void CheckInAppointment()
        {
            // check in appointment
            // null _currentlyEvaluatedAppointment
        }

        //private static KeyValuePair<string, string> GetKeyValuePairFromConfigLine(string configLine)
        //{
        //    var spaceIndex = configLine.IndexOf(' ') + 1;
        //    var keyString = new string(configLine.Take(spaceIndex).ToArray());
        //    var valueString = new string(configLine.Skip(configLine.IndexOf(' ') + 1).ToArray());

        //    return new KeyValuePair<string, string>(keyString, valueString);
        //}

        // private
        private static string _settingAppointmentId = "appointmentId";
        private static string _settingVisitorName = "visitorName";
        private static string _settingEmployeeName = "employeeName";

        private static int _currentlyEvaluatedAppointment;

    }
}
