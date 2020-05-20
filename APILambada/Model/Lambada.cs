using System;

namespace APILambada.Model
{
    public class Lambada
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLambada { get; set; }
        public int TecnicoId { get; set; }
        public  Tecnico Tecnico { get; set; }
    }
}
