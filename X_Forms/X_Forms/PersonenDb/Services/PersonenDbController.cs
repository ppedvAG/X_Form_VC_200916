using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using X_Forms.PersonenDb.Model;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    //Der PersonenDbController handelt alle Person-betreffenden Datenbankanfragen mithilfe des DependencyServices.
    //Der globale Zugriff auf den Controller erfolgt in diesem Beispiel über die App-Klasse.
    public class PersonenDbController
    {
        //Statische Locker-Objekte werden benutzt um einen gleichzeitigen Datenbankzugriff durch dieselbe App zu verhindern
        static object locker = new object();

        //Connection-Objekt
        SQLiteConnection database;

        //Konstruktor
        public PersonenDbController()
        {
            //Mittels des lock-Stichworts kann der Datenbankzugriff mittels eines spezifischen Objekts limitiert werden
            lock (locker)
            {
                //Erstellen des Connection-Objekts mittels der OS-spezifischen Klassen. Der DependencyService sucht automatisch
                //die dem aktuellen OS entsprechende Klasse (wenn vohanden)
                IDatabaseService dbService = DependencyService.Get<IDatabaseService>();

                database = dbService.GetConnection();

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
        
        public void UpdatePerson(Person person)
        {
            lock (locker)
            {
                //Aktualisieren einer Person in der Datenbank
                database.Update(person);
            }
        }
    }
}
