using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Emigrante.App.Dominio;
using Emigrante.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Emigrante.App.Frontend.Pages
{
    public class AddServicioModel : PageModel
    {
        private readonly IRepositorioServicio repositorioServicio;
        private readonly IRepositorioMigrante repositorioMigrante;
        private readonly IRepositorioEntidad repositorioEntidad;
        public Servicio Servicio { get; set; }
        public SelectList Migrantes { get; set; }
        public SelectList Entidades { get; set; }

        public string NumDocEntidad { get; set; }
        public string NumDocMigrante { get; set; }
        public string mensaje { get; set; }

        public AddServicioModel(IRepositorioServicio repositorioServicio, IRepositorioEntidad repositorioEntidad, IRepositorioMigrante repositorioMigrante)
        {
            this.repositorioServicio = repositorioServicio;
            this.repositorioEntidad = repositorioEntidad;
            this.repositorioMigrante = repositorioMigrante;
            Servicio = new Servicio();
            Migrantes = new SelectList(repositorioMigrante.ReadMigrantes(), nameof(Migrante.NumDoc), nameof(Migrante.Nombres),nameof(Migrante.Apellidos));
            Entidades = new SelectList(repositorioEntidad.ReadEntidades(), nameof(Entidad.NumDoc), nameof(Entidad.RazonSocial),nameof(Entidad.Ciudad));
        }
        public IActionResult OnPost(Servicio Servicio, string NumDocMigrante, string NumDocEntidad)
        {
                Entidad Entidad = repositorioEntidad.ObtenerEntidad(NumDocEntidad);
                Migrante Migrante = repositorioMigrante.ReadMigrante(NumDocMigrante);

                Servicio NuevoServicio = new Servicio();
               
        
        }
    }
}