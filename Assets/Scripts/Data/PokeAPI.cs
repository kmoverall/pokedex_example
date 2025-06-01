using UnityEngine;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Assets.Scripts.Data
{
    public static class PokeAPI
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private const string POKEMON_ENDPOINT = "pokemon";
        private static HttpClient _client = new HttpClient();

        private static async Task<JObject> Request(string endPoint, int id)
        {
            try
            {
                StringBuilder sb = new StringBuilder(API_URL);
                sb.AppendFormat("{0}/{1}", endPoint, id);

                var response = await _client.GetStringAsync(sb.ToString());
                return JObject.Parse(response);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public static async void GetPokemon(int id, Action<PokemonModel> callback)
        {
            var json = await Request(POKEMON_ENDPOINT, id);
            callback(new PokemonModel(json));
        }
    }
}
