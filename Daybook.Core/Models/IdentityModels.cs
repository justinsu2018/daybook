using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Daybook.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string NickName { get; set; }

        public MemberType MemberType { get; set; }

        public SubscriptedType SubscriptedType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public ICollection<USRBookCategory> USRBookCategories { get; set; }
        public ICollection<USRBookCategoryItem> USRBookCategoryItems { get; set; }
        public ICollection<Payee> Payees { get; set; }
        public ICollection<USRCurrency> USRCurrencies { get; set; }
        public ICollection<WorkingGroup> WorkingGroups { get; set; }
        public ICollection<Planning> Plannings { get; set; }

        [StringLength(3)]
        public string CurrencyID { get; set; }
        //public USRCurrency USRCurrency { get; set; }

        public ApplicationUser()
        {
            USRBookCategories = new Collection<USRBookCategory>();
            USRBookCategoryItems = new Collection<USRBookCategoryItem>();
            Payees = new Collection<Payee>();
            USRCurrencies = new Collection<USRCurrency>();
            WorkingGroups = new Collection<WorkingGroup>();
            Plannings = new Collection<Planning>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}