using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using X_Forms.BspMVVM.Model;

namespace X_Forms.BspMVVM.Services
{
    public class DbService
    {
        static object locker = new object();

        SQLiteConnection database;

        public DbService()
        {
            lock (locker)
            {
                string ordner = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                string dbName = "PersonenDb.db3";

                string path = Path.Combine(ordner, dbName);

                database = new SQLiteConnection(path);

                database.CreateTable<Model.Person>();
            }
        }

        public Person GetPerson(Guid id)
        {
            lock (locker)
            {
                return database.Get<Person>(id);
            }
        }

        public List<Person> GetPeople()
        {
            lock (locker)
            {
                return database.Table<Person>().ToList();
            }
        }

        public void AddPerson(Person person)
        {
            lock (locker)
            {
                database.Insert(person);
            }
        }

        public void DeletePerson(Person person)
        {
            lock (locker)
            {
                database.Delete(person);
            }
        }
    }
}
