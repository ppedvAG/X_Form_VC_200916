using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace X_Forms.PersonenDb.Model
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
