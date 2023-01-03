using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF_Teste
{
    [System.Serializable]
    public class Monster
    {
        public int id;
        public string name;
        public double hp;
        public  double ap;
        public double exp;
        public int gold;
        public string category;
        public string weakness;
        public string resist;
        public string spells;
        public int isBoss;
    }
}
