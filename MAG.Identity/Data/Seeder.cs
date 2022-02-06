using MAG.AppCommons;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAG.Identity
{
    public class Seeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<long>> roleManager;
        private readonly IdentityContext identityContext;

        public Seeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<long>> roleManager, IdentityContext identityContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.identityContext = identityContext;
        }

        public async Task Seed()
        {
            identityContext.Database.Migrate();

            using(var transaction = await identityContext.Database.BeginTransactionAsync())
            {
                if(!identityContext.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole<long>(UserRole.Admin.ToString()));
                    await roleManager.CreateAsync(new IdentityRole<long>(UserRole.User.ToString()));
                }

                if(!identityContext.Users.Any())
                {
                    var admin = new ApplicationUser()
                    {
                        UserName = "Admin",
                        Name = "Administrator",
                        Surname = "Administrator",
                        Email = "nie@tup.ru",
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var user = new ApplicationUser()
                    {
                        UserName = "Mefju",
                        Name = "Dżerard",
                        Surname = "z Rivii",
                        Email = "fejkowy@email.ru",
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    await userManager.CreateAsync(admin, "gowno123");
                    await userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());

                    await userManager.CreateAsync(user, "gowno123");
                    await userManager.AddToRoleAsync(user, UserRole.User.ToString());
                }

                transaction.Commit();
            }
        }
    }
}
