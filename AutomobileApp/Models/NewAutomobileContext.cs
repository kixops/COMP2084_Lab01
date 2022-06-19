using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AutomobileApp.Models
{
    public partial class NewAutomobileContext : DbContext
    {
        public NewAutomobileContext()
        {
        }

        public NewAutomobileContext(DbContextOptions<NewAutomobileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AutoMobileCompany> AutoMobileCompany { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoMobileCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__auto_mob__3E26723526069BB2");

                entity.ToTable("auto_mobile_company");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedDateTime).HasColumnName("created_date_time");

                entity.Property(e => e.Foundation)
                    .HasColumnName("foundation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__cars__4C9A0DB39CD9DD3E");

                entity.ToTable("cars");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedDateTime).HasColumnName("created_date_time");

                entity.Property(e => e.Foundation)
                    .HasColumnName("foundation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Auto_Mobile_Car");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
