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
        public static bool GetAppointment(ref string employeeName, string guestName)
        {
            string[] lines = File.ReadAllLines(@"../../../Appointments.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];
                if(lines[i].Contains(guestName))
                {
                    var appointmentIdLine = lines[i - 1];
                    var guestNameLine = lines[i];
                    var employeeNameLine = lines[i + 1];

                    var appointmentKeyValuePair = GetConfigPair(appointmentIdLine);
                    var visitorKeyValuePair = GetConfigPair(guestNameLine);
                    var employeeKeyValuePair = GetConfigPair(employeeNameLine);

                    if (appointmentKeyValuePair.Item1 == _settingAppointmentId && visitorKeyValuePair.Item1 == _settingVisitorName && employeeKeyValuePair.Item1 == _settingEmployeeName)
                    {
                        employeeName = employeeKeyValuePair.Item2;
                        return int.TryParse(appointmentKeyValuePair.Item2, out _currentlyEvaluatedAppointment);
                    }
                }
            }

            return false;
        }

        private static Tuple<string, string> GetConfigPair(string configLine)
        {
            var spaceIndex = configLine.IndexOf(' ');
            var keyString = new string(configLine.Take(spaceIndex).ToArray());
            var valueString = new string(configLine.Skip(spaceIndex + 1).ToArray());

            return new Tuple<string, string>(keyString, valueString);
        }

        public static void CheckInAppointment()
        {

        }

        // private
        private static string _settingAppointmentId = "appointmentId";
        private static string _settingVisitorName = "visitorName";
        private static string _settingEmployeeName = "employeeName";

        private static int _currentlyEvaluatedAppointment;

    }
}
