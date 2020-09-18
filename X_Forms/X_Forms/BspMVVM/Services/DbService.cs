using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using X_Forms.BspMVVM.Model;

namespace X_Forms.BspMVVM.Services
{
    //Je nach Lesart gehören in MVVM Service- und Controller-Klassen mit zum Model oder zu einem seperaten Bereich
    //(bez. SQLite vgl. PersonenDb/Services)
    public class DbService
    {
        static object locker = new object();

        //Connection-Objekt
        SQLiteConnection database;

        public DbService()
        {
            //Mittels des lock-Stichworts kann der Datenbankzugriff mittels eines spezifischen Objekts limitiert werden
            lock (locker)
            {
                string ordner = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string dbName = "PersonenDb.db3";

                string path = Path.Combine(ordner, dbName);

                database = new SQLiteConnection(path);

                //Erstellen einer neuen Person-Tabelle (wenn noch nicht vorhanden)
                database.CreateTable<Model.Person>();
            }
        }

        //Methoden für die verschiedenen Datenbankzugriffsarten
        public Person GetPerson(Guid id)
        {
            lock (locker)
            {
                //Erfragen eines einzelnen Person-Objekts anhand der Id
                return database.Get<Person>(id);
            }
        }

        public List<Person> GetPeople()
        {
            lock (locker)
            {
                //Erfragen aller Person-Objekte der Datenbank
                return database.Table<Person>().ToList();
            }
        }

        public void AddPerson(Person person)
        {
            lock (locker)
            {
                //Hinzufügen einer Person zur Datenbank
                database.Insert(person);
            }
        }

        public void DeletePerson(Person person)
        {
            lock (locker)
            {
                //Löschen einer Person in der Datenbank
                database.Delete(person);
            }
        }
    }
}
