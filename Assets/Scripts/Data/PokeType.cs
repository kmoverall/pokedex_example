using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.Data
{
    public static class PokeType
    {
        // I would prefer to capitalize these enum stylistically
        // But all lower case works better with the API
        public enum Type
        {
            none,
            normal,
            fighting,
            flying,
            poison,
            ground,
            rock,
            bug,
            ghost,
            steel,
            fire,
            water,
            grass,
            electric,
            psychic,
            ice,
            dragon,
            dark,
            fairy
        }

        public static List<Type> ParseTypes(JToken token)
        {
            var result = new List<Type>();
            result.Add(Parse(token.First(t => (int)t["slot"] == 1)));
            result.Add(Parse(token.First(t => (int)t["slot"] == 2)));

            return result;
        }

        private static Type Parse(JToken typeData)
        {
            return Enum.Parse<Type>(typeData["type"]["name"].ToString());
        }
    }
}
