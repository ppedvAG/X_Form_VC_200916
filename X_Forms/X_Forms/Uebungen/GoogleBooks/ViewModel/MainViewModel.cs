using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using X_Forms.Uebungen.GoogleBooks.Model;
using System.Threading.Tasks;


//vgl. BspMVVM/ViewModel
namespace X_Forms.Uebungen.GoogleBooks.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Interface-Event
        public event PropertyChangedEventHandler PropertyChanged;

        //Properties für DataBinding
        public string SearchString { get; set; }
        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { isRefreshing = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing")); }
        }
        public Command SearchCommand { get; set; }
        public ObservableCollection<Item> BookList
        {
            get
            {
                //Zugriff auf die Bücherliste (hier als statisches Object in App.xaml / statische Klasse im Model)
                return App.BookList;
            }
            set
            {
                App.BookList = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BookList)));
            }
        }

        //Command-Methode
        private async void SearchBooks()
        {
            //Damit die View die 'Ladeschnecke' des ListViews anzeigen kann muss diese Methode in einem seperaten Task laufen
            await Task.Run(() =>
            {
                IsRefreshing = true;
                GBook gBook = Services.BookService.FindBooks(SearchString);
                BookList = new ObservableCollection<Item>(gBook.Items);
                IsRefreshing = false;
            });
        }

        //Konstruktor
        public MainViewModel()
        {
            BookList = new ObservableCollection<Item>();

            SearchCommand = new Command(SearchBooks);
        }

    }
}
