using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace X_Forms.PersonenDb.Services
{
    //Mittels des DependencyServices können Aktionen, welche OS-spezifisch gehandelt werden müssen, an derartige Klassen umgeleitet werden.
    //Dazu muss ein allgemeines Interface erstellt werden, von welchem die OS-spezifischen Klassen erben (vgl. Android/Services/AndroidDatabaseService.cs).
    //Der Aufruf einer derartigen Klasse muss über die Get-Methode des DependencyServices erfolgen (vgl. PersonenDbController)
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
    }
}
