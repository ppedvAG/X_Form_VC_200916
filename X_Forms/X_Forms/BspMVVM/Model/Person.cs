using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Collections.ObjectModel;

namespace X_Forms.BspMVVM.Model
{
    //Die Model-Klassen defnieren die Business-Objekte der App
    //In MVVM beinhalten die Model-Klassen keine Referenzen außerhalb anderer Modelklassen.
    public class Person
    {
        //SQLlite-Property-Attribute(vgl. PersonenDb/Model)
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }

        [Ignore]
        public static ObservableCollection<Person> PersonenListe { get; set; } = new ObservableCollection<Person>();
    }
}
