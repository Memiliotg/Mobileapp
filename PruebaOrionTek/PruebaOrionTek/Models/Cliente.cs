using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PruebaOrionTek.Models
{
    public class Cliente
    {
        [PrimaryKey,AutoIncrement]
        public int? Id {get;set;}
        public string Nombre { get; set; }
        public int? IdEmpresa { get; set; }  
    }
}
