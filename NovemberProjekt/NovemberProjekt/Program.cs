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
        //en static string som används för att input ska fungerar inom static void game, detsammma gäller för dudUsed
        static string input;
        static bool dudUsed = false;
        static void Main(string[] args)
        {
            string playerName = Welcome(); //får fram playerName genom metoden Welcome()
            Console.Clear();  //tar bort allt ifrån consolen
            Console.WriteLine(playerName + "! Welcome"); //välkomnar spelaren med dess namn
            Console.Clear(); //tar bort allt ifrån consolen
            Game(playerName); //gör metoden game med playerName 
            Console.ReadLine();
        }
        //main metoden där hela spelet finns inom
        public static void Game(string playerName)
        {
            bool gameOver = false; //bool gameOver för while loopen
            var starterPok = PokemonChoice(playerName); //en pokemon som man får ifrån pokemonChoice metoden
            var enemy = PokemonEnemy(); //den man möter kommer ifrån metoden pokemonEnemy
            Console.Clear(); //gör rent
            Console.WriteLine("So " + playerName + " your choice of pokemon was " + Utils.ToUpperFirstLetter(starterPok.name) + " nice one, Your first opponent will be " + Utils.ToUpperFirstLetter(enemy.name));
            Console.WriteLine("Press enter to start");
            while (!gameOver) //while loop som körs till någon dör
            {
                if (!dudUsed) //if sats för att input ska fungera korrekt, används ikoppling med static bool dubUsed som sitter längst upp i program.cs
                {
                    input = "1";
                    dudUsed = true;
                }
                else
                {
                    input = Console.ReadLine();
                }
                //presenterar livet på de båda fint
                Console.Clear();
                Console.WriteLine("        " + Utils.ToUpperFirstLetter(starterPok.name) + " Hp: " + starterPok.GetHp() + " VS " + Utils.ToUpperFirstLetter(enemy.name) + " Hp: " + enemy.GetHp());
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Press 1 to perform a !Light Attack!\nPress 2 to perform a !Heavy Attack! (hard to hit & might inflict dmg upon yourself)");
      
                if (input == "1")
                {
                    //ifall input är 1 så kör båda hurt metoden och lightattack metoden
                    enemy.Hurt(starterPok.LightAttack());
                    starterPok.Hurt(enemy.LightAttack());
                }
                else if (input == "2")
                {
                    //ifall input är 2 så körs heavyattack metoden
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
        //metod för att låta användare välja en pokemon ifrån 3 random skappade
        public static Pokemon PokemonChoice(string playerName)
        {
            Console.WriteLine(playerName + " please pick a pokemon to fight with!");
            PokemonFactory pokemonFactory = new PokemonFactory(); //gör en lista ifrån klassen pokemonfactory
            List<Pokemon> starterOptions = new List<Pokemon>(); //lista för de pokemon man ska välja ifrån
            //for loop som görs 3 gången
            for (int i = 0; i < 3; i++)
            {
                Pokemon p = pokemonFactory.Production(); //skappar 3 instanser av pokemon
                starterOptions.Add(p); //lägger till de 3st i starterOptions listan
                Console.WriteLine("Name: " + Utils.ToUpperFirstLetter(p.name) + " Type: " + Utils.ToUpperFirstLetter(p.Types)); //skriver ut de 3 pokemonens namn och type i stor bokstav
            }
            //en while true loop som låter använder välja mellan de 3 st pokemons
            while (true)
            {
                Console.WriteLine("Press 1-3 to select pokemon");
                string input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3") //om input är 1-3 
                {
                    int.TryParse(input, out int index); //tryparsar input ut till index
                    Pokemon starter = starterOptions[index - 1]; //pokemon starter är index - 1 på starteroptions listan
                    return starter; //returnar den man har valt
                }
                else
                {
                    Console.WriteLine("Try again"); //fel medellande ifall man inte gav korrekt input
                }
            }
        }
        //en static pokemon som skappar en pokemon enemy genom att använda sig av Production metoden ifrån pokemonfactory klassen
        public static Pokemon PokemonEnemy()
        {
            PokemonFactory pokemonFactory = new PokemonFactory();
            Pokemon enemy = pokemonFactory.Production();
            return enemy;
        }
        //En metod som tar string input ifrån klassen utils och returnar namnet på spelaren, den kallas sedan på i main
        static string Welcome()
        {
            Console.WriteLine("Hello and welcome to Pokemon fight sim!\nPlease type in a username");
            string name = Utils.input();
            return name;
        }
    }
}
