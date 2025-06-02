using UnityEngine;
using Assets.Scripts.Core;
using Assets.Scripts.Data;
using Assets.Scripts.UI.Fields;
using System.Collections.Generic;

namespace Assets.Scripts.UI.Menus
{
    public class PokedexMenu : MonoBehaviour
    {
        private const int INITIAL_LOAD_ID = 1;

        private PokemonModel _currentPokemon;
        [SerializeField]
        private GameObject _loadingOverlay;
        [SerializeField]
        private List<InputField> _fields;

        private void Awake()
        {
            //AppEvents.OnAPICallBegin += () => SetLoadingOverlayVisible(true);
            AppEvents.OnAPICallBegin += EnableLoadingScreen;
            AppEvents.OnAPICallEnd += DisableLoadingScreen;
        }

        private void Start()
        {
            LoadPokemon(INITIAL_LOAD_ID);
        }

        private void LoadPokemon(int id)
        {
            AppState.API.GetPokemon(id, PopulateMenu);
        }

        private void PopulateMenu(PokemonModel model)
        {
            _currentPokemon = model;
            Debug.Log(_currentPokemon);
            foreach(var field in _fields)
            {
                field.Populate(model);
            }
        }

        private void EnableLoadingScreen() => _loadingOverlay.SetActive(true);
        private void DisableLoadingScreen(bool wasLoadSuccess) => _loadingOverlay.SetActive(false);
    }
}
