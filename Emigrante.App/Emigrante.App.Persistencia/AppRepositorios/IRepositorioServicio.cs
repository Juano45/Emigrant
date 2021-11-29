using System.Collections.Generic;
using System.Linq;
using Emigrante.App.Dominio;

namespace Emigrante.App.Persistencia{
    public interface IRepositorioServicio{
        IEnumerable<Servicio> GetAllServicios();
        Servicio GetServicio(int Id);
        Servicio AddServicio(Servicio servicio);
        Servicio UpdateServicio(Servicio servicio);
    }
}