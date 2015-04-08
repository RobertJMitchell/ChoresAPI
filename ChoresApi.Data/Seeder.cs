using ChoresApi.Data.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoresApi.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            // generic Identity - Store the users
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            // generic Identity - roles
            RoleStore<Role> roleStore = new RoleStore<Role>(db);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);

            // seed data users...
            ApplicationUser userOne = null;
            userOne = userManager.FindByName("julio@codercamps.com");

            // if USER_ONE does not exist, do create them
            if (userOne == null)
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "julio@codercamps.com",
                    FirstName = "julio",
                    LastName = "r",
                    UserName = "julio@codercamps.com"
                }, "123456");
                userOne = userManager.FindByName("julio@codercamps.com");
            }

            ApplicationUser userTwo = null;
            userTwo = userManager.FindByName("rickjames@codercamps.com");
            // if USER_TWO does not exist, do create them
            if (userTwo == null)
            {
                userManager.Create(new ApplicationUser
                {
                    Email = "rickjames@codercamps.com",
                    FirstName = "Rick",
                    LastName = "J",
                    UserName = "rickjames@codercamps.com"
                }, "123456");
                userTwo = userManager.FindByName("rickjames@codercamps.com");
            }



            // if ROLES does not exist, do create them
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new Role { Name = "Admin" });
                roleManager.Create(new Role { Name = "General" });
            }

            // assign the userOne into a role
            if (!userManager.IsInRole(userOne.Id, "Admin"))
            {
                userManager.AddToRole(userOne.Id, "Admin");
            }
            // assign the userOne into a role
            if (!userManager.IsInRole(userTwo.Id, "General"))
            {
                userManager.AddToRole(userTwo.Id, "General");
            }
        }
    }
}
