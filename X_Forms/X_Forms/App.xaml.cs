using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    public partial class App : Application
    {
        //Die App-Klasse beinhaltet eine grundlegen Initialisierung der App sowie die MainPage-Property, welche defniert,
        //welche Page gerade in der App angezeigt wird. Diese Property wird auch als Einstiegspunkt verwendet.
        public App()
        {
            InitializeComponent();

            //Zuweisung der MainPage-Property zu einer Page
            //MainPage = new MainPage();

            //Zuweisung der MainPage-Property zu einer NavigationPage (ermöglicht Stack-Navigation) mit Angabe der Startpage.
            //MainPage = new NavigationPage(new MainPage());

            //Zuweisung der MainPage-Property zu einer MasterDetailPage (vgl. BspLayouts/MasterDetail)
            MainPage = new Navigation.MasterDetail.MDP();
        }

        public DateTime TimeStamp { get; set; }

        //Methoden, welche zu bestimmten globalen Events ausgeführt werden (Start, Unterbrechen der App [Sleep], Wiederaktivierung der App [Resume])
        protected override void OnStart()
        {
            TimeStamp = DateTime.Now;
            ((MainPage as Navigation.MasterDetail.MDP).Detail as NavigationPage).CurrentPage.DisplayAlert("Time", "Starttime: " + TimeStamp.ToLongTimeString(), "Ok");
        }

        protected override void OnSleep()
        {
            TimeStamp = DateTime.Now;
        }

        protected override void OnResume()
        {
            ((MainPage as Navigation.MasterDetail.MDP).Detail as NavigationPage).CurrentPage.DisplayAlert("Time", "Sleeping timespan: " + DateTime.Now.Subtract(TimeStamp).TotalSeconds, "Ok");
        }

        public static System.Collections.ObjectModel.ObservableCollection<Uebungen.GoogleBooks.Model.Item> BookList { get; set; }
    }
}
