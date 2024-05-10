using BloodDonorReceiver.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorReceiver.DataAccess.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext(DbContextOptions options) : base(options)
        {
        }

        protected MasterContext()
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<DonorModel> Donors { get; set; }
        public DbSet<ReceiverModel> Receivers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_URI"), p => p.CommandTimeout(600)).EnableSensitiveDataLogging();
            }
        }

    }
}
