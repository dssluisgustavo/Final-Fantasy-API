using FF_Teste.Controllers;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace FF_Teste.DataBase
{
    public class ArmorDataBase
    {
        public List<Armor> GetAll()
        {
            var armor = new List<Armor>();

            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand sqlitecommand = new SqliteCommand("SELECT * FROM Armor", connection);

            SqliteDataReader reader = sqlitecommand.ExecuteReader();

            while (reader.Read())
            {
                Armor getarmor = new Armor();

                getarmor.id = reader.GetInt32(0);
                getarmor.name = reader.GetString(1);

                armor.Add(getarmor);
            }

            connection.Close();

            return armor;
        }

        public Armor GetById(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"SELECT * FROM Armor JOIN ArmorType ON Armor.typeid = ArmorType.id WHERE Armor.id = {id}", connection);

            SqliteDataReader reader = command.ExecuteReader();

            var exist = reader.Read();

            if (!exist)
            {
                return null;
            }

            Armor getarmorid = new Armor();

            getarmorid.id = reader.GetInt32(0);
            getarmorid.name = reader.GetString(1);
            getarmorid.absorb = reader.GetInt32(2);
            getarmorid.evade = reader.GetInt32(3);
            getarmorid.type = reader.GetString(6);

            connection.Close();

            return getarmorid;
        }

        public void DeleteById(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"DELETE FROM Armor WHERE id={id}", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Create (Armor armor)
        {
            SqliteConnection connection = new SqliteConnection("Data Source = C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"INSERT INTO Armor (id,name,absorb, evade) VALUES ({armor.id}, '{armor.name}', {armor.absorb}, {armor.evade})", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Update (int id, Armor armor)
        {
            SqliteConnection connection = new SqliteConnection("Data Source = C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"UPDATE Armor SET name = '{armor.name}', absorb = {armor.absorb}, evade = {armor.evade} WHERE id = {id}", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public List<Armor> GetAllArmorJobId(int jobid)
        {
            var armorlist = new List<Armor>();

            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"SELECT * FROM JobArmor JOIN Armor ON JobArmor.armorid = Armor.id JOIN ArmorType ON Armor.typeid = ArmorType.id WHERE jobid = {jobid}", connection);


            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Armor armor = new Armor();

                armor.id = reader.GetInt32(1);
                armor.name = reader.GetString(3);
                armor.absorb = reader.GetInt32(4);
                armor.evade = reader.GetInt32(5);
                armor.type = reader.GetString(8);

                armorlist.Add(armor);

            }
            connection.Close();

            return armorlist;
        }
    }
}
