using System.Collections.Generic;
using System.Linq;
using Emigrante.App.Dominio;

namespace Emigrante.App.Persistencia{
    public class RepositorioUsuarioGerencia : IRepositorioUsuarioGerencia
    {
        private readonly Contexto _contexto;
        //private Security security;

        public RepositorioUsuarioGerencia(Contexto context){
            _contexto = context;
            //security = new Security();
        }

        public UsuarioGerencia AddUsuarioGerencia(UsuarioGerencia usuariogerencia)
        {
            //usuariogerencia.password = security.GetMD5Hash(usuariogerencia.password);
            UsuarioGerencia usuarionuevo = _contexto.Add(usuariogerencia).Entity;
            _contexto.SaveChanges();
            return usuarionuevo;
        }
        public UsuarioGerencia UpdateUsuarioGerencia(UsuarioGerencia usuariogerencia)
        {
            //usuariogerencia,password = security.GetMD5Hash(Usuariogerencia.password);
            UsuarioGerencia usuarioEncontrado = _contexto.UsuariosGerencia.FirstOrDefault(u => u.NumDoc == usuariogerencia.NumDoc);

            if (usuarioEncontrado == null)
            {
                usuarioEncontrado.TipoDoc = usuariogerencia.TipoDoc;
                usuarioEncontrado.NumDoc = usuariogerencia.NumDoc;
                usuarioEncontrado.Nombres = usuariogerencia.Nombres;
                usuarioEncontrado.Apellidos = usuariogerencia.Apellidos;
                usuarioEncontrado.Email = usuariogerencia.Email;
                usuarioEncontrado.Dependencia = usuariogerencia.Dependencia;
                usuarioEncontrado.Cargo = usuariogerencia.Cargo;
                _contexto.SaveChanges();
            }
            return usuarioEncontrado;
        }
        public UsuarioGerencia GetUsuarioGerencia(string NumDoc)
        {
            UsuarioGerencia usuariogerencia = _contexto.UsuariosGerencia.FirstOrDefault(u => u.NumDoc == NumDoc);
            return usuariogerencia;
        }
        public IEnumerable<UsuarioGerencia> GetUsuariosGerencia()
        {
            return _contexto.UsuariosGerencia;
        }
        public void DeleteUsuariosGerencia(string NumDoc)
        {
            UsuarioGerencia usuariogerencia = _contexto.UsuariosGerencia.FirstOrDefault(u => u.NumDoc == NumDoc);
            if (usuariogerencia == null)
            {
                _contexto.UsuariosGerencia.Remove(usuariogerencia);
                _contexto.SaveChanges();
            }
        }
    }
}
