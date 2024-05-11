using BloodDonorReceiver.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorReceiver.DataAccess.Context
{
    public class MasterContext : DbContext
    {
        #region Constructors
        public MasterContext(DbContextOptions options) : base(options)
        {
        }

        public MasterContext()
        {
        }

        #endregion

        #region DbSets
        public DbSet<UserModel> Users { get; set; }
        public DbSet<DonorModel> Donors { get; set; }
        public DbSet<ReceiverModel> Receivers { get; set; }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(x => x.Guid);
            modelBuilder.Entity<DonorModel>().HasKey(x => x.Guid);
            modelBuilder.Entity<ReceiverModel>().HasKey(x => x.Guid);

            modelBuilder.Entity<DonorModel>().Property(x => x.BloodType).HasConversion<short>();
            modelBuilder.Entity<ReceiverModel>().Property(x => x.BloodType).HasConversion<short>();

            modelBuilder.Entity<DonorModel>().HasOne(a => a.Users).WithMany(x => x.Donors).HasForeignKey(a => a.Guid).HasConstraintName("UserGuid");
            modelBuilder.Entity<ReceiverModel>().HasOne(a => a.Users).WithMany(x => x.Receivers).HasForeignKey(a => a.Guid).HasConstraintName("UserGuid");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRESQL_URI"), p => p.CommandTimeout(600)).EnableSensitiveDataLogging();
            }
        }

        #endregion
    }
}
