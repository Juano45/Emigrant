using System;

namespace Emigrante.App.Dominio{
    public class Persona{
        public int Id {get;set;}
        public TipoDoc TipoDoc {get;set;}
        public string NumDoc {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string RazonSocial {get; set;}
        public Genero Genero { get; set; }
        public string FechaNacimiento {get;set;}
        public string Email {get;set;}
        public string NumCelular {get;set;}
        public string DireccionActual {get;set;}
        public string Ciudad {get;set;}
        public string Cargo {get;set;}
    }
}