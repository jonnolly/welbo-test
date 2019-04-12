using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelboChallenge
{
    public interface IUserInteraction
    {
        string ReadConsoleLine();

        void WriteConsoleLine(string inputLine);
    }
}
