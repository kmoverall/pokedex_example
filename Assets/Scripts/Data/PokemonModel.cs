using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.Data
{
    public class PokemonModel
    {
        private const string TARGET_LANGUAGE = "en";
        private const float HEIGHT_CONVERSION_FACTOR = 0.1f;
        private const float WEIGHT_CONVERSION_FACTOR = 0.1f;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public float Height { get; private set; }
        public float Weight { get; private set; }
        public BaseStats BaseStats { get; private set; }
        public List<PokeType.Type> Type { get; private set; }

        public PokemonModel(JObject baseJson, JObject speciesJson)
        {
            Id = baseJson["id"].ToObject<int>();
            Name = baseJson["name"].ToObject<string>();
            Height = baseJson["height"].ToObject<float>() * HEIGHT_CONVERSION_FACTOR;
            Weight = baseJson["weight"].ToObject<float>() * WEIGHT_CONVERSION_FACTOR;

            var generaToken = speciesJson["genera"].First(t => t["language"]["name"].ToObject<string>() == TARGET_LANGUAGE);
            Category = generaToken["genus"].ToObject<string>();

            BaseStats = new BaseStats(baseJson["stats"]);
            Type = PokeType.ParseTypes(baseJson["types"]);
        }
    }
}
