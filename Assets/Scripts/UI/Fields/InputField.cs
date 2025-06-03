using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Data;
using TMPro;

namespace Assets.Scripts.UI.Fields
{
    public abstract class InputField : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _label;

        private void Start()
        {
            Initialize();
        }
        protected virtual void Initialize() { }

        public void SetLabelText(string text)
        {
            _label.text = text;
        }
    }

    public abstract class InputField<T> : InputField
    {
        public abstract void Populate(T field);
    }
}
