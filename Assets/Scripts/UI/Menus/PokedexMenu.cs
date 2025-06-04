using UnityEngine;
using Assets.Scripts.Core;
using Assets.Scripts.Data;
using Assets.Scripts.UI.Fields;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.UI.Menus
{
    public class PokedexMenu : MonoBehaviour
    {
        private const int INITIAL_LOAD_ID = 1;

        private PokemonModel _currentPokemon;
        [SerializeField]
        private List<GameObject> _loadingOverlays;
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

        [SerializeField]
        private TMP_InputField _searchField;
        [SerializeField]
        private Button _searchButton;

        private void Awake()
        {
            //AppEvents.OnAPICallBegin += () => SetLoadingOverlayVisible(true);
            AppEvents.OnAPICallBegin += EnableLoadingScreen;
            AppEvents.OnAPICallEnd += DisableLoadingScreen;
            _searchButton.onClick.AddListener(Search);

        }

        private void Start()
        {
            _searchField.text = INITIAL_LOAD_ID.ToString();
            LoadPokemon(INITIAL_LOAD_ID);
        }

        private void LoadPokemon(int id)
        {
            AppState.Data.GetPokemon(id, PopulateMenu);
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

        private void EnableLoadingScreen()
        {
            foreach (var overlay in _loadingOverlays)
                overlay.SetActive(true);
        }
        private void DisableLoadingScreen()
        {
            foreach (var overlay in _loadingOverlays)
                overlay.SetActive(false);
        }

        private void Search()
        {
            int id = int.Parse(_searchField.text);
            LoadPokemon(id);
        }
    }
}
