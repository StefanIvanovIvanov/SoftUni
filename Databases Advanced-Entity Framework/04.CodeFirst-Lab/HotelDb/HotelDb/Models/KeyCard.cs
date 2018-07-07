using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelDb.Models
{
    public class KeyCard
    {
        [Key]
        public int Id { get; set; }

        public int CardNumber { get; set; }
        public int RoomId { get; set; }
        public virtual ICollection<RoomKeyCard> RoomKeyCards { get; set; }
    }
}
