using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.POCOs
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Extention { get; set; }
        [Required]
        public byte[] Content { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Date> Dates { get; set; }
    }
}
