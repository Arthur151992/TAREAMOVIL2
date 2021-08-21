using tareacrudsqlite.Model;
using System;
using System.Collections.Generic;
using System.Text;
using tareacrudsqlite.Controller;
using SQLite;
using System.Threading.Tasks;

namespace tareacrudsqlite.Controller
{
    public class Crud
    {
        Conexion conn = new Conexion();



        public Task<List<datospersonas>> getReadPersonas()
        {
            return conn.GetConnectionAsync().Table<datospersonas>().ToListAsync();
        }

        public Task<datospersonas> getPersonasId(int id)
        {
            return conn
                .GetConnectionAsync()
                .Table<datospersonas>()
                .Where(item => item.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> getPersonasUpdateId(datospersonas personas)
        {
            return conn
                .GetConnectionAsync()
                .UpdateAsync(personas);

        }

        public Task<int> Delete(datospersonas personas)
        {
            return conn
                .GetConnectionAsync()
                .DeleteAsync(personas);
        }


    }
}