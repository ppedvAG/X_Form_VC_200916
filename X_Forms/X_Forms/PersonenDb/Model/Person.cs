using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace X_Forms.PersonenDb.Model
{
    public class Person
    {
        //Diese Model-Klasse wurde zur Verwendung durch SQLite optimiert. Dazu wurden Property-Attribute hinzugefügt.
        //Der Primary Key muss definiert sein; AutoIncrement zählt diesen automatisch hoch.
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }

        //Properties, die nicht in der Datenbank vermerkt werden sollen, müssen mit Ignore markiert sein.
        [Ignore]
        public string FullName
        {
            get { return $"{Vorname} {Nachname}"; }
        }
    }
}
