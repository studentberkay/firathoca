using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FiratHoca.Models;

namespace FiratHoca.Data
{
    public class FiratHocaContext : DbContext
    {
        public FiratHocaContext (DbContextOptions<FiratHocaContext> options)
            : base(options)
        {
        }

        // c#: Bebekler listesi    -----migrations, savechanges-----> sqlite:Bebekler tablosuna 
        public DbSet<Bebek> Bebekler { get; set; }

        // c#: Resimler listesi    -----migrations, savechanges-----> sqlite:Resimler tablosuna 
        public DbSet<Resim> Resimler { get; set; }
    }
}
