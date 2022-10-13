using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPR___TASK_1__USE_.Models
{
    public class CashDonations
    {
        //(Model In ASP.NET MVC 5, 2022)
        [Key]

        public int user { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Amount { get; set; }

        public bool Annonymys { get; set; }

    }
}
