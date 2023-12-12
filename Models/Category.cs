using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using EStore.Data.Base;
using EStore.Data.Enums;

namespace EStore.Models
{
    public class Category:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Category Name")]
        public String CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }


       
    }
}
