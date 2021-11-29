using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Emigrante.App.Dominio{
    public class Servicio{

        [Key]        
        public int Id { get; set; }
        public Migrante Migrante { get; set; }
        public Entidad Entidad { get; set; }

        //Conforme a los formularios para cada uno

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set;}
        public DateTime FechaSolicitud { get; set;}
        public Categoria Categoria { get; set; }
        public int Cupos { get; set; }
        public Estado Estado { get; set; }
        public String Descripcion { get; set; }    
    }
}