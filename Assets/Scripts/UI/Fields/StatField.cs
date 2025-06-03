using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.UI.Fields
{
    public class StatField : InputField<int>
    {
        [SerializeField]
        private TMP_InputField _inputField;
        [SerializeField]
        private Slider _slider;

        public override void Populate(int field)
        {
            _inputField.SetTextWithoutNotify(field.ToString());
            _slider.SetValueWithoutNotify(field);
        }
    }
}
