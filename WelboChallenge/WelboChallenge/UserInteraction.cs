using System;

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
