using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace AppLar.Core.Model
{
    
    public class Medicamento
    {
        public Medicamento() { }
        public Medicamento(int id, String nome)
        {
            this.id = id;
            this.nome = nome;
        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(60)]
        public String nome { get; set; }

        public String marca { get; set; }
    }
}
