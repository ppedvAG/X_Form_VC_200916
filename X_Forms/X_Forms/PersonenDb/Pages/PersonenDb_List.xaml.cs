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

        private void TbI_Click_Save(object sender, EventArgs e)
        {
            JsonController.Save(Personenliste);

            ToastController.ShowToastMessage("Liste gespeichert", ToastDuration.Long);
        }
        
        private void TbI_Click_Load(object sender, EventArgs e)
        {
            Personenliste = JsonController.Load<ObservableCollection<Model.Person>>();

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Personenliste"));

            ToastController.ShowToastMessage("Liste geladen", ToastDuration.Long);
        }
    }
}