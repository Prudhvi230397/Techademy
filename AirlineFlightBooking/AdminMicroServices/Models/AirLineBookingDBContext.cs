using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdminMicroServices.Models
{
    public partial class AirLineBookingDBContext : DbContext
    {
        public AirLineBookingDBContext()
        {
        }

        public AirLineBookingDBContext(DbContextOptions<AirLineBookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminDetail> AdminDetails { get; set; }
        public virtual DbSet<PassengerDetail> PassengerDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET358;Initial Catalog=AirLineBookingDB;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminDetail>(entity =>
            {
                entity.Property(e => e.IsAdmin).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<PassengerDetail>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmailId).HasMaxLength(200);

                entity.Property(e => e.FlightNo).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.IsCancelled).HasDefaultValueSql("((0))");

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.PassengerName).HasMaxLength(50);

                entity.Property(e => e.Pnr)
                    .HasMaxLength(50)
                    .HasColumnName("pnr");

                entity.Property(e => e.SeatNo).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
