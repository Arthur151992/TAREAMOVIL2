using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tareacrudsqlite.Modelview;
using Xamarin.Forms;

namespace tareacrudsqlite
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Viewmodel();
        }



        private async void lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inicio());
        }
    }
}
