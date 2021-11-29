using System;

namespace Emigrante.App.Dominio{
    public class Grupo{
        public int Id { get; set; }
        public string Relacion { get; set; }
        public Migrante Migrante { get; set; }
    }
}