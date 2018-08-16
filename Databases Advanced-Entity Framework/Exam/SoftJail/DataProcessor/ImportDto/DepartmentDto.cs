using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
    class DepartmentDto
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

        public Cell[] Cells { get; set; }
    }
}
