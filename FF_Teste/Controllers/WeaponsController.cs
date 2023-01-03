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
    public class WeaponsController : Controller
    {
        public WeaponDataBase weapon = new WeaponDataBase();

        [HttpGet]
        public ActionResult<List<Weapon>> GetWeapons()
        {
           var weapons = this.weapon.GetAll();

            return Ok(weapons);
        }

        [HttpGet("{id}")]
        public ActionResult<Weapon> GetWeaponsById(int id)
        {
            var getweapons = weapon.GetById(id);

            return Ok(getweapons);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWeapon(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"DELETE FROM Weapon WHERE id={id}", connection);

            command.ExecuteNonQuery();

            connection.Close();

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateWeapon(Weapon weaponcreate)
        {
            weapon.Create(weaponcreate);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWeapon(int id, Weapon updateweapon)
        {
            weapon.Update(id, updateweapon);
            return Ok();
        }
    }
}
