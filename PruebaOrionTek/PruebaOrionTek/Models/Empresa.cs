using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaOrionTek.Models
{
    public class Empresa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Nombre { set; get; }    
    }
}
