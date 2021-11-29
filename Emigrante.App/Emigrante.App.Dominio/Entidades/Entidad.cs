using System;

namespace Emigrante.App.Dominio{
    public class Entidad:Persona{
        
        public string PaginaWeb {get;set;}
        public Sector Sector {get;set;}
        public Categoria Categoria { get; set; }
    }
}