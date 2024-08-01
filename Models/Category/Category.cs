using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class Category
    {

        [Key]
        public int categoryId { get; set; }


        public String? categoryName { get; set; }

    }
}
