using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Fields
{
    public class NumericField : InputField<float>
    {
        [SerializeField]
        private string _numericFormat = "F1";
        [SerializeField]
        private TMP_InputField _field;
        public override void Populate(float data)
        {
            _field.SetTextWithoutNotify(data.ToString(_numericFormat));
        }
    }
}
