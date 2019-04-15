using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelboChallenge
{
    internal class WelboApplication
    {
        public static void RunApplication(IUserInteraction userInteraction)
        {
            var userUnderstanding = new UserUnderstanding(userInteraction);

            string userInput = "";
            string[] greetingVariations = { "hello", "hi", "howdy" };

            // matches "Ello ello", "ello ello Ello" etc
            // as well as "HELLOO", "hellooooooooooo" etc
            string[] greetingMatchers = { "^ello( ello)*$", "^hello+$" };
            if (!userUnderstanding.ReadUserInput(ref userInput, greetingVariations, greetingMatchers))
                return;

            userInteraction.WriteConsoleLine("Hello and welcome! Are you here for an appointment?");
            string[] yesVariations = { "yes", "yup" };
            if (!userUnderstanding.ReadUserInput(ref userInput, yesVariations, null))
                return;

            string guestName = "";
            userInteraction.WriteConsoleLine("Lovely stuff. What is your full name?");
            string[] nameRegex = { "([a-zA-Z]+\\s*\\b){2,}" };
            if (!userUnderstanding.ReadUserInput(ref guestName, null, nameRegex))
                return;

            string employeeName = "";
            if(AppointmentManager.GetAppointment(ref employeeName, guestName))
            {
                userInteraction.WriteConsoleLine("You have an appointment with " + employeeName + ".\n Would you like to check in for this appointment?");
                if (userUnderstanding.ReadUserInput(ref userInput, yesVariations))
                {
                    AppointmentManager.CheckInAppointment();
                    userInteraction.WriteConsoleLine("You're all checked in! Please take a seat.");
                }
            }
            else
            {
                userInteraction.WriteConsoleLine("I'm afraid you don't have an appointment in the system.");
            }
        }
    }
}
