using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Data.DataSources;

namespace Assets.Scripts.Data
{
    public class PokedexDataSource : IPokeDataSource
    {
        private List<IPokeDataSource> _dataSources = new();

        public void AddDataSource(IPokeDataSource source)
        {
            _dataSources.Add(source);
        }

        public bool Contains(int id) => true;

        public void GetPokemon(int id, Action<PokemonModel> callback)
        {
            foreach (var source in _dataSources)
            {
                if (source.Contains(id))
                {
                    source.GetPokemon(id, callback);
                    break;
                }
            }
        }
    }
}
