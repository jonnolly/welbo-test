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

            string[] greetingVariations = { "hello", "hi", "howdy" };

            // matches "Ello ello", "ello ello Ello" etc
            // as well as "HELLOO", "hellooooooooooo" etc
            string[] greetingMatchers = { "^ello( ello)*$", "^hello+$" };

            string greeting = "Hello and welcome! Are you here for an appointment?";

            userUnderstanding.ReadUserInput(greeting, greetingVariations, greetingMatchers);


        }
    }
}
