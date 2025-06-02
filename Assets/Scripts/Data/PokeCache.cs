using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    public class PokeCache
    {
        private Dictionary<int, PokemonModel> _cache = new();

        public bool Contains(int id) => _cache.ContainsKey(id);
        public bool Contains(PokemonModel model) => _cache.ContainsKey(model.Id);
        public PokemonModel Get(int id) => _cache[id];
        public void Update(PokemonModel model)
        {
            _cache[model.Id] = model;
        }
        public void Delete(PokemonModel model)
        {
            _cache.Remove(model.Id);
        }
    }
}
