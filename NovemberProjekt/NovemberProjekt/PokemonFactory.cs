using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace NovemberProjekt
{
    class PokemonFactory
    {
        static PokemonFactory()
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
        }

    }
}
