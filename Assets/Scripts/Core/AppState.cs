using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Data;

namespace Assets.Scripts.Core
{
    public static class AppState
    {
        public static PokeAPI API = new();
        public static PokeCache Cache = new();
    }
}
