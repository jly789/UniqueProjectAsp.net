using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class Product
    {


        [Key]
        public int productId { get; set; } //상품번호
        public int productPrice { get; set; } //상품가격
        public int productView { get; set; } //상품조회수

        public String? productName { get; set; } //상품이름
        public String? productContent { get; set; } //상품내용
        public String? productBrand { get; set; } //상품 브랜드

        public String? productImage { get; set; } //상품이미지
        public String? productImagePath { get; set; } //상품이미지 경로
        public String? productCategoryName { get; set; } //상품카테고리 이름

        public int memberId { get; set; } //회원번호
      
        public int categoryId { get; set; }//카테고리번호














    }
}
