using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusFinder_2.Models;

namespace BusFinder_2.Dados
{
    public class BusFinderContext : DbContext
    {
        public BusFinderContext(DbContextOptions<BusFinderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItinerarioVeiculo>()
                .HasKey(ac => new { ac.VeiculoId, ac.ItinerarioId });
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Arduino> Arduinos { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
        public DbSet<BusFinder_2.Models.ItinerarioVeiculo> ItinerarioVeiculo { get; set; }
    }
}
