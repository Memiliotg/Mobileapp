using PruebaOrionTek.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaOrionTek.Helpers
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Cliente>().Wait();
            db.CreateTableAsync<Empresa>().Wait();
            db.CreateTableAsync<Direcciones>().Wait();
        }

        //Insert Data
        public Task<int> CreateClientesAsync(Cliente cliente)
        {
            return db.InsertAsync(cliente);
        }

        public Task<int> CreateEmpresaAsync(Empresa empresa)
        {
            return db.InsertAsync(empresa);
        }

        public Task<int> CreateDireccionAsync(Direcciones direcciones)
        {
            return db.InsertAsync(direcciones);
        }

        // Get Data

        public Task<List<Cliente>> GetClientesAsync()
        {
            return db.Table<Cliente>().ToListAsync();
        }

        public Task<List<Empresa>> GetEmpresaAsync()
        {
            return db.Table<Empresa>().ToListAsync();
        }

        public Task<List<Direcciones>> GetDireccionesAsync(int Id)
        {
            Console.WriteLine("*****************"+Id+"************");
            return db.Table<Direcciones>().Where(x=> x.IdCliente == Id).ToListAsync();
           
        }


        //Delete Data

        public Task<int> DeleteEmpresaAsync(Empresa empresa)
        {
            return db.DeleteAsync(empresa);
        }

        public Task<int> DeleteClienteAsync(Cliente cliente)
        {
            return db.DeleteAsync(cliente);
        }

        public Task<int> DeleteDireccionesAsync(Direcciones direcciones)
        {
            return db.DeleteAsync(direcciones);
        }

        //Update Data
        public Task<int> UpdateEmpresaAsync(Empresa empresa)
        {
            return db.UpdateAsync(empresa);
        }

        public Task<int> UpdateClienteAsync(Cliente cliente)
        {
            return db.UpdateAsync(cliente);
        }

        public Task<int> UpdateDireccionesAsync(Direcciones direcciones)
        {
            return db.UpdateAsync(direcciones);
        }


        // Search
        public Task<List<Cliente>> Search(string search)
        {
            return db.Table<Cliente>().Where(x=> x.Nombre.StartsWith(search)).ToListAsync();
        }



    }
}
