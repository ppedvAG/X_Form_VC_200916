using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using X_Forms.PersonenDb.Model;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    public class PersonenDbController
    {
        static object locker = new object();

        SQLiteConnection database;

        public PersonenDbController()
        {
            lock(locker)
            {
                IDatabaseService dbService = DependencyService.Get<IDatabaseService>();

                database = dbService.GetConnection();

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
