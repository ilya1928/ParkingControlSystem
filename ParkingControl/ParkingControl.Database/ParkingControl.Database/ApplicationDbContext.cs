using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingControl.Database.Models;

namespace ParkingControl.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportVehicle> ReportVehicles { get; set; }
        public DbSet<ReportVehicleType> ReportVehicleTypes { get; set; }

        public DbSet<ReportsHandler> ReportsHandlers { get; set; }
        public DbSet<ReportsHandlerDistrict> ReportsHandlerDistricts { get; set; }

        public DbSet<EvacuationCrew> EvacuationCrews { get; set; }
        public DbSet<EvacuationCrewmate> EvacuationCrewmates { get; set; }
        public DbSet<EvacuationCrewDistrict> EvacuationCrewDistricts { get; set; }
        public DbSet<TowTruck> TowTrucks { get; set; }
        public DbSet<TowTruckReportVehicleType> TowTruckReportVehicleTypes { get; set; }

        public DbSet<District> Districts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EvacuationCrewDistrict>()
                .HasKey(ecd => new { ecd.EvacuationCrewId, ecd.DistrictId });

            modelBuilder.Entity<ReportsHandlerDistrict>()
                .HasKey(rhd => new { rhd.ReportsHandlerId, rhd.DistrictId });

            modelBuilder.Entity<TowTruckReportVehicleType>()
                .HasKey(ttrvp => new { ttrvp.TowTruckId, ttrvp.ReportVehicleTypeId });

            modelBuilder.Entity<Report>()
                .HasOne(r => r.ReportVehicle).WithOne(rv => rv.Report).HasForeignKey<ReportVehicle>(rv => rv.ReportId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.ReportsHandler).WithOne(rh => rh.ApplicationUser).HasForeignKey<ReportsHandler>(u => u.ApplicationUserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.EvacuationCrewmate).WithOne(c => c.ApplicationUser).HasForeignKey<EvacuationCrewmate>(u => u.ApplicationUserId);
        }
    }
}
