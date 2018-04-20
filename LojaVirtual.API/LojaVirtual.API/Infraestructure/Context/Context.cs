using LojaVirtual.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LojaVirtual.API.Infraestructure.Context
{
    public class Context : DbContext
    {
        public Context() : base("LojaPadrao")
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}