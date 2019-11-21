using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace NovemberProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Welcome();
            Console.Clear();
            Console.WriteLine(playerName + "! Welcome" );
            Console.Clear();                  
            Game(playerName);
            Console.ReadLine();
        }

        public static void Game(string playerName)
        {
            var starterPok = PokemonChoice(playerName);
            Console.Clear();
            Console.WriteLine("So " + playerName + " your choice of pokemon was " + Utils.ToUpperFirstLetter(starterPok.name) + " nice one");
            
        }

        public static Pokemon PokemonChoice(string playerName)
        {
            Console.WriteLine(playerName + " please pick a pokemon to fight with!");
            PokemonFactory pokemonFactory = new PokemonFactory();
            List<Pokemon> starterOptions = new List<Pokemon>();
          
            for (int i = 0; i < 3; i++)
            {
                Pokemon p = pokemonFactory.Production();
                starterOptions.Add(p);
                Console.WriteLine("Name: " + Utils.ToUpperFirstLetter(p.name) + " Type: " + Utils.ToUpperFirstLetter(p.Types));                
            }

            while(true)
            {

                if (int.TryParse(Utils.input(), out int index) == true) 
                {
                    Pokemon starter = starterOptions[index - 1];

                    return starter;
                }
                else
                {
                    Console.WriteLine("try agin");
                }              

            }

        }
        //En metod som tar string input ifrån klassen utils och returnar namnet på spelaren
        static string Welcome()
        {
            Console.WriteLine("Hello and welcome to Pokemon fight sim!\nPlease type in a username");
            string name = Utils.input();
            return name;       
        }
       
    }
}
