using CRUDEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace CRUDEF
{
    public class SchoolContext: DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=CPU0118\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Skills)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasColumnType("money");

                entity.Property(e => e.AddedOn)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }

   
}
