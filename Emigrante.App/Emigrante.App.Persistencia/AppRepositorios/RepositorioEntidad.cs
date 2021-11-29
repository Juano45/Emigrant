using System;
using System.Collections.Generic;
using Emigrante.App.Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace Emigrante.App.Persistencia{
    public class RepositorioEntidad : IRepositorioEntidad
    {
        private readonly Contexto _contexto;
        //private readonly Security security;
        public RepositorioEntidad(Contexto contexto){
            _contexto = contexto;
            //security = new Security();
        }
        public Entidad AddEntidad(Entidad entidad)
        {
            //Entidad.password = security.GetMD5Hash(entidad.password);
            Entidad entidadNueva = _contexto.Add(entidad).Entity;
            _contexto.SaveChanges();
            return entidadNueva;
        }
        public Entidad UpdateEntidad(Entidad entidad)
        {
            //entidad.password = security..GetMD5Hash(entidad.password);
            var entidadActualizar = _contexto.Entidades.Where(x=> x.Id == entidad.Id).FirstOrDefault();

            if (entidadActualizar != null){
                entidadActualizar.TipoDoc = entidad.TipoDoc;
                entidadActualizar.NumDoc = entidad.NumDoc;
                entidadActualizar.Nombres = entidad.Nombres;
                entidadActualizar.Apellidos = entidad.Apellidos;
                entidadActualizar.Cargo = entidad.Cargo;
                entidadActualizar.RazonSocial = entidad.RazonSocial;
                entidadActualizar.Ciudad = entidad.Ciudad;
                entidadActualizar.PaginaWeb = entidad.PaginaWeb;
                entidadActualizar.DireccionActual = entidad.DireccionActual;
                entidadActualizar.NumCelular = entidad.NumCelular;
                entidadActualizar.Categoria = entidad.Categoria;
                entidadActualizar.Sector = entidad.Sector;
                //entidad.Username = entidad.Username;
                //entidadActualizar.password = entidad.password;
                _contexto.SaveChanges();
            }
            return entidadActualizar;
        }
        public IEnumerable<Entidad> ReadEntidades()
        {
            return _contexto.Entidades;
        }
        public Entidad ObtenerEntidad(string NumDoc)
        {
            Entidad entidadEncontrada = _contexto.Entidades.Where(x => x.NumDoc == NumDoc).FirstOrDefault();
            return entidadEncontrada;
        }
        public void DeleteEntidad (string NumDoc)
        {
            Entidad entidadEncontrada = _contexto.Entidades.Where(x => x.NumDoc == NumDoc).FirstOrDefault();
            if(entidadEncontrada != null){
                _contexto.Entidades.Remove(entidadEncontrada);
                _contexto.SaveChanges();
            }
        }
    }
}
     