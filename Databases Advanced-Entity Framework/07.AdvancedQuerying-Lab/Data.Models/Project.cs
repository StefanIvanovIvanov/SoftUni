using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
