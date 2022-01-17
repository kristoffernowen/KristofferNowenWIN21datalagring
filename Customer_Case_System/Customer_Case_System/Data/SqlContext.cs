using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Customer_Case_System.Models;

namespace Customer_Case_System.Data
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<CaseDetail> CaseDetails { get; set; } = null!;
        public virtual DbSet<CaseNumber> CaseNumbers { get; set; } = null!;
        public virtual DbSet<ContactInfo> ContactInfos { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<StatusOfCase> StatusOfCases { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\krist\\OneDrive\\Documents\\KN_WIN21\\Datalagring\\Customer_Case_System\\Customer_Case_System\\Data\\Customer_Case_Database.mdf;Integrated Security=True;Connect Timeout=30");
            }                                               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(25);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StreetName).HasMaxLength(50);
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CaseDetail>(entity =>
            {
                entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Administrator)
                    .WithMany(p => p.CaseDetails)
                    .HasForeignKey(d => d.AdministratorId)
                    .HasConstraintName("FK__CaseDetai__Admin__47DBAE45");

                entity.HasOne(d => d.CaseNumbers)
                    .WithMany(p => p.CaseDetails)
                    .HasForeignKey(d => d.CaseNumbersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CaseDetai__CaseN__44FF419A");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.CaseDetails)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CaseDetai__Statu__46E78A0C");
            });

            modelBuilder.Entity<CaseNumber>(entity =>
            {
                entity.Property(e => e.Header).HasMaxLength(25);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CaseNumbers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CaseNumbe__Custo__4222D4EF");
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.ToTable("ContactInfo");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ContactInfos)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactIn__Custo__3B75D760");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Customers__Addre__38996AB5");
            });

            modelBuilder.Entity<StatusOfCase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusOfCase1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("StatusOfCase");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
