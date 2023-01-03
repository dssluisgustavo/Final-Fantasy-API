using FF_Teste.Controllers;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace FF_Teste.DataBase
{
    public class WeaponDataBase
    {
        public List<Weapon> GetAll()
        {
            var weaponslist = new List<Weapon>();

            SqliteConnection connection  = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command =  new SqliteCommand("SELECT * FROM Weapon", connection);

            SqliteDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Weapon getweapon = new Weapon();

                getweapon.id = reader.GetInt32(0);  
                getweapon.name = reader.GetString(1);
                getweapon.damage = reader.GetInt32(2); 
                getweapon.hit =  reader.GetInt32(3);

                weaponslist.Add(getweapon);
            }
            connection.Close();

            return weaponslist;
        }
        public Weapon GetById(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"SELECT id,name FROM Weapon WHERE id = {id}", connection);

            SqliteDataReader reader = command.ExecuteReader();

            var exist = reader.Read();

            if (!exist)
            {
                return null;
            }

            Weapon getweapons = new Weapon();

            getweapons.id = reader.GetInt32(0);
            getweapons.name = reader.GetString(1);
            getweapons.damage = reader.GetInt32(2);
            getweapons.hit = reader.GetInt32(3);

            connection.Close();

            return getweapons;
        }

        public void Create (Weapon weapon)
        {
            SqliteConnection connection = new SqliteConnection("Data Source = C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"INSERT INTO Weapon (id, name, damage, hit) VALUES ({weapon.id}, '{weapon.name}', {weapon.damage}, {weapon.hit})", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Update (int id, Weapon weapon)
        {
            SqliteConnection connection = new SqliteConnection("Data Source = C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"UPDATE Weapon SET name = '{weapon.name}', damage = {weapon.damage}, hit = {weapon.hit} WHERE id = {id}", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public List<Weapon> GetAllByJobId(int jobid)
        {
            var weaponlist = new List<Weapon>();

            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"SELECT * FROM JobWeapon JOIN Weapon ON JobWeapon.weaponid = Weapon.id WHERE jobid = {jobid}", connection);


            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Weapon weapon = new Weapon();

                weapon.id = reader.GetInt32(1);
                weapon.name = reader.GetString(3);
                weapon.damage = reader.GetInt32(4);
                weapon.hit = reader.GetInt32(5);

                weaponlist.Add(weapon);

            }
            connection.Close();

            return weaponlist;

        }
    }
}
