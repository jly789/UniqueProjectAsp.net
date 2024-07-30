using System.ComponentModel.DataAnnotations;

namespace Unique.Models.member
{
    public class Member
    {

        [Key]
        public int memberId { get; set; }


      

        [Required(ErrorMessage ="아이디를 입력하세요")]
        public String? userId { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력하세요")]
        public String? pwd { get; set; }

        [Required(ErrorMessage = "이름을 입력하세요")]
        public String? userName { get; set; }

        [Required(ErrorMessage = "닉네임을 입력하세요")]
        public String? nickName { get; set; }

        [Required(ErrorMessage = "전화번호를 입력하세요")]
        public String? tel { get; set; }

        [Required(ErrorMessage = "우편번호를 입력하세요")]
        public String? postcode { get; set; }

        [Required(ErrorMessage = "주소를 입력하세요")]
        public String? address { get; set; }
        public String? detailAddress { get; set; }
        public String? extraAddress { get; set; }

        [Required(ErrorMessage = "이메일을 입력하세요")]
        public String? email { get; set; }

        [Required(ErrorMessage = "생일을 입력하세요")]
        public DateTime? birth { get; set; }


    }
}
