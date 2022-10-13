using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPR___TASK_1__USE_.Models
{
    public class Donations
    {
        //(Model In ASP.NET MVC 5, 2022)
        [Key]

        public int user {get;set;}

        public string Date { get; set; }

        public string Time { get; set; }

        public int NewItem { get; set; }

        public string Catagory { get; set; }

        public string Description { get; set; }
         
        public bool Annonymys { get; set; }
    }
}
