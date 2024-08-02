using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Unique.Models.Member
{
    public class Product
    {


        [Key]
        public int productId { get; set; }
        public int productPrice { get; set; }
        public int productView { get; set; }

        public String? productName { get; set; }
        public String? productContent { get; set; }
        public String? productImage { get; set; }
        public String? productImagePath { get; set; }
        public String? productCategoryName { get; set; }
      

        public int memberId { get; set; }

        [ForeignKey("memberId")]
        public virtual Member? Member { get; set; }


        public int categoryId { get; set; }

        [ForeignKey("categoryId")]
        public virtual Category? Category { get; set; }




        







    }
}
