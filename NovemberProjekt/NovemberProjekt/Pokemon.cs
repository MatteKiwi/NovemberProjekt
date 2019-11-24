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
