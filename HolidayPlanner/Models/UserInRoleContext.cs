namespace HolidayPlanner.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserInRoleContext : DbContext
    {
        public UserInRoleContext()
            : base("name=UserInRoleContext")
        {
        }

        public virtual DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
