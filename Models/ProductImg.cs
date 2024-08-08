using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Unique.Models
{
    public class ProductImg
    {


        [Key]
        public int productImgId { get; set; } //상품이미지번호


        public String? productImage { get; set; } //상품이미지
        public String? productImagePath { get; set; } //상품이미지경로



        public int productId { get; set; } //상품번호






    }
}
