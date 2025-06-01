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

        public async void RequestPokemon()
        {
            Debug.Log("Requesting Pokemon");
            PokemonModel pokemon;
            try
            {
                pokemon = await PokeAPI.GetPokemon(1);
                Debug.Log($"Got Pokemon\n {pokemon}");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
