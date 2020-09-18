using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    public enum ToastDuration
    {
        Long,
        Short
    }

    public static class ToastController
    {
        //vgl. PersonenDbController
        //Globaler Zugriff erfolgt hier über statische Klasse
        public static void ShowToastMessage(string message, ToastDuration duration)
        {
            switch (duration)
            {
                case ToastDuration.Long:
                    DependencyService.Get<IToastService>().ShowLong(message);
                    break;
                case ToastDuration.Short:
                    DependencyService.Get<IToastService>().ShowShort(message);
                    break;
                default:
                    break;
            }
        }
    }
}
