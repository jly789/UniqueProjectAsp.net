using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{

    public class Member
    {

        [Key]
        public int memberId { get; set; } //회원번호




        [Required(ErrorMessage = "아이디를 입력하세요")] 
        public String? userId { get; set; } //사용자 아이디

        [Required(ErrorMessage = "비밀번호를 입력하세요")]
        public String? pwd { get; set; } //사용자 비밀번호

        [Required(ErrorMessage = "이름을 입력하세요")]
        public String? userName { get; set; } //사용자 이름

        [Required(ErrorMessage = "닉네임을 입력하세요")]
        public String? nickName { get; set; } //사용자 닉네임

        [Required(ErrorMessage = "전화번호를 입력하세요")]
        public String? tel { get; set; } //전화번호

        [Required(ErrorMessage = "우편번호를 입력하세요")]
        public String? postcode { get; set; } //우편번호

        [Required(ErrorMessage = "주소를 입력하세요")]
        public String? address { get; set; } //주소
        public String? detailAddress { get; set; } //상세주소
        public String? extraAddress { get; set; } //참고주소

        [Required(ErrorMessage = "이메일을 입력하세요")]

        public String? email { get; set; } //이메일

        [Required(ErrorMessage = "생일을 입력하세요")]
        public DateTime? birth { get; set; } //생일

    }
}
