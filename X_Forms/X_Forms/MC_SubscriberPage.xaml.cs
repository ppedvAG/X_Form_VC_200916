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
        public MC_SubscriberPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MainPage, string>(this, "Nachricht", SetzeText);
        }

        private void SetzeText(object sender, string text)
        {
            Lbl_Main.Text = text;
        }
    }
}