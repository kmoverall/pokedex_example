using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.UI.Fields
{
    class BaseStatsField : InputField<BaseStats>
    {
        [SerializeField]
        private StatField[] _statFields;

        public override void Populate(BaseStats field)
        {
            if (_statFields.Length != 6)
                throw new ArgumentException("Not all base stats provided!");

            _statFields[0].Populate(field.HP);
            _statFields[1].Populate(field.Attack);
            _statFields[2].Populate(field.Defense);
            _statFields[3].Populate(field.SpecialAttack);
            _statFields[4].Populate(field.SpecialDefense);
            _statFields[5].Populate(field.Speed);
        }
    }
}
