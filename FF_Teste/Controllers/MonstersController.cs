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
    public class MonsterController : Controller
    {
        public MonsterDataBase monster = new MonsterDataBase();

        [HttpGet]
        public ActionResult<List<Monster>> GetMonster()
        {
           var monsterlist = monster.GetAllMonster();

            return Ok(monsterlist);
        }

        [HttpGet("{id}")]
        public ActionResult <Monster> GetMonsterById(int id)
        {
            var monsterbyid = monster.GetById(id);

            return Ok(monsterbyid);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMonsterById(int id)
        {
            monster.DeleteById(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateMonster(Monster newmonster)
        {
            monster.Create(newmonster);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMonster(int id, Monster updatemonster)
        {
            monster.Update(id, updatemonster);

            return Ok();
        }
    }
}
