using System.ComponentModel.DataAnnotations;
using UniProject.Models.BaseDto;

namespace UniProject.Models.Entity.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        [Display(Name ="نام و نام خانوادگی")]
        public string FullName { get; set; }


        [Required(ErrorMessage ="کدملی را وارد کنید")]
        [Display(Name ="کدملی")]
        public string NationalCode { get; set; }


        [Required(ErrorMessage ="ایمیل اجباری است")]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage ="رمز عبور اجباری است")]
        [Display(Name ="رمزعبور")]
        public string Password { get; set; }


        [Display(Name ="تاریخ ثبت نام")]
        public DateTime CreateDate { get; set; }


        [Display(Name ="تاریخ آخرین بروزرسانی")]
        public DateTime UpdateTime { get; set; }
    }
}
