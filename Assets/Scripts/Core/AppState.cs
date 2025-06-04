using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Data;
using Assets.Scripts.Data.DataSources;

namespace Assets.Scripts.Core
{
    public static class AppState
    {
        public static PokedexDataSource Data = new();
    }
}
