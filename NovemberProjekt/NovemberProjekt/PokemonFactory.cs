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
        RestClient client;
        public PokemonFactory()
        {
            client = new RestClient("https://pokeapi.co/api/v2/");      
        }

        public Pokemon Production()
        {
            int pokeID = Utils.gen.Next(1, 151);
            RestRequest request = new RestRequest("pokemon/" + pokeID);
            IRestResponse response = client.Get(request);
            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            return pokemon;
        }

    }
}
