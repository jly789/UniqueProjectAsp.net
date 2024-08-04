using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Unique.Models

{
    public class Cart
    {

        [Key]
        public int cartId { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public int totalPrice { get; set; }

        public int memberId { get; set; }


        [ForeignKey("memberId")]
        public virtual Member? Member { get; set; }


        public int productId { get; set; }


        [ForeignKey("productId")]
        public  Product? Product { get; set; }
    }
}
