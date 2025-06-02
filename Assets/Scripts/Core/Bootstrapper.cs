using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private PokeAPI _api;

        private void Awake()
        {
            AppState.API = _api;
        }
    }
}
