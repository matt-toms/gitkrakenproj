
using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace testApp.Code
{

    public interface IMattContext
    {

    }



    public partial class MattContext : DbContext, IMattContext
    {
        public MattContext()
        {
        }

        public MattContext(DbContextOptions<MattContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=localhost\\mattdb;User ID=sa;Password=123;Initial Catalog=testdb;Integrated Security=True;Persist Security Info=False;MultipleActiveResultSets=False;";

                optionsBuilder.UseSqlServer(connectionString);
                //  optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.productname).HasMaxLength(250);

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}