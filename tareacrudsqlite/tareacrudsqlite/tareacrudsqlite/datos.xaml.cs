using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tareacrudsqlite.Modelview;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tareacrudsqlite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class datos : ContentPage
    {
        public datos()
        {
            InitializeComponent();
            BindingContext = new Viewmodel();
        }
    }
}