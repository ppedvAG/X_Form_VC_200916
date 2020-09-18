using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MC_SubscriberPage : ContentPage
    {
        //vgl. auch MainPage.xaml
        public MC_SubscriberPage()
        {
            InitializeComponent();

            //Abonieren einer Nachricht über das MessagingCenter unter Angabe von 
            //<Sender, Nachrichtentyp>(Empfänger, Titel, Methode zum Handeln des Inhalts)
            MessagingCenter.Subscribe<MainPage, string>(this, "Nachricht", SetzeText);
        }

        //Methode, welche die MC-Nachricht handelt. Diese wird automatisch ausgeführt, wenn die Nachricht eintrifft
        private void SetzeText(object sender, string text)
        {
            Lbl_Main.Text = text;
        }
    }
}