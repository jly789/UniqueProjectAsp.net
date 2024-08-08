using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace Unique.Models
{
    public class SubCategory
    {
        [Key]
        public int subCategoryId { get; set; } //하위카테고리 번호


        public String? subCategoryName { get; set; } //하위카테고리 이름


        public int categoryId { get; set; } //카테고리 번호

      
       

     
    }
}
