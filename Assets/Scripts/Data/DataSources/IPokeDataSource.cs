using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data.DataSources
{
    public interface IPokeDataSource
    {
        public bool Contains(int id);
        public void GetPokemon(int id, Action<PokemonModel> callback);
    }
}
