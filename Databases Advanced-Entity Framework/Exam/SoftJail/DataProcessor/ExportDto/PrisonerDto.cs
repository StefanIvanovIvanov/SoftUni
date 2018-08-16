using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor.ExportDto
{
    public class PrisonerDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        public string CellNumber { get; set; }

        [JsonProperty("Officers")]
        public List<OfficerDto> Officers { get; set; }=new List<OfficerDto>();

      //  public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}
