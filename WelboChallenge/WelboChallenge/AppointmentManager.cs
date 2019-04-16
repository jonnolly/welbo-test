using System;
using System.IO;
using System.Linq;

namespace WelboChallenge
{
    public class AppointmentManager
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public static void CheckInAppointment()
        {
            var checkinsPath = @"../../../Checkins.txt";
            string[] lines = File.ReadAllLines(checkinsPath);

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var appointmentPair = GetConfigPair(line);
                int appointmentNumber;
                if (int.TryParse(appointmentPair.Item1, out appointmentNumber))
                {
                    if (appointmentNumber == _currentlyEvaluatedAppointment)
                    {
                        // update existing
                        string dateTime = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ssZ");
                        lines[i] = _currentlyEvaluatedAppointment.ToString() + " " + dateTime;
                    }
                }
            }

            File.WriteAllLines(checkinsPath, lines);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // private 
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static string _settingAppointmentId = "appointmentId";
        private static string _settingVisitorName = "visitorName";
        private static string _settingEmployeeName = "employeeName";
        private static int _currentlyEvaluatedAppointment;

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private static Tuple<string, string> GetConfigPair(string configLine)
        {
            var spaceIndex = configLine.IndexOf(' ');
            var keyString = new string(configLine.Take(spaceIndex).ToArray());
            var valueString = new string(configLine.Skip(spaceIndex + 1).ToArray());

            return new Tuple<string, string>(keyString, valueString);
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
