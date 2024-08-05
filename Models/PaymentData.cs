using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class PaymentData
    {
      
            public int? memberId { get; set; }
            public int[]? cartId { get; set; }
            public int[]? productId { get; set; }
            public int[]? price { get; set; }
            public int[]? totalPrice { get; set; }
            public string? impUid { get; set; }
            public string? orderNum { get; set; }
            public int? orderPrice { get; set; }
            public int[]? orderQuantity { get; set; }
            public string? orderStatus { get; set; }
        }









    
}
