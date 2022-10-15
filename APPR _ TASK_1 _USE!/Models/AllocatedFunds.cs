using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APPR___TASK_1__USE_.Models
{
    public class AllocatedFunds
    {
        [Key]
        public int id { get; set; }

        public string Date { get; set; }


        [Required]
        [ForeignKey("Disaster")]
        public int TDisaster { get; set; }

        public virtual Disaster Disaster { get; set; }

        [Required]
        [ForeignKey("CashDonations")]
        public int user { get; set; }

        public virtual CashDonations CashDonations { get; set; }
    }
}
