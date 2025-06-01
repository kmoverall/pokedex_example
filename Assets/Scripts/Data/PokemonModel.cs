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
        private JObject _json;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public float Height { get; private set; }
        public float Weight { get; private set; }
        public BaseStats BaseStats { get; private set; }

        public List<PokeType.Type> Type { get; private set; }

        public PokemonModel(JObject json)
        {
            _json = json;

            Id = json["id"].ToObject<int>();
            Name = json["name"].ToString();
            Height = json["height"].ToObject<float>() / 10f;
            Weight = json["weight"].ToObject<float>() / 10f;

            BaseStats = new BaseStats(json["stats"]);
            Type = PokeType.ParseTypes(json["types"]);
        }

        public override string ToString()
        {
            return _json.ToString();
        }
        
    }
}
