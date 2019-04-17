using CoopSoftNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoopSoftNetCore.Context
{
    public class DbContextCS : DbContext
    {
        public DbContextCS(DbContextOptions<DbContextCS> options) : base (options)
        {

        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
    }
}
