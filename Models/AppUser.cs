using Microsoft.AspNetCore.Identity;

namespace IntershipProject.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public string PictureUri { get; set; }
    }
}
