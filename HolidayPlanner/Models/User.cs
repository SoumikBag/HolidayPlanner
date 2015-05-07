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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }


        [Required]
        [StringLength(50)]
        public string UserName { get; set; }


        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        public string EmailId { get; set; }


        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[0-9]{8,11}$", ErrorMessage = "Please enter a valid Contact number ")] 
        public string ContactNo { get; set; }


        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public virtual ICollection<Role> Roles { get; set; }


        public Role Role { get; set; }
    }
}