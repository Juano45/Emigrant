using System;
using System.Collections.Generic;
using Emigrante.App.Dominio;

namespace Emigrante.App.Persistencia{
    public interface IRepositorioEntidad{
        IEnumerable <Entidad> ReadEntidades();
        Entidad AddEntidad(Entidad entidad);
        Entidad UpdateEntidad(Entidad entidad);
        void DeleteEntidad (string NumDoc);
        Entidad ObtenerEntidad(string NumDoc);
    } 
}