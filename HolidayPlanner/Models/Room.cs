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
        public Room()
        {
            Hotels = new HashSet<Hotel>();
        }

        public int RoomId { get; set; }

        [StringLength(50)]
        public string RoomType { get; set; }

        public int? RoomCapacity { get; set; }

        [StringLength(50)]
        public string RoomDetails { get; set; }

        public int? Rate { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
