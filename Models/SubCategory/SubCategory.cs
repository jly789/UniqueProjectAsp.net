using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace Unique.Models
{
    public class SubCategory
    {
        [Key]
        public int subCategoryId { get; set; }


        public String? subCategoryName { get; set; }

  
        public int categoryId { get; set; }

        [ForeignKey("categoryId")]
        public virtual Category? Category { get; set; }
       

     
    }
}
