using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.UI.Fields
{
    public class PokeTypeField : InputField<PokeType.Type>
    {
        [SerializeField]
        private TMP_Dropdown _typeDropdown;

        protected override void Initialize()
        {
            List<TMP_Dropdown.OptionData> options = new();
            foreach (var type in Enum.GetNames(typeof(PokeType.Type)))
            {
                options.Add(new TMP_Dropdown.OptionData(type));
            }
            _typeDropdown.ClearOptions();
            _typeDropdown.AddOptions(options);
            _typeDropdown.RefreshShownValue();
        }
        
        public override void Populate(PokeType.Type field)
        {
            _typeDropdown.SetValueWithoutNotify((int)field);
            _typeDropdown.RefreshShownValue();
        }
    }
}
