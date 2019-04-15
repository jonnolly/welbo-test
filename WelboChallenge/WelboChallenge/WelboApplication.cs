using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelboChallenge
{
    internal class WelboApplication
    {
        public static void RunApplication(IUserInteraction userIteraction)
        {
            var userUnderstanding = new UserUnderstanding(userIteraction);

            string userInput = "";
            string[] greetingVariations = { "hello", "hi", "howdy" };

            // matches "Ello ello", "ello ello Ello" etc
            // as well as "HELLOO", "hellooooooooooo" etc
            string[] greetingMatchers = { "^ello( ello)*$", "^hello+$" };
            if (!userUnderstanding.ReadUserInput(ref userInput, greetingVariations, greetingMatchers))
                return;

            userIteraction.WriteConsoleLine("Hello and welcome! Are you here for an appointment?");
            string[] yesVariations = { "yes", "yup" };
            if (!userUnderstanding.ReadUserInput(ref userInput, yesVariations, null))
                return;

            userIteraction.WriteConsoleLine("Lovely stuff. What is your full name?");
            string[] nameRegex = { "([a-zA-Z]+\\s*\\b){2,}" };
            if (!userUnderstanding.ReadUserInput(ref userInput, null, nameRegex))
                return;

            var appointments = ConfigReader.GetAppointments();
        }
    }
}
