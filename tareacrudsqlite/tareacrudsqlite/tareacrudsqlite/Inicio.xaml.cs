using tareacrudsqlite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using tareacrudsqlite.Model;
using tareacrudsqlite.Modelview;

namespace tareacrudsqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {

        public Inicio()
        {
            InitializeComponent();

            OnAppearing();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new Modelview.ListViewModel(Navigation);
        }

        private void menuToolbar_Clicked(object sender, EventArgs e)
        {

        }






    }
}