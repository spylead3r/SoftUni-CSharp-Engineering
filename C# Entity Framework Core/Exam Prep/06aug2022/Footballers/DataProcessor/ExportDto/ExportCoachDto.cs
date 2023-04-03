﻿using Footballers.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachDto
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        [Required]
        [MaxLength(ValidationConstants.CoachNameLengthMax)]
        [MinLength(ValidationConstants.CoachNameLengthMin)]
        public string CoachName { get; set; }

        [XmlArray("Footballers")]
        public ExportFootballerDto[] Footballers { get; set; }
    }
}
