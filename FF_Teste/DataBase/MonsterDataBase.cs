using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace FF_Teste.DataBase
{
    public class MonsterDataBase
    {
        public List<Monster> GetAllMonster()
        {
            var monsterlist = new List<Monster>();

            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand("SELECT * FROM Monster", connection);

            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Monster getmonster = new Monster();

                getmonster.id = reader.GetInt32(0);
                getmonster.name = reader.GetString(1);

                monsterlist.Add(getmonster);
            }
            connection.Close();

            return (monsterlist);
        }

        public Monster GetById(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"SELECT * FROM Monster WHERE id = {id}", connection);

            SqliteDataReader reader = command.ExecuteReader();

            var exist = reader.Read();

            if (!exist)
            {
                return null;
            }

            Monster getmonsterid = new Monster();

            getmonsterid.id = reader.GetInt32(0);
            getmonsterid.name = reader.GetString(1);
            getmonsterid.hp = reader.GetInt32(2);
            getmonsterid.ap = reader.GetInt32(3);
            getmonsterid.exp = reader.GetInt32(4);
            getmonsterid.gold = reader.GetInt32(5);
            getmonsterid.category = reader.GetString(6);
            getmonsterid.weakness = reader.GetString(7);
            getmonsterid.resist = reader.GetString(8);
            getmonsterid.spells = reader.GetString(9);
            getmonsterid.isBoss = reader.GetInt32(10);

            connection.Close();

            return getmonsterid;

        }

        public void DeleteById (int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"DELETE FROM Monster WHERE id={id}", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Create(Monster monster)
        {
            SqliteConnection connection = new SqliteConnection("Data Source = C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"INSERT INTO Monster (id, name, hp, ap, exp, gold, category, weakness, resist, spells, isBoss) VALUES ({monster.id}, '{monster.name}', {monster.hp}, {monster.ap}, {monster.exp}, {monster.gold}, '{monster.category}', '{monster.weakness}', {monster.resist}, '{monster.spells}', {monster.isBoss})", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Update (int id, Monster monster)
        {
            SqliteConnection connection = new SqliteConnection("Data Source = C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"UPDATE Monster SET name = '{monster.name}', hp = {monster.hp}, ap = {monster.ap}, exp = {monster.exp}, gold = {monster.gold}, category = '{monster.category}', weakness = '{monster.weakness}', resist = '{monster.resist}', spells = '{monster.spells}', isBoss = {monster.isBoss} WHERE id = {id}", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }
    }
}
