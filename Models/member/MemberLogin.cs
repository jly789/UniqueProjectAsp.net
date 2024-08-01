using System.ComponentModel.DataAnnotations;

namespace Unique.Models.Member
{
    public class MemberLogin
    {



        [Required(ErrorMessage = "아이디를 입력하세요")]
        public String? userId { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력하세요")]
        public String? pwd { get; set; }
    }
}
