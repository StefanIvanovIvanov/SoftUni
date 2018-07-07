using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDb.Models
{
   public class RoomKeyCard
    {
        public int RoomId { get; set; }
        public int KeyCardId { get; set; }

        public virtual Room Room{get; set; }
        public virtual KeyCard KeyCard { get; set; }
    }
}
