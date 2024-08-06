using System.ComponentModel.DataAnnotations;

namespace Unique.Models
{
    public class Notice
    {


        [Key]
        public int noticeId { get; set; }


        [Required(ErrorMessage = "제목을 입력하세요")]
        public String? noticeTitle { get; set; }

        [Required(ErrorMessage = "내용을 입력하세요")]
        public String? noticeContent { get; set; }

        public DateTime? noticeDate { get; set; }

        public int? memberId { get; set; }
    }
}
