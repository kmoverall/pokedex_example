using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Fields
{
    public class TextField : InputField<string>
    {
        [SerializeField]
        private TMP_InputField _field;
        public override void Populate(string data)
        {
            _field.SetTextWithoutNotify(data);
        }
    }
}
