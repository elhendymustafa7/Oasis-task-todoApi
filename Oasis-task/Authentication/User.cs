using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Oasis_task.Authentication
{
    public class User : IdentityUser<int>
    {
        //[Required, MaxLength(50)]
        //public string FirstName { get; set; }

        //[Required, MaxLength(50)]
        //public string LastName { get; set; }
    }
}
