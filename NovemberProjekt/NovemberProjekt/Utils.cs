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

        public static string ToUpperFirstLetter(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;
            // convert to char array of the string
            char[] letters = name.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }

        //ett försök på en tryparse.
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
