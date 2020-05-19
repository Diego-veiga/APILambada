using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILambada.Model
{
    public class Lambada
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLambada { get; set; }
        public int TecnicoId { get; set; }
        public virtual Tecnico Tecnico { get; set; }
    }
}
