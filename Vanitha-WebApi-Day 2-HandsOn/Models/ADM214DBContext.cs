using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vanitha_WebApi_Day_2_HandsOn.Models
{
    public class ADM214DBContext : DbContext
    {
        public ADM214DBContext()
        {
        }

        public ADM214DBContext(DbContextOptions<ADM214DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> EMPLs { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; database=ADM21; integrated security=true");
            }
        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Employee__AF2DBB995C0BD1CF");

                entity.ToTable("EMPL");

                entity.HasIndex(e => e.Name, "ENAME_IDX");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__Department__AF2DBB995C0BD1CF");

                entity.ToTable("DEPARTMENT");

                entity.HasIndex(e => e.DepartmentName, "DNAME_IDX");

                entity.Property(e => e.DId).ValueGeneratedNever();



            });
        }
    }
}