using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

using System.Security.Claims;
using System.Threading.Tasks;

namespace Entities.Models
{
   
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
    }

}