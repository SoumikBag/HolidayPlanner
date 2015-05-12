namespace HolidayPlanner.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InfoData : DbContext
    {
        public InfoData()
            : base("name=InfoData2")
        {
        }

        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelType> HotelTypes { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Facilities)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HotelType>()
                .HasMany(e => e.Hotels)
                .WithRequired(e => e.HotelType)
                .WillCascadeOnDelete(false);
        }
    }
}
