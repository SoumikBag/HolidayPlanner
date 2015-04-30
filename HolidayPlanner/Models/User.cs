namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string EmailId { get; set; }

        [StringLength(50)]
        public string ContactNo { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

    }
}
