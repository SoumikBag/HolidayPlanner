namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInRole")]
    public partial class UserInRole
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }


        //[ForeignKey("RoleId")]
        //[Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int MyProperty { get; set; }
        //public int RoleId { get; set; }


        //Foreign key for Standard
        public int RoleId { get; set; }

        //[ForeignKey("RoleId")]
        //public Role Role { get; set; }

    }
}
