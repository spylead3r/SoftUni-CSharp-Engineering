using Footballers.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [JsonProperty("Name")]
        [MinLength(ValidationConstants.TeamNameLengthMin)]
        [MaxLength(ValidationConstants.TeamNameLengthMax)]
        [RegularExpression("^[a-zA-Z0-9 .-]+$")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("Nationality")]
        [MinLength(ValidationConstants.TeamNationalityLengthMin)]
        [MaxLength(ValidationConstants.TeamNationalityLengthMax)]
        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] Footballers { get; set; }

    }
}
