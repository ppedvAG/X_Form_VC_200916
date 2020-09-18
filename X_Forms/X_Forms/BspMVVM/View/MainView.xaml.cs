using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.BspMVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        //Im CodeBehind der Views sollte nichts stehen, außer dem Konstruktor, welche die InitializeComponent()-Methode aufruft
        public MainView()
        {
            InitializeComponent();
        }
    }
}