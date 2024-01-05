using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon_Infrumusetare.Models;

namespace Salon_Infrumusetare.Data
{
    public class Salon_InfrumusetareContext : DbContext
    {
        public Salon_InfrumusetareContext (DbContextOptions<Salon_InfrumusetareContext> options)
            : base(options)
        {
        }

        public DbSet<Salon_Infrumusetare.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Salon_Infrumusetare.Models.Specialist>? Specialist { get; set; }

        public DbSet<Salon_Infrumusetare.Models.Client>? Client { get; set; }

        public DbSet<Salon_Infrumusetare.Models.Programare>? Programare { get; set; }

        public DbSet<Salon_Infrumusetare.Models.Recenzie>? Recenzie { get; set; }
    }
}
