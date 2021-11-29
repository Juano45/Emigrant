using System.Collections.Generic;
using Emigrante.App.Dominio;

namespace Emigrante.App.Persistencia{

    public interface IRepositorioMigrante {
        IEnumerable<Migrante> ReadMigrantes();
        Migrante ReadMigrante(string NumDoc);
        Migrante UpdateMigrante(Migrante migrante);
        void DeleteMigrante(string NumDoc);
        Migrante AddMigrante(Migrante migrante);
    }
}