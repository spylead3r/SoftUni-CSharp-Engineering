using Footballers.Common;
using Footballers.Data.Models.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
            TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.FootballerNameLengthMax)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime ContractStartDate  { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }
        public PositionType PositionType { get; set; }

        public BestSkillType BestSkillType { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }

        public Coach Coach { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers { get; set; } = null!;
    }
}
