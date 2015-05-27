namespace HolidayPlanner.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MapLocation : DbContext
    {
        public MapLocation()
            : base("name=MapLocation")
        {
        }

        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(e => e.LocationName)
                .IsUnicode(false);
        }
    }
}
