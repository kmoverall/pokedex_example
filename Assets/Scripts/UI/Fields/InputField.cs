using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Scripts.Data;

namespace Assets.Scripts.UI.Fields
{
    public abstract class InputField : MonoBehaviour
    {
        private void Start()
        {
            Initialize();
        }
        public virtual void Initialize() { }

        public abstract void Populate(PokemonModel model);
    }

    public abstract class InputField<T> : InputField
    {
    }
}
