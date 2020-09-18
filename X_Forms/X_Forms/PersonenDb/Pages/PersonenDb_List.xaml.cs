using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonenDb_List : ContentPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Listenproperty, welche auf die StaticObjects-Liste verweist
        public ObservableCollection<Model.Person> Personenliste { get; set; } = StaticObjects.PersonenListe;

        public PersonenDb_List()
        {
            //GUI-Initialisierung
            InitializeComponent();

            //Zuweisung der lokalen Liste mit den Datenbank-Inhalten
            this.Personenliste = new ObservableCollection<Model.Person>(StaticObjects.Database.GetPeople());

            //Setzen des BindingContextes
            this.BindingContext = this;
        }

        //EventHandler zum Update einer Person
        private void CaMenu_Update_Clicked(object sender, EventArgs e)
        {
            Model.Person p = (sender as MenuItem).CommandParameter as Model.Person;

            p.Vorname = "TEST";

            StaticObjects.Database.UpdatePerson(p);

            this.Personenliste = new ObservableCollection<Model.Person>(StaticObjects.Database.GetPeople());

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Personenliste"));
        }

        //EventHandler zum Löschen einer Person
        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            //Cast des Inhalts der CommandParameter-Property des Sender-Objekts (das ausgewählte ListView-Item) in Person-Objekt
            Model.Person p = (sender as MenuItem).CommandParameter as Model.Person;

            //Anzeige einer 'MessageBox' und Abfrage der User-Antwort
            bool result = await DisplayAlert("Löschen", $"Soll {p.Vorname} {p.Nachname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                //Löschen aus lokaler Liste
                this.Personenliste.Remove(p);

                //Löschen aus Datenbank
                StaticObjects.Database.DeletePerson(p);

            }

            //Ausgabe eines Toasts
            ToastController.ShowToastMessage($"{p.Vorname} {p.Nachname} wurde gelöscht.", ToastDuration.Long);
        }

        //EventHandler zum Speichern der Liste (mittels Json)
        private void TbI_Click_Save(object sender, EventArgs e)
        {
            //Aufruf der Save-Methode des JsonControllers
            JsonController.Save(Personenliste);
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage("Liste gespeichert", ToastDuration.Long);
        }

        //EventHandler zum Laden der Liste (mittels Json)
        private void TbI_Click_Load(object sender, EventArgs e)
        {
            //Neuzuweisung der lokalen Liste mit durch JsonController geladenen Datei
            Personenliste = JsonController.Load<ObservableCollection<Model.Person>>();
            //Aufruf des Events zum Aktualisieren der GUI
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Personenliste"));
            //Ausgabe eines Toasts
            ToastController.ShowToastMessage("Liste geladen", ToastDuration.Long);
        }
    }
}