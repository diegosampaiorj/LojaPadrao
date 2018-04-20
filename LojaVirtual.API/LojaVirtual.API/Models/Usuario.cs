using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtual.API.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
        public string permissao { get; set; }

    }
}