using APILambada.Model.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILambada.Model
{
    public class Tecnico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public ICollection<Lambada> Lambadas { get; set; } = new List<Lambada>();

    }
}
