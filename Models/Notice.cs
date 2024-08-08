using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class Notice
    {


        [Key]
        public int noticeId { get; set; } //공지번호


        [Required(ErrorMessage = "제목을 입력하세요")]
        public String? noticeTitle { get; set; } //공지제목

        [Required(ErrorMessage = "내용을 입력하세요")]
        public String? noticeContent { get; set; } //공지내용

        public DateTime? noticeDate { get; set; } //공지등록일

        public int? memberId { get; set; } //회원번호
    }
}
