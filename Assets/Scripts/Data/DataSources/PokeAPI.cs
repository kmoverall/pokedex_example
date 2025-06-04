using Assets.Scripts.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Data.DataSources
{
    public class PokeAPI : MonoBehaviour, IPokeDataSource
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private const string POKEMON_ENDPOINT = "pokemon";

        public bool IsWaitingForResponse { get; private set; }

        private IEnumerator Get(string url, Action<JObject> callback)
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
        private IEnumerator GetSprite(string url, Action<Texture> callback)
        {
            AppEvents.OnAPICallBegin();
            IsWaitingForResponse = true;

            var request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            var response = DownloadHandlerTexture.GetContent(request);

            IsWaitingForResponse = false;
            AppEvents.OnAPICallEnd();

            callback(response);
        }

        private IEnumerator Request(string endPoint, int id, Action<JObject> callback)
        {
            StringBuilder sb = new StringBuilder(API_URL);
            sb.AppendFormat("{0}/{1}", endPoint, id);

            yield return Get(sb.ToString(), callback);
        }

        public void GetPokemon(int id, Action<PokemonModel> callback)
        {
            StartCoroutine(Request(POKEMON_ENDPOINT, id, r => GetPokemonCallback(r, callback)));
        }

        private void GetPokemonCallback(JObject result, Action<PokemonModel> callback)
        {
            StartCoroutine(Get(
                result["species"]["url"].ToString(), 
                r => GetPokemonSpeciesCallback(result, r, callback)
            ));
        }

        private void GetPokemonSpeciesCallback(JObject baseResult, JObject speciesResult, Action<PokemonModel> callback)
        {
            StartCoroutine(GetSprite(
                baseResult["sprites"]["front_default"].ToString(),
                r => GetPokemonSpriteCallback(baseResult, speciesResult, r, callback)
            ));
        }

        private void GetPokemonSpriteCallback(JObject baseResult, JObject speciesResult, Texture sprite, Action<PokemonModel> callback)
        {
            callback(new PokemonModel(baseResult, speciesResult, sprite));
        }

        public bool Contains(int id) => true;
    }
}
