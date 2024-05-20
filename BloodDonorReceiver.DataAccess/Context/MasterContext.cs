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
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<StateModel> States { get; set; }
        public DbSet<BloodCenterModel> BloodCenters { get; set; }
        public DbSet<DonorsCitiesModel> DonorsCities { get; set; }
        public DbSet<ReceiversCitiesModel> ReceiversCities { get; set; }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasKey(x => x.Guid);
            modelBuilder.Entity<DonorModel>().HasKey(x => x.Guid);
            modelBuilder.Entity<ReceiverModel>().HasKey(x => x.Guid);
            modelBuilder.Entity<CityModel>().HasKey(x => x.ID);
            modelBuilder.Entity<StateModel>().HasKey(x => x.ID);
            modelBuilder.Entity<BloodCenterModel>().HasKey(x => x.TeamId);
            modelBuilder.Entity<DonorsCitiesModel>().HasKey(x => x.Guid);
            modelBuilder.Entity<ReceiversCitiesModel>().HasKey(x => x.Guid);

            modelBuilder.Entity<DonorModel>().Property(x => x.BloodType).HasConversion<short>();
            modelBuilder.Entity<ReceiverModel>().Property(x => x.BloodType).HasConversion<short>();

            modelBuilder.Entity<DonorModel>().Property(x => x.Gender).HasConversion<short>();
            modelBuilder.Entity<ReceiverModel>().Property(x => x.Gender).HasConversion<short>();

            modelBuilder.Entity<UserModel>().HasMany(a => a.Donors).WithOne(x => x.Users).HasForeignKey(a => a.UserGuid);
            modelBuilder.Entity<UserModel>().HasMany(a => a.Receivers).WithOne(x => x.Users).HasForeignKey(a => a.UserGuid);

            modelBuilder.Entity<BloodCenterModel>().HasOne(a => a.City).WithMany(x => x.BloodCenters).HasForeignKey(a => a.CityId);
            modelBuilder.Entity<BloodCenterModel>().HasOne(a => a.State).WithMany(x => x.BloodCenters).HasForeignKey(a => a.StateId);

            modelBuilder.Entity<DonorsCitiesModel>().HasOne(x => x.Donor).WithMany(x => x.DonorsCities).HasForeignKey(x => x.DonorsGuid).HasConstraintName("DonorsGuid");
            modelBuilder.Entity<DonorsCitiesModel>().HasOne(x => x.City).WithMany(x => x.DonorsCities).HasForeignKey(x => x.CitysId).HasConstraintName("CitysId");

            modelBuilder.Entity<ReceiversCitiesModel>().HasOne(x => x.Receiver).WithMany(x => x.ReceiversCities).HasForeignKey(x => x.ReceiversGuid).HasConstraintName("ReceiversGuid");
            modelBuilder.Entity<ReceiversCitiesModel>().HasOne(x => x.City).WithMany(x => x.ReceiversCities).HasForeignKey(x => x.CitysId).HasConstraintName("CitysId");



            modelBuilder.Entity<CityModel>().HasMany(a => a.States).WithOne(x => x.City).HasForeignKey(a => a.CityId).HasConstraintName("CityId");
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
