using Microsoft.AspNetCore.Identity;

namespace WebToYen.Models
{
    public class AppUser : IdentityUser
    {
        public string RoleId { get; set; }
    }
}
