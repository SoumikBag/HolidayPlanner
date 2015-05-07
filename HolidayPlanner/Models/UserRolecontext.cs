namespace HolidayPlanner.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Spatial;
    using System.Collections.Generic;


    public partial class UserRolecontext : DbContext
    {
        public UserRolecontext()
            : base("name=UserRolecontext")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInRole> UserInRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
            .HasMany(e => e.Users)
            .WithMany(e => e.Roles)
            .Map(m => m.ToTable("UserInRole").MapLeftKey("RoleId").MapRightKey("UserId"));

            //modelBuilder.Entity<User>()
            //.HasMany(g => g.UserInRoles)
            //.WithRequired(gm => gm.User);

            //modelBuilder.Entity<Role>()
            //    .HasMany(u => u.UserInRoles)
            //    .WithRequired(gm => gm.Role);

            
        }

       // public virtual ICollection<Role> Roles { get; set; }
    }
}
