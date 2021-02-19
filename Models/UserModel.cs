using System.ComponentModel.DataAnnotations;

namespace IntershipProject.Models
{
    public class UserModel // То что видит пользователь
    {
        [Required]
        [Display(Name = "Your user name:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Your password:")]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("password")]
        public string Password { get; set; }

        [Display(Name = "Your full name:")]
        public string FullName { get; set; }
        
        [Required]
        [Display(Name = "Your EMail:")]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        
        [Display(Name = "Your photo:")]
        public string PictureUri { get; set; }
    }
}
