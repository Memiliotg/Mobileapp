using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaOrionTek.Models
{
    public class Direcciones
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; } 
        public string Direccion { get; set; }  
        public int? IdCliente { get; set; }
    }
}
