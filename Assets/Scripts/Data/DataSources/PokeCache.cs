using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data.DataSources
{
    public class PokeCache : IPokeDataSource
    {
        private Dictionary<int, PokemonModel> _cache = new();

        public bool Contains(int id) => _cache.ContainsKey(id);
        public void Update(PokemonModel model)
        {
            _cache[model.Id] = model;
        }
        public void Delete(PokemonModel model)
        {
            _cache.Remove(model.Id);
        }

        public void GetPokemon(int id, Action<PokemonModel> callback) => callback(_cache[id]);
    }
}
