using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using X_Forms.BspMVVM.Model;
using X_Forms.BspMVVM.Services;
using Xamarin.Forms;

namespace X_Forms.BspMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Page ContextPage { get; set; }

        public DbService Datenbank { get; set; }

        public string NeuerVorname { get; set; }
        public string NeuerNachname { get; set; }

        public bool IsRefreshing { get; set; }

        public ObservableCollection<Person> Personenliste { get; set; }

        public Command HinzufügenCmd { get; set; }
        public Command LöschenCmd { get; set; }
        public Command RefreshCmd { get; set; }


        public MainViewModel()
        {
            Datenbank = new DbService();

            Personenliste = new ObservableCollection<Person>(Datenbank.GetPeople());

            HinzufügenCmd = new Command(AddPerson);
            LöschenCmd = new Command(DeletePerson);
            RefreshCmd = new Command(RefreshList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddPerson()
        {
            Person neuePerson = new Person()
            {
                Vorname = NeuerVorname,
                Nachname = NeuerNachname
            };

            Personenliste.Add(neuePerson);
            Datenbank.AddPerson(neuePerson);

            NeuerVorname = String.Empty;
            NeuerNachname = String.Empty;

            UpdateGUI(nameof(NeuerVorname));
            UpdateGUI(nameof(NeuerNachname));
        }

        private async void DeletePerson(object person)
        {
            bool result = await ContextPage.DisplayAlert("Löschen", "Soll diese Person wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            {
                Datenbank.DeletePerson(person as Person);
                Personenliste.Remove(person as Person);
            }
        }

        private void RefreshList()
        {
            Personenliste = new ObservableCollection<Person>(Datenbank.GetPeople());
            IsRefreshing = false;

            UpdateGUI(nameof(IsRefreshing));
            UpdateGUI(nameof(Personenliste));
        }

        private void UpdateGUI(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
