using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Unique.Models

{
    public class Cart
    {

        [Key]
        public int cartId { get; set; } //장바구니번호
        public int quantity { get; set; } // 상품 수량
        public int price { get; set; } //상품가격

        public int totalPrice { get; set; } //상품총가격

        public int memberId { get; set; } //회원번호


        public int productId { get; set; } //상품번호


 
    }
}
