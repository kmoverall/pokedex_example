using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts.Data
{
    public struct BaseStats
    {
        public int HP;
        public int Attack;
        public int Defense;
        public int SpecialAttack;
        public int SpecialDefense;
        public int Speed;

        public BaseStats(JToken statsObject)
        {
            HP = (int)statsObject[0]["base_stat"];
            Attack = (int)statsObject[1]["base_stat"];
            Defense = (int)statsObject[2]["base_stat"];
            SpecialAttack = (int)statsObject[3]["base_stat"];
            SpecialDefense = (int)statsObject[4]["base_stat"];
            Speed = (int)statsObject[5]["base_stat"];
        }
    }
}
