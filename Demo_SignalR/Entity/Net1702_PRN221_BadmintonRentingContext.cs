using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Demo_SignalR.Entity
{
    public partial class Net1702_PRN221_BadmintonRentingContext : DbContext
    {
        public Net1702_PRN221_BadmintonRentingContext()
        {
        }

        public Net1702_PRN221_BadmintonRentingContext(DbContextOptions<Net1702_PRN221_BadmintonRentingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BadmintonField> BadmintonFields { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedules { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=(local);database=Net1702_PRN221_BadmintonRenting;uid=sa;password=1234567890;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadmintonField>(entity =>
            {
                entity.ToTable("BadmintonField");

                entity.Property(e => e.BadmintonFieldId).HasColumnName("BadmintonFieldID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BadmintonFieldName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.HasIndex(e => e.CustomerId, "IX_Booking_CustomerId");

                entity.Property(e => e.BookingType)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedAt).HasColumnType("date");

                entity.Property(e => e.IsStatus)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__UserId__398D8EEE");
            });

            modelBuilder.Entity<BookingBadmintonFieldSchedule>(entity =>
            {
                entity.HasKey(e => e.OrderBadmintonFieldScheduleId)
                    .HasName("PK__Booking___750D09A5A8EEFC40");

                entity.ToTable("Booking_BadmintonField_Schedule");

                entity.HasIndex(e => e.BadmintonField, "IX_Booking_BadmintonField_Schedule_BadmintonField");

                entity.HasIndex(e => e.BookingId, "IX_Booking_BadmintonField_Schedule_BookingId");

                entity.HasIndex(e => e.ScheduleId, "IX_Booking_BadmintonField_Schedule_ScheduleId");

                entity.Property(e => e.OrderBadmintonFieldScheduleId).HasColumnName("OrderBadmintonFieldScheduleID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.BadmintonFieldNavigation)
                    .WithMany(p => p.BookingBadmintonFieldSchedules)
                    .HasForeignKey(d => d.BadmintonField)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_B__Badmi__412EB0B6");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingBadmintonFieldSchedules)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_B__Booki__403A8C7D");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.BookingBadmintonFieldSchedules)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_B__Sched__4222D4EF");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IsStatus)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.EndTimeFrame).HasColumnType("date");

                entity.Property(e => e.ScheduleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StartTimeFrame).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
