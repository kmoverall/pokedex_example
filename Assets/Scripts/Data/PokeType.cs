using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Data
{
    public static class PokeType
    {
        public enum Type
        {
            None,
            Normal,
            Fighting,
            Flying,
            Poison,
            Ground,
            Rock,
            Bug,
            Ghost,
            Steel,
            Fire,
            Water,
            Grass,
            Electric,
            Psychic,
            Ice,
            Dragon,
            Dark,
            Fairy
        }

        public static List<Type> ParseTypes(JToken token)
        {
            var result = new List<Type>();
            result.Add(Parse(token.FirstOrDefault(t => (int)t["slot"] == 1)));
            result.Add(Parse(token.FirstOrDefault(t => (int)t["slot"] == 2)));

            return result;
        }

        private static Type Parse(JToken typeData)
        {
            if (typeData == null)
                return Type.None;

            var typeName = typeData["type"]["name"].ToString().FirstCharToUpper();
            return Enum.Parse<Type>(typeName);
        }
    }
}
