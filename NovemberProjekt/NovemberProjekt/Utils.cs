using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovemberProjekt
{
    class Utils
    {
        //En random generator som jag kan nå överallt inom programmet
        public static Random gen = new Random();
        //En string input
        public static string input()
        {
            string input = Console.ReadLine();
            return input;
        }

        public static int TryParse()
        {

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int i))
                {                  
                    return i;                    
                }
                else
                {
                    Console.WriteLine("Wrong");
                }
            }
        }
    }
}
