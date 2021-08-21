using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using tareacrudsqlite.Controller;
using tareacrudsqlite.Model;
using Xamarin.Forms;

namespace tareacrudsqlite.Modelview
{
    public class Viewmodel : basemodel
    {
        Conexion conn = new Conexion();
        Crud crud = new Crud();
        private int id;
        private string _nombre;
        private string _apellido;
        private string _correo;
        private double _edad;
        private string _direccion;
        private string _puesto;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(); }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(); }
        }
        public double Edad
        {
            get { return _edad; }
            set { _edad = value; OnPropertyChanged(); }
        }
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; OnPropertyChanged(); }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; OnPropertyChanged(); }
        }
        public string Puesto
        {
            get { return _puesto; }
            set { _puesto = value; OnPropertyChanged(); }
        }
        public async void Guardar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de nombre vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Apellido vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Edad.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de edad vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Correo))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de correo vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Direccion))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de direccion vacio", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Puesto))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de puesto vacio", "Ok");
                return;
            }
            var personas = new datospersonas()
            {
                id = Id,
                nombre = Nombre,
                apellido = Apellido,
                edad = Edad,
                direccion = Direccion,
                correo = Correo,
                puesto = Puesto

            };

            try
            {


                conn.Conn().CreateTable<datospersonas>();
                conn.Conn().Insert(personas);
                conn.Conn().Close();

                await App.Current.MainPage.DisplayAlert("Success", "Datos Guardados", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new Inicio());


            }
            catch (SQLiteException)
            {
                await App.Current.MainPage.DisplayAlert("Warning", "Correo Ya existe", "Ok");
            }
        }
    

    public ICommand ClearCommand { private set; get; }
    public ICommand SendEmailCommand { private set; get; }

    public Viewmodel()
    {
        ClearCommand = new Command(() => Clear());

    }

    public ICommand GuardarCommand
    {
        get { return new Command(() => Guardar()); }
    }
    public ICommand DeleteCommand { get { return new Command(() => eliminar()); } }
    public ICommand UpdateCommand { get { return new Command(() => actualizar()); } }
    void Clear()
    {

        Nombre = string.Empty;
        Apellido = string.Empty;
        Correo = string.Empty;
        Direccion = string.Empty;
        Puesto = string.Empty;


    }
    async void eliminar()
    {
        var persona = await crud.getPersonasId(Convert.ToInt32(Id));
        bool conf = await App.Current.MainPage.DisplayAlert("Delete", "Eliminar Persona", "Accept", "Cancel");
        if (conf)
        {
            if (persona != null)
            {
                await crud.Delete(persona);
                await App.Current.MainPage.DisplayAlert("Delete", "Datos Eliminados", "ok");
                Clear();
                await App.Current.MainPage.Navigation.PopModalAsync();

            }
        }

    }
    async void actualizar()
    {

        bool conf = await App.Current.MainPage.DisplayAlert("Update", "Actualizar datos de Empleado", "Accept", "Cancel");
        if (conf)
        {
            if (!string.IsNullOrEmpty(Id.ToString()))
            {
                datospersonas update = new datospersonas
                {
                    id = Convert.ToInt32(Id.ToString()),
                    nombre = Nombre,
                    apellido = Apellido,
                    edad = Convert.ToDouble(Edad),
                    direccion = Direccion,
                    correo = Correo,
                    puesto = Puesto
                };
                await crud.getPersonasUpdateId(update);
                await App.Current.MainPage.DisplayAlert("Update", "Datos Actualizados", "ok");
                await App.Current.MainPage.Navigation.PopModalAsync();

            }
        }

    }

        private string name;

        public string Name { get => name; set => SetProperty(ref name, value); }

    }
}

