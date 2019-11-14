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
            RestClient client = new RestClient("https://pokeapi.co/api/v2/");
            RestRequest request = new RestRequest("pokemon/804");
            IRestResponse response = client.Get(request);
            Pokemon p = JsonConvert.DeserializeObject<Pokemon>(response.Content);
            //Console.WriteLine(p.types[0].type.name);
            //Console.WriteLine(response.Content);
            Console.WriteLine(p.name + " " + p.weight + " " + p.base_experience);
            Console.WriteLine(p.Types);
            // p.PrintTypes();

            

            Console.WriteLine(Welcome());

            Console.ReadLine();
        }

        public void Game()
        {

        }

        //En metod som tar string input ifrån klassen utils och returnar namnet på spelaren
        static string Welcome()
        {
            Console.WriteLine("Hello and welcome to Pokemon fight sim! \n Please type in a username");
            string name = Utils.input();
            if(Utils.TryParse.name = true)
            {
                return name;
            }
         
        }
    }
}
