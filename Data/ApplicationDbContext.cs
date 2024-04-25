using Microsoft.EntityFrameworkCore;
using TicketOrdering.Models;

namespace TicketOrdering.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyEntityTypeConfigurations(modelBuilder);
        }

        private void ApplyEntityTypeConfigurations(ModelBuilder modelBuilder)
        {
            UserEntityConfiguration(modelBuilder);
            ClientEntityConfiguration(modelBuilder);
            TicketEntityConfiguration(modelBuilder);
        }

        private void UserEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Username)
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired(false);

                entity.Property(e => e.LastName)
                    .IsRequired(false);
            });
        }

        private void ClientEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Address)
                    .IsRequired(false);
            });
        }

        private void TicketEntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity => 
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(tc => tc.Owner)
                    .WithMany(own => own.Tickets)
                    .HasForeignKey(tc => tc.OwnerId);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sqlite.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}