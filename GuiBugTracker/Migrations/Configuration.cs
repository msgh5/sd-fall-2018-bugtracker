namespace GuiBugTracker.Migrations
{
    using GuiBugTracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuiBugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GuiBugTracker.Models.ApplicationDbContext context)
        {
            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            var userManager =
                new UserManager<ApplicationUser>(
                        new UserStore<ApplicationUser>(context));

            if (!context.Roles.Any(p => p.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!context.Roles.Any(p => p.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole("Project Manager"));
            }

            if (!context.Roles.Any(p => p.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole("Developer"));
            }

            if (!context.Roles.Any(p => p.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole("Submitter"));
            }

            ApplicationUser adminUser;

            if (!context
                .Users
                .Any(p => p.UserName == "admin@mybugtracker.com"))
            {
                adminUser = new ApplicationUser();
                adminUser.Email = "admin@mybugtracker.com";
                adminUser.UserName = "admin@mybugtracker.com";

                userManager.Create(adminUser, "Password-1");
            }
            else
            {
                adminUser = context
                    .Users
                    .First(p => p.UserName == "admin@mybugtracker.com");
            }

            if (!userManager.IsInRole(adminUser.Id, "Admin"))
            {
                userManager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}
