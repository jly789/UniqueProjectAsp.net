using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class Category
    {

        [Key]
        public int categoryId { get; set; } //카테고리 번호


        public String? categoryName { get; set; } //카테고리 이름 

    }
}
