using System.ComponentModel.DataAnnotations;

namespace IntershipProject.Models
{
    public class BiometricLoginView
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Uri")]
        public string PictureUri { get; set; }
    }
}
