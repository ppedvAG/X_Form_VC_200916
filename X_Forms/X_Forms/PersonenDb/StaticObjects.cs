using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using X_Forms.PersonenDb.Model;
using X_Forms.PersonenDb.Services;

namespace X_Forms.PersonenDb
{
    //Statische Klasse mit globalen Objekten (kann auch Service- und Controllerobjekte beinhalten)
    public static class StaticObjects
    {
        private static ObservableCollection<Person> personenListe;
        public static ObservableCollection<Person> PersonenListe
        {
            get
            {
                if (personenListe == null)
                {
                    personenListe = new ObservableCollection<Person>()
                    {
                        new Person() { Vorname = "Rainer", Nachname = "Zufall" }
                    };
                }
                return personenListe;
            }
            set { personenListe = value; }
        }

        public static PersonenDbController Database { get; set; } = new PersonenDbController();
    }
}
