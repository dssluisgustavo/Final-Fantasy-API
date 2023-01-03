using FF_Teste.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF_Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmorsController : Controller
    {
        public ArmorDataBase armor = new ArmorDataBase();

        [HttpGet]
        public ActionResult<List<Armor>> GetArmor()
        {
            var list = armor.GetAll();
            
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<Armor> GetArmorById(int id)
        {
            var armorid = armor.GetById(id);

            if(armorid == null)
            {
                return NotFound();
            }

            return Ok(armorid);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArmorById(int id)
        {
            armor.DeleteById(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateArmor(Armor armorcreate)
        {
            armor.Create(armorcreate);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArmor(int id, Armor armorupdate)
        {
            armor.Update(id, armorupdate);

            return Ok();
        }
    }
}
