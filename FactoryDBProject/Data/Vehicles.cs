using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FactoryDBProject.Data
{
    public partial class Vehicles : DbContext
    {
        public Vehicles()
            : base("name=Vehicles")
        {
        }

        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<VHT001_VEHICLE> VHT001_VEHICLE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleType>()
                .Property(e => e.VehicleTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<VehicleType>()
                .HasMany(e => e.VHT001_VEHICLE)
                .WithOptional(e => e.VehicleType)
                .HasForeignKey(e => e.VehicleTypeCode);

            modelBuilder.Entity<VHT001_VEHICLE>()
                .Property(e => e.VehicleId)
                .IsUnicode(false);

            modelBuilder.Entity<VHT001_VEHICLE>()
                .Property(e => e.VehicleColor)
                .IsUnicode(false);
        }
    }
}
