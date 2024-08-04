using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Unique.Models
{
    public class ProductImg
    {


        [Key]
        public int productImgId { get; set; }
      

        public String? productImage { get; set; }
        public String? productImagePath { get; set; }
      


        public int productId { get; set; }

    

        [ForeignKey("productId")]
        public virtual Product? Product { get; set; }





    }
}
