using Microsoft.AspNetCore.Identity;

namespace BIThesisApi.Domain
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}