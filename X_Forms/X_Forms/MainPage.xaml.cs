using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace X_Forms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //Property zum Zwischenspeichern der Personenliste (ObservableCollection ist eine generische Liste, welche die GUI
        //automatisch über Veränderungen informiert
        public ObservableCollection<string> NamensListe { get; set; }

        //Konstruktor
        public MainPage()
        {
            //Neuzuordnung der verwendetet Culure (Sprache uä.)
            ResourcesBsp.Culture = new System.Globalization.CultureInfo("de");

            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Zuweisung von EventHandlern zu den Completed-Events, damit ein besserer Bedienfluss gegeben ist
            Ent_Vorname.Completed += (s, e) => Ent_Nachname.Focus();
            Ent_Nachname.Completed += Btn_Show_Clicked;

            //Initialisierung der Namesliste
            NamensListe = new ObservableCollection<string>()
            {
                "Anna Nass",
                "Rainer Zufall"
            };

            //Durch Setzen des BindingContextes nehmen Kurzbindungen aus dem XAML-Code automatisch Bezug auf die Properties
            //des im BindingContext gesetzten Objekts
            this.BindingContext = this;

            //Zugriff auf die Battery-Klasse aus Xamarin.Essentials zum Zugriff auf den Batteriestatus
            Lbl_Battery.Text = Battery.State.ToString() + " | State: " + Battery.ChargeLevel * 100 + "%";

            //Zuweisung von Sprachressourcen an UI-Elemente als Alternative zur x:Static-Bindung (vgl. Resource.resx und Resource.de.resx)
            //Btn_LocalisationBsp.Text = ResourcesBsp.String_Btn;
            //Lbl_LocalisationBsp.Text = ResourcesBsp.String_Lbl;
        }

        //EventHandler
        private void Button_Clicked(object sender, EventArgs e)
        {
            Lbl_Output.Text = "Der Button wurde geklickt";
        }

        private async void Btn_Show_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            if (await DisplayAlert($"{Ent_Vorname.Text} {Ent_Nachname.Text}", "Abspeichern?", "Ok", "Abbruch"))
                //Erstellen eines neuen Listenelements (aus UI-Properties)
                NamensListe.Add(Ent_Vorname.Text + " " + Ent_Nachname.Text);
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschung", "Soll der Eintrag gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen eines Listeneintrags
                string person = (sender as MenuItem).CommandParameter.ToString();

                NamensListe.Remove(person);
            }
        }

        //Push-Navigation
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //Navigation zu einer anderen Page (Muss innerhalb einer NavigationPage stattfinden (vgl. App.xaml-CB))
            Navigation.PushAsync(new Uebungen.U_AbsoluteL());
            
            //Navigation zu einer anderen Page (ohne 'Zurück'-GUI)
            //Navigation.PushModalAsync(new Uebungen.U_AbsoluteL());
            
            //Navigation zur vorherigen Seite
            //Navigation.PopAsync();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Navigation.TabbedBsp());
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Navigation.CarouselBsp());
        }

        private void Btn_MC_Clicked(object sender, EventArgs e)
        {
            //Mittels des MessagingCenters können zwei voneinander unabhängige Objekte mittels eines Sender/Subscriber-Prinzips
            //miteinander kommunizieren

            //Instanziierung des Emfänger-Objekts (dieses muss zum Zeitpunkt der Nachricht-Sendes bereits existieren)
            Page page = new MC_SubscriberPage();

            //Senden der Nachricht inkl. Sender, Titel und Inhalt
            MessagingCenter.Send(this, "Nachricht", Ent_Vorname.Text);

            //Navigation zum Empfänger-Objekt (vgl. MC_SubscriberPage.xaml)
            Navigation.PushAsync(page);
        }

        private void Btn_LocalisationBsp_Clicked(object sender, EventArgs e)
        {

        }
    }
}
