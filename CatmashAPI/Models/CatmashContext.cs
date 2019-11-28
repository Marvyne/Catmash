using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatmashAPI.Models
{
    public partial class CatmashContext : DbContext
    {
        public CatmashContext()
        {
        }

        public CatmashContext(DbContextOptions<CatmashContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Cat> Cat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

                //Marvyne
                 optionsBuilder.UseSqlServer("Server=MARVYNE\\SQLEXPRESS;Database=BlogNet;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>()
                .Property(b => b.Url)
                .IsRequired();
        }
    }
}
