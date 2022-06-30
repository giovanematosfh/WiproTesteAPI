using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wipro.Fila.Domain.Entities;

namespace Wipro.Fila.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ItemFila> ItemFilas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<ItemFila>().Property(x => x.Id);
            modelBuilder.Entity<ItemFila>().Property(x => x.Moeda);
            modelBuilder.Entity<ItemFila>().Property(x => x.Data_Inicio);
            modelBuilder.Entity<ItemFila>().Property(x => x.Data_Fim);

        }
    }
}
