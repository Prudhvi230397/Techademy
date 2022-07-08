using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TicketWebServices.Models
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
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
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

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId);

                entity.Property(e => e.Boarding)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.FlightNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pnr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pnr");

                entity.Property(e => e.RoundTripEndDateTime).HasColumnType("datetime");

                entity.Property(e => e.RoundTripFlightNo).HasMaxLength(50);

                entity.Property(e => e.RoundTripStartDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<PassengerDetail>(entity =>
            {
                entity.HasKey(e => e.PassengerId);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Meal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PassengerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Pnr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("pnr");

                entity.Property(e => e.SeatNo)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
