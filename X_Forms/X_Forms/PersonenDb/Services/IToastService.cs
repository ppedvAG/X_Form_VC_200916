using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Services
{
    //vgl. IDatabaseService
    //vgl. Android/Services/AndroidToastService
    public interface IToastService
    {
        void ShowLong(string msg);
        void ShowShort(string msg);
    }
}
