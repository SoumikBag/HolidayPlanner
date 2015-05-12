namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelType")]
    public partial class HotelType
    {
        public HotelType()
        {
            Hotels = new HashSet<Hotel>();
        }

        [Key]
        [StringLength(10)]
        public string HTypeId { get; set; }

        [Column("HotelType")]
        [StringLength(50)]
        public string HotelType1 { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
