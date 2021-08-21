using System;
using System.Collections.Generic;
using System.Text;

namespace tareacrudsqlite.Controller
{
    public class Validar
    {
        bool respuesta;
        public bool validarPersona(string nombre,string apellido,int edad,string correo,string direccion)
        {
           
            respuesta = (nombre == null || apellido == null || edad.Equals("") || correo == null || direccion == null) ? false : true;

            return respuesta;
        }
        



    }
}
