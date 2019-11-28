using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Threading;

namespace NovemberProjekt
{
    class Program
    {
        static string input;
        static bool dudUsed = false;
        static void Main(string[] args)
        {
            string playerName = Welcome();
            Console.Clear();
            Console.WriteLine(playerName + "! Welcome");
            Console.Clear();
            Game(playerName);
            Console.ReadLine();
        }

        public static void Game(string playerName)
        {
            bool gameOver = false;
            var starterPok = PokemonChoice(playerName);
            var enemy = PokemonEnemy();
            Console.Clear();
            Console.WriteLine("So " + playerName + " your choice of pokemon was " + Utils.ToUpperFirstLetter(starterPok.name) + " nice one, Your first opponent will be " + Utils.ToUpperFirstLetter(enemy.name));
            Console.WriteLine("Press enter to start");
            while (!gameOver)
            {
                if (!dudUsed)
                {
                    input = "69";
                    dudUsed = true;
                }
                else
                {
                    input = Console.ReadLine();
                }
                
                Console.Clear();
                Console.WriteLine("        " + Utils.ToUpperFirstLetter(starterPok.name) + " Hp: " + starterPok.GetHp() + " VS " + Utils.ToUpperFirstLetter(enemy.name) + " Hp: " + enemy.GetHp());
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Press 1 to perform a !Light Attack!\nPress 2 to perform a !Heavy Attack! (hard to hit)");
               // string input = Console.ReadLine();
                if (input == "1")
                {
                    //b tar skade av a attack och tvärtom för a
                    enemy.Hurt(starterPok.LightAttack());
                    starterPok.Hurt(enemy.LightAttack());
                }
                else if (input == "2")
                {
                    enemy.Hurt(starterPok.HeavyAttack(starterPok));
                    starterPok.Hurt(enemy.HeavyAttack(enemy));
                }
                //if sats som kollar ifall dom lever och visar då vem som vann
                if (starterPok.IsAlive() == true)
                {
                    Console.WriteLine(Utils.ToUpperFirstLetter(enemy.name) + " Won !");
                    Console.ReadLine();
                    gameOver = true;
                }
                else if (enemy.IsAlive() == true)
                {
                    Console.WriteLine(Utils.ToUpperFirstLetter(starterPok.name) + " and you Won !");
                    Console.ReadLine();
                    gameOver = true;
                }


            }
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

            while (true)
            {
                Console.WriteLine("Press 1-3 to select pokemon");
                string input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    int.TryParse(input, out int index);
                    Pokemon starter = starterOptions[index - 1];
                    return starter;
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
        }
        public static Pokemon PokemonEnemy()
        {
            PokemonFactory pokemonFactory = new PokemonFactory();
            Pokemon enemy = pokemonFactory.Production();
            return enemy;
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
