namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReviewId { get; set; }

        [StringLength(2000)]
        public string ReviewDetails { get; set; }

        public double? Rating { get; set; }

        public int UserId { get; set; }

        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
