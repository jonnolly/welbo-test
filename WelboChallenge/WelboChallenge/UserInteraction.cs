using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelboChallenge
{
    /// <summary>
    /// Real implementation of user interaction
    /// </summary>
    public class UserInteraction : IUserInteraction
    {
        public string ReadConsoleLine()
        {
            return Console.ReadLine();
        }

        public void WriteConsoleLine(string inputLine)
        {
            Console.WriteLine(inputLine);
        }
    }
}
