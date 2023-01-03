using FF_Teste.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF_Teste
{
    [System.Serializable]
    public class Job
    {
        public string Name;
        public int Id;
        public List<Weapon> weaponlist;
        public List<Armor> armorlist;
    }
}
