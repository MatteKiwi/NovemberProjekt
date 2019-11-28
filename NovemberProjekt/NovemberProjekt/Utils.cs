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
        //Taget ifrån stackoverflow men fungerar genom att ta in en string och sedan konverta den till en char array och därefter kapitalisera första char eller då bokstaven, sedan returnar den, den nya stringen.
        public static string ToUpperFirstLetter(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;
            //gör om stringen till char array
            char[] letters = name.ToCharArray();
            //kapitaliserar första char
            letters[0] = char.ToUpper(letters[0]);
            //retunernar then arrayen som var gjort av den nya char arrayen
            return new string(letters);
        }

    }
}
