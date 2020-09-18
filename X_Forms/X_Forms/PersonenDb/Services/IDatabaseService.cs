using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace X_Forms.PersonenDb.Services
{
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
    }
}
