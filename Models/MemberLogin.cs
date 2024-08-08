using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class MemberLogin
    {



        [Required(ErrorMessage = "아이디를 입력하세요")]
        public String? userId { get; set; } //로그인 사용자 아이디

        [Required(ErrorMessage = "비밀번호를 입력하세요")]
        public String? pwd { get; set; } //로그인 사용자 비밀번호
    }
}
