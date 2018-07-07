using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Cache;
using System.Text;

namespace HotelDb.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BedCount { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [DefaultValue(true)]//available by default
        public bool IsAvailable { get; set; }
        [Required]
        public decimal? Cost { get; set; }

        [NotMapped]
        public RoomType RoomTypeEnum => (RoomType)Enum.Parse(typeof(RoomType), this.RoomType.ToString());


        public string RoomNickname { get; set; }

        [Required]
        public string RoomType { get; set; }

        public virtual ICollection<RoomKeyCard> RoomKeyCards { get; set; }
    }
}
