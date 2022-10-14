using System.ComponentModel.DataAnnotations;

namespace APPR___TASK_1__USE_.Models
{
    public class Categories
    {
        [Key]

        public int id { get; set; }
        public string Category { get; set; }
    }
}
