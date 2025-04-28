using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Entites
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
