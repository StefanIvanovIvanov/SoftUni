using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor.ImportDto
{
   public class OfficerPrisonerDto
    {
        public int PrisonerId { get; set; }

        public int OfficerId { get; set; }
    }
}
