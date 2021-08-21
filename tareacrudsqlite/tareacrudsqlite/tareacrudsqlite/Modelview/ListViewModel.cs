using tareacrudsqlite.Controller;
using tareacrudsqlite.Model;
using tareacrudsqlite.Modelview;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SQLite;
using tareacrudsqlite;

namespace tareacrudsqlite.Modelview
{
    public class ListViewModel : basemodel
    {
  
        Crud crud = new Crud();
        private ObservableCollection<datospersonas> _persons;

        public ObservableCollection<datospersonas> Persons
        {
            get { return _persons; }
            set { _persons = value; OnPropertyChanged(); }
        }

        private datospersonas _selectedPersona;

        public datospersonas SelectedPersona
        {
            get { return _selectedPersona; }
            set { _selectedPersona = value; OnPropertyChanged(); }
        }

        public ICommand IrInformacionCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListViewModel(INavigation navigation)
        {
            Navigation = navigation;
            IrInformacionCommand = new Command<Type>(async (pageType) => await IrInformacion(pageType));

            Persons = new ObservableCollection<datospersonas>();

            mostrar();

        }

        
        public async void mostrar()
        {
            try
            {
                var personasList = await crud.getReadPersonas();
                foreach (var persons in personasList)
                {
                    Persons.Add(new datospersonas
                    {
                        id = persons.id,
                        nombre = persons.nombre,
                        apellido = persons.apellido,
                        correo = persons.correo,
                        direccion = persons.direccion,
                        edad = persons.edad,
                        puesto = persons.puesto,

                    });
                }
                   
              

            }
            catch (SQLiteException e)
            {
                

            }
        }

        async Task IrInformacion(Type pageType)
        {
            if (SelectedPersona != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);

                page.BindingContext = new Viewmodel()
                {
                    Id=SelectedPersona.id,
                    Nombre = SelectedPersona.nombre,
                    Apellido = SelectedPersona.apellido,
                    Edad=SelectedPersona.edad,
                    Puesto=SelectedPersona.puesto,
                    Correo=SelectedPersona.correo,
                    Direccion=SelectedPersona.direccion
                  
                };

                await Navigation.PushModalAsync(page);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Seleccione Persona", "ok");
            }
        }

    }
}