using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace tareacrudsqlite.Controller
{
    public class Conexion {
       private string pathdb;
        public Conexion() { }


       public string Conector()
        {
            string dbname = "db.sqlite";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            pathdb = Path.Combine(path, dbname);
            return pathdb;
        }

        public SQLiteConnection Conn()
        {
            SQLiteConnection conn = new SQLiteConnection(App.UBICACIONDB);
            return conn;
        }


        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(App.UBICACIONDB);
        }


    }
}
