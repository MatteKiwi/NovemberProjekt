using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovemberProjekt
{
    class Pokemon
    {
        public string name;
        public int base_experience;
        public int weight;

        public TypeSlot[] types;

        private int hp = 100;
        public int GetHp()
        {
            int x = hp;

            return x;
        }

        //generara en random nummer för attack
        public int LightAttack()
        {
            int i = Utils.gen.Next(1, 25);
            return i;
        }
        //20 % chans att man kan få in en heavyattack som skadar 90
        public int HeavyAttack(Pokemon pokemon)
        {
            int x = Utils.gen.Next(1, 100);

            if (x <= 80)
            {
                int i = 0;
                Console.WriteLine(pokemon.name + " Miss!");
                return i;
            }
            else
            {
                int i = 90;
                Console.WriteLine(pokemon.name + " Hit");
                return i;
            }
        }

        public void Hurt(int amount)
        {
            hp -= amount;
        }

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

        public void PrintTypes()
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].type.name);
            }
        }
    }
}
