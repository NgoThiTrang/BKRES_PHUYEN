using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DoAn.Data.Model
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FullName { get; set; }

        public string Avatar { get; set; } // avatar profile

        public string Address { get; set; } // Address of user

        public string LoginEndIP { get; set; }

        public int? LoginCount { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool? Gender { get; set; }
        
        public int? ProvinceId { get; set; }

        public int? DisctrictId { get; set; }

        public IEnumerable<ActivityLog> ActivityLogs { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        [ForeignKey("DisctrictId")]
        public virtual District District { get; set; }
    }
}