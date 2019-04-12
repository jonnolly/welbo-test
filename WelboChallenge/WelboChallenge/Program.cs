using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelboChallenge
{
    public class Program
    {
        /// <summary>
        /// Entry-point for the application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // run the application with a real instance of UserInteraction
            WelboApplication.RunApplication(new UserInteraction());
        }
    }
}
