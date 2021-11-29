using System.Collections.Generic;
using Emigrante.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;



namespace Emigrante.App.Persistencia{
    public class RepositorioMigrante : IRepositorioMigrante
        {
        private readonly Contexto _contexto;
        //private readonly Security security;
        
        public RepositorioMigrante(Contexto contexto){
            _contexto = contexto;
            //security = new Security();
        }

        public Migrante AddMigrante(Migrante migrante)
        {
            //migrante.password = security.GetMD5Hash(migrante.password);
            Migrante migranteRegistrado =_contexto.Add(migrante).Entity;
            _contexto.SaveChanges();
            return migranteRegistrado;
        }

        public Migrante UpdateMigrante(Migrante migrante)
        {
            //migrante.password = security.GetMD5Hash(migrante.password);
            Migrante migranteUpdate = _contexto.Migrantes.FirstOrDefault(n => n.Id == migrante.Id);
            if(migranteUpdate !=null){
                migranteUpdate.TipoDoc = migrante.TipoDoc;
                migranteUpdate.NumDoc = migrante.NumDoc;
                migranteUpdate.FechaNacimiento = migrante.FechaNacimiento;
                migranteUpdate.Genero = migrante.Genero;
                migranteUpdate.Email = migrante.Email;
                //migranteUpdate.password = migrante.password;
                //migranteUpdate.Username = migranteUpdate.Username;
                migranteUpdate.NumCelular = migrante.NumCelular;
                migranteUpdate.DireccionActual = migrante.DireccionActual;
                migranteUpdate.Ciudad = migrante.Ciudad;
                migranteUpdate.Situacionlaboral = migrante.Situacionlaboral;
                _contexto.SaveChanges();
            }
            return migranteUpdate;
        }

        public void DeleteMigrante(string NumDoc)
        {
            Migrante migranteEliminar = _contexto.Migrantes.FirstOrDefault(n => n.NumDoc == NumDoc);
            if (migranteEliminar !=null){
                _contexto.Migrantes.Remove(migranteEliminar);
                _contexto.SaveChanges();
            }
        }

        public Migrante ReadMigrante(string NumDoc)
        {
        Migrante migranteBuscado = _contexto.Migrantes.Include("entidad").Include("grupo").FirstOrDefault(n=>n.NumDoc == NumDoc);
        return migranteBuscado;
        }

        public IEnumerable<Migrante> ReadMigrantes()
        {
            return _contexto.Migrantes.Include("entidad").Include("grupo");
        }
    }
}