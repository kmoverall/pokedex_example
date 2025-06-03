using UnityEngine;
using Assets.Scripts.Core;
using Assets.Scripts.Data;
using Assets.Scripts.UI.Fields;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.Menus
{
    public class PokedexMenu : MonoBehaviour
    {
        private const int INITIAL_LOAD_ID = 1;

        private PokemonModel _currentPokemon;
        [SerializeField]
        private GameObject _loadingOverlay;
        [SerializeField]
        private TextField _nameField;
        [SerializeField]
        private TextField _categoryField;
        [SerializeField]
        private NumericField _heightField;
        [SerializeField]
        private NumericField _weightField;
        [SerializeField]
        private PokeTypeField _primaryTypeField;
        [SerializeField]
        private PokeTypeField _secondaryTypeField;
        [SerializeField]
        private BaseStatsField _baseStatsField;
        [SerializeField]
        private SpriteField _spriteField;

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

            _nameField.Populate(model.Name);
            _nameField.SetLabelText($"#{model.Id}");

            _categoryField.Populate(model.Category);
            _heightField.Populate(model.Height);
            _weightField.Populate(model.Weight);
            _baseStatsField.Populate(model.BaseStats);
            _primaryTypeField.Populate(model.Type[0]);
            _secondaryTypeField.Populate(model.Type[1]);
            _spriteField.Populate(model.Sprite);
        }

        private void EnableLoadingScreen() => _loadingOverlay.SetActive(true);
        private void DisableLoadingScreen() => _loadingOverlay.SetActive(false);
    }
}
