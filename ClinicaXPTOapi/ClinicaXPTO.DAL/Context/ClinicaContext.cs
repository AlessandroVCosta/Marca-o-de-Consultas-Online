using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicaXPTO.MODEL.Entities;

namespace ClinicaXPTO.DAL.Context
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<AnonymousRequest> AnonymousRequests { get; set; } = null!;
        public DbSet<AppointmentRequest> AppointmentRequests { get; set; } = null!;
        public DbSet<AppointmentRequestItem> AppointmentRequestItems { get; set; } = null!;
        public DbSet<ActType> ActTypes { get; set; } = null!;
        public DbSet<Professional> Professionals { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Índice único em User.Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Configurações de relacionamento (são inferidos por convenção, mas deixamos explícito)

            // 1:N: AppointmentRequest → AppointmentRequestItem
            modelBuilder.Entity<AppointmentRequest>()
                .HasMany(ar => ar.Items)
                .WithOne(i => i.AppointmentRequest)
                .HasForeignKey(i => i.AppointmentRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:N: ActType → AppointmentRequestItem
            modelBuilder.Entity<ActType>()
                .HasMany(a => a.RequestItems)
                .WithOne(i => i.ActType)
                .HasForeignKey(i => i.ActTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1:N: Professional (solicitado) → AppointmentRequestItem
            modelBuilder.Entity<Professional>()
                .HasMany(p => p.RequestItemsSolicitados)
                .WithOne(i => i.Professional)
                .HasForeignKey(i => i.ProfessionalId)
                .OnDelete(DeleteBehavior.SetNull);

           

            // 1:N: User → AppointmentRequest
            modelBuilder.Entity<User>()
                .HasMany(u => u.Requests)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // 1:N: AnonymousRequest → AppointmentRequest
            modelBuilder.Entity<AnonymousRequest>()
                .HasMany(a => a.Requests)
                .WithOne(r => r.AnonymousRequest)
                .HasForeignKey(r => r.AnonymousRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
     }
}
