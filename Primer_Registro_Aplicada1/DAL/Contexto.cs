using Microsoft.EntityFrameworkCore;
using Primer_Registro_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primer_Registro_Aplicada1.DAL
{
   public class Contexto : DbContext
    {
        public DbSet<Roles> Roles { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Roles.db");
        }

    }
}
