namespace HolidayPlanner.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string RoomId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }

        [StringLength(50)]
        public string RoomType { get; set; }

        [StringLength(50)]
        public string RoomCapacity { get; set; }

        [StringLength(200)]
        public string RoomDetails { get; set; }

        [StringLength(50)]
        public string Rate { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
