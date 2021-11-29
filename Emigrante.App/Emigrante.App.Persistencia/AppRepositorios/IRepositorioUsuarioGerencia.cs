using System.Collections.Generic;
using Emigrante.App.Dominio;

namespace Emigrante.App.Persistencia
{
    public interface IRepositorioUsuarioGerencia{
        IEnumerable<UsuarioGerencia> GetUsuariosGerencia();
        UsuarioGerencia GetUsuarioGerencia(string NumDoc);
        void DeleteUsuariosGerencia(string NumDoc);
        UsuarioGerencia AddUsuarioGerencia(UsuarioGerencia usuariogerencia);
    } 
}