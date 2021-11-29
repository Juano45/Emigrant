using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Emigrante.App.Dominio;
using Emigrante.App.Persistencia;



namespace Emigrante.App.Frontend.Pages
{
    public class AddUsuarioModel : PageModel
    {
        private readonly IRepositorioUsuarioGerencia repositorioUsuario;
        public UsuarioGerencia usuario {get; set;}

        public AddUsuarioModel(IRepositorioUsuarioGerencia repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
            UsuarioGerencia usuario = new UsuarioGerencia();
        }
        public void OnGet()
        {

        }
    }
}
