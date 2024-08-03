using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Unique.Models.Member

{
    public class Cart
    {

        [Key]
        public int cartId { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public int memberId { get; set; }


        [ForeignKey("memberId")]
        public virtual Member? Member { get; set; }


        public int productId { get; set; }


        [ForeignKey("productId")]
        public virtual Product? Product { get; set; }
    }
}
