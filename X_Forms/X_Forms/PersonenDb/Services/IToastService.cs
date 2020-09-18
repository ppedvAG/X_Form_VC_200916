using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Services
{
    public interface IToastService
    {
        void ShowLong(string msg);
        void ShowShort(string msg);
    }
}
