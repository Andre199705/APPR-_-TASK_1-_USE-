using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPR___TASK_1__USE_.Models
{
    public class Disaster
    {
        //(Model In ASP.NET MVC 5, 2022)
        [Key]
        public int TDisaster { get; set; }
        public string Startdate { get; set; }

        public string Enddate { get; set; }

        public string Location { get; set; }

        public string Atype { get; set; }
    }
}
