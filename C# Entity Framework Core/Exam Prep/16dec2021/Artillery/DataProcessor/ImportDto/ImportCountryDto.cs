using Artillery.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportCountryDto
    {
        
        [MinLength(GlobalConstants.CountryNameMinLength)]
        [MaxLength(GlobalConstants.CountryNameMaxLength)]
        [XmlElement("CountryName")]
        [Required]
        public string? CountryName { get; set; }

        [Required]
        [Range(GlobalConstants.CountryArmySizeMin, GlobalConstants.CountryArmySizeMax)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}
