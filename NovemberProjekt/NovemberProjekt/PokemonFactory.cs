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
        //restclient = client
        RestClient client;
        //skappar client till pokeApi
        public PokemonFactory()
        {
            client = new RestClient("https://pokeapi.co/api/v2/");      
        }
        //Denna metod skappar en random siffra ifrån 1 till 151, detta är kopplat till gen 1 pokemons. Sedan tar man ner den pokemonen ifrån api:n och sen returnar den
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
