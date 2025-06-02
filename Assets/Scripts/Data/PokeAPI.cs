using UnityEngine;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using Assets.Scripts.Core;

namespace Assets.Scripts.Data
{
    public class PokeAPI
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private const string POKEMON_ENDPOINT = "pokemon";
        private HttpClient _client = new HttpClient();

        public bool IsWaitingForResponse { get; private set; }

        private async Task<JObject> Request(string endPoint, int id)
        {
            AppEvents.OnAPICallBegin();
            IsWaitingForResponse = true;
            try
            {
                StringBuilder sb = new StringBuilder(API_URL);
                sb.AppendFormat("{0}/{1}", endPoint, id);

                var response = await _client.GetStringAsync(sb.ToString());

                IsWaitingForResponse = false;
                AppEvents.OnAPICallEnd(true);

                return JObject.Parse(response);
            }
            catch (Exception e)
            {
                IsWaitingForResponse = false;
                AppEvents.OnAPICallEnd(false);

                throw new Exception(e.ToString());
            }
        }

        public async void GetPokemon(int id, Action<PokemonModel> callback)
        {
            if (AppState.Cache.Contains(id))
                callback(AppState.Cache.Get(id));

            var json = await Request(POKEMON_ENDPOINT, id);
            callback(new PokemonModel(json));
        }
    }
}
