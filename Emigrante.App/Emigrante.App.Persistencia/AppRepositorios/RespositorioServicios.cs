using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Emigrante.App.Dominio;

namespace Emigrante.App.Persistencia{
    public class RepositorioServicio : IRepositorioServicio
    {
        private readonly Contexto _contexto;
        public RepositorioServicio(Contexto contexto){
            _contexto = contexto;
        }
        public Servicio AddServicio(Servicio servicio)
        {
            /*Primera Restricción: Un Migrante no puede tener dos servicios de la misma categoria al mismo tiempo
            El migrante no puede solicitar un servicio en una fecha posterior a la aportada por la entidad*/
            
            /*El Migrante no puede tener dos servicios de la misma categoria*/
            Servicio servicioAgregado = _contexto.Add(servicio).Entity;
            _contexto.SaveChanges();
            return servicioAgregado;
        }
        public IEnumerable<Servicio> GetAllServicios()
        {
            return _contexto.Servicios.Include("Migrante").Include("Entidad").Include("Estado").Include("Categoria"); 
        }
        public Servicio GetServicio(int Id) 
        {
            return _contexto.Servicios.Include("Migrante").Include("Entidad").FirstOrDefault(s => s.Id == Id);
        }
        public Servicio UpdateServicio(Servicio servicio)
        {
            Servicio servicioEditar = _contexto.Servicios.FirstOrDefault(s => s.Id == servicio.Id);
            if (servicioEditar == null){
                servicioEditar.Migrante = servicio.Migrante;
                servicioEditar.Entidad = servicio.Entidad;
                servicioEditar.Estado = servicio.Estado;
                servicioEditar.FechaInicio = servicio.FechaInicio;
                servicioEditar.FechaFinal = servicio.FechaFinal;
                servicioEditar.FechaSolicitud = servicio.FechaSolicitud;
                servicioEditar.Cupos = servicio.Cupos;
                servicioEditar.Categoria = servicio.Categoria;
                servicioEditar.Descripcion = servicio.Descripcion;
            }
            return servicioEditar;
        }
    }
}