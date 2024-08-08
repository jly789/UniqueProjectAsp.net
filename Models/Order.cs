using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class Order
    {
        [Key]
        public int? orderId { get; set; }  //주문번호
        public int? memberId { get; set; } //회원번호
        public int? cartId { get; set; } //장바구니번호
        public int? productId { get; set; }  //상품번호
        public int? price { get; set; } //상품가격
        public int? totalPrice { get; set; } //상품총가격
        public string? impUid { get; set; } //결제번호
        public string? orderNum { get; set; } //주문번호
        public int? orderPrice { get; set; } //총결제금액
        public int? orderQuantity { get; set; } //주문수량
        public string? orderStatus { get; set; } //주문상태
    }
}
