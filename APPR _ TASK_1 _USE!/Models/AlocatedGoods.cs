using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APPR___TASK_1__USE_.Models
{
    public class AlocatedGoods
    {
        [Key]
        public int id { get; set; }


        [Required]
        [ForeignKey("Disaster")]
        public int DisasterId { get; set; }
        public virtual Disaster Disaster { get; set; }


        [Required]
        [ForeignKey("Donations")]
        public int user { get; set; }
        public virtual Donations Donations { get; set; }
    }
}
