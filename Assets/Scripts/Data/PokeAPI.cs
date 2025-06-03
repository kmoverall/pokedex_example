using UnityEngine;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using Assets.Scripts.Core;
using System.Collections;
using UnityEngine.Networking;

namespace Assets.Scripts.Data
{
    public class PokeAPI : MonoBehaviour
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private const string POKEMON_ENDPOINT = "pokemon";

        public bool IsWaitingForResponse { get; private set; }

        private IEnumerator Request(string url, Action<JObject> callback)
        {
            AppEvents.OnAPICallBegin();
            IsWaitingForResponse = true;

            var request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            var response = JObject.Parse(request.downloadHandler.text);

            IsWaitingForResponse = false;
            AppEvents.OnAPICallEnd();

            callback(response);
        }

        private IEnumerator Request(string endPoint, int id, Action<JObject> callback)
        {
            StringBuilder sb = new StringBuilder(API_URL);
            sb.AppendFormat("{0}/{1}", endPoint, id);

            yield return Request(sb.ToString(), callback);
        }

        public void GetPokemon(int id, Action<PokemonModel> callback)
        {
            if (AppState.Cache.Contains(id))
                callback(AppState.Cache.Get(id));

            var json = StartCoroutine(Request(POKEMON_ENDPOINT, id, r => GetPokemonCallback(r, callback)));
        }

        private void GetPokemonCallback(JObject result, Action<PokemonModel> callback)
        {
            var json = StartCoroutine(Request(
                result["species"]["url"].ToString(), 
                r => GetPokemonSpeciesCallback(result, r, callback)
            ));
        }

        public void GetPokemonSpeciesCallback(JObject baseResult, JObject speciesResult, Action<PokemonModel> callback)
        {
            callback(new PokemonModel(baseResult, speciesResult));
        }
    }
}
