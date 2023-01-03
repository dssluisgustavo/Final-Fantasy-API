using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace FF_Teste.DataBase
{
    public class JobDataBase
    {
        public WeaponDataBase weaponshandler = new WeaponDataBase();
        public ArmorDataBase armorhandler = new ArmorDataBase();
        public List<Job> GetAllJobs()
        {
            var joblist = new List<Job>();

            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand sqliteCommand = new SqliteCommand("SELECT * FROM Job", connection);

            SqliteDataReader reader = sqliteCommand.ExecuteReader();

            while (reader.Read())
            {
                Job getjob = new Job();
                getjob.Id = reader.GetInt32(0);
                getjob.Name = reader.GetString(1);

                joblist.Add(getjob);
            }

            connection.Close();

            return joblist;
        }

        public Job GetById(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"SELECT * FROM Job WHERE id = {id} ", connection);

            SqliteDataReader reader = command.ExecuteReader();

            var existt = reader.Read();

            if (!existt)
            {
                return null;
            }

            Job getjob = new Job();

            getjob.Id = reader.GetInt32(0);
            getjob.Name = reader.GetString(1);
            getjob.weaponlist = weaponshandler.GetAllByJobId(getjob.Id);
            getjob.armorlist = armorhandler.GetAllArmorJobId(getjob.Id);

            connection.Close();

            return getjob;
        }

        public void DeleteById(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"DELETE FROM Job WHERE id={id}", connection);

            command.ExecuteNonQuery();

            connection.Close();

        }

        public void Create(Job job)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"INSERT INTO Job (id, name) VALUES({job.Id} ,'{job.Name}')", connection);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(int id, Job job)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=C:\\DataBase\\Final_Fantasy_I2.db");

            connection.Open();

            SqliteCommand command = new SqliteCommand($"UPDATE Job SET name = '{job.Name}' WHERE name = {id}", connection);

            command.ExecuteNonQuery();

            connection.Close();
        }
        
    }
}
