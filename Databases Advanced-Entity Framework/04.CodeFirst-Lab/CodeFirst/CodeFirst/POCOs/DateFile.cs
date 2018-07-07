using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CodeFirst.POCOs
{
   public class DateFile
    {
        public int DateId { get; set; }
        public int FileId { get; set; }

        public virtual Date Date { get; set; }
        public virtual File File { get; set; }
    }
}
