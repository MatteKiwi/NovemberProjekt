using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovemberProjekt
{
    class Pokemon
    {
        //Variabler för pokemonen, dess namn, dess olika types och dess liv. Detta används i program.cs senare
        public string name;
        public TypeSlot[] types;
        private int hp = 100;
        //Enkel metod för att visa pokemon HP vilket är 100
        public int GetHp()
        {
            int x = hp;
            return x;
        }
        //generara en random nummer från 1-25 för lightAttack, det är hur mycket skada light attack kommer att göra.
        public int LightAttack()
        {
            int i = Utils.gen.Next(1, 25);
            return i;
        }
        //metod för heavyattack den gör så att det är svårt att träffa men skadar väldigt mycket. Den har Pokemon pokemon som referens så att man kan få fram vilken pokemon som träffa/missa
        public int HeavyAttack(Pokemon pokemon)
        {
            int x = Utils.gen.Next(1, 100);

            if (x <= 80)
            {
                int i = 0;
                Console.WriteLine(Utils.ToUpperFirstLetter(pokemon.name) + " Miss!");
                return i;
            }
            else
            {
                int i = 90;
                Console.WriteLine(Utils.ToUpperFirstLetter(pokemon.name) + " Hit");
                return i;
            }
        }
        //Enke metod för att man ska kunna ta skada
        public void Hurt(int amount)
        {
            hp -= amount;
        }
        //Metod som använder sig av en bool för att kolla ifall pokemonen lever eller är död.
        public bool IsAlive()
        {
            if (hp <= 0)
            {
                hp = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        //metod som använder sig av get / set för att ge stringen s med ett "värde" av vilka "types" pokemonen har. Den tar in värde ifrån type tror jag.
        public string Types
        {
            get
            {
                string s = "";
                for (int i = 0; i < types.Length; i++)
                {
                    s += types[i].type.name + " ";
                }

                return s;
            }
            private set
            {

            }
        }
        //Metod som skriver ut namnet på typ/typerna pokemonen har, som man får ifrån api:n.
        public void PrintTypes()
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].type.name);
            }
        }
    }
}
