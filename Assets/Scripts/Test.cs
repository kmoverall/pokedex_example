using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Data;

namespace Assets.Scripts
{
    class Test : MonoBehaviour
    {
        public void Start()
        {
            RequestPokemon();
        }

        public void RequestPokemon()
        {
            Debug.Log("Requesting Pokemon");
            try
            {
                PokeAPI.GetPokemon(5, PokemonCallback);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public void PokemonCallback(PokemonModel model)
        {
            Debug.Log($"Got Pokemon\n {model}");

        }
    }
}
