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
            PokemonChoice(playerName);           
            Console.ReadLine();
        }

        public void Game()
        {

        }

        public static void PokemonChoice(string playerName)
        {
            Console.WriteLine(playerName + " please pick a pokemon to fight with!");
            PokemonFactory pokemonFactory = new PokemonFactory();
          
            for (int i = 0; i < 3; i++)
            {
                Pokemon p = pokemonFactory.Production();

                Console.WriteLine("Name: " + Utils.ToUpperFirstLetter(p.name) + " Type: " + Utils.ToUpperFirstLetter(p.Types));
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
