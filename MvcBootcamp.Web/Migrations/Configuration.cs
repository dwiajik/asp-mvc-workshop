namespace MvcBootcamp.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MvcBootcamp.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBootcamp.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            //ContextKey = "MvcBootcamp.Web.Models.ApplicationDbContext";
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcBootcamp.Web.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin1"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = "admin1" };
                userManager.Create(user, "123456");
                roleManager.Create(new IdentityRole { Name = "Administrators" });
                userManager.AddToRole(user.Id, "Administrators");
            }

            if (!context.Users.Any(u => u.UserName == "user1"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser { UserName = "user1" };
                userManager.Create(user, "123456");
                roleManager.Create(new IdentityRole { Name = "Members" });
                userManager.AddToRole(user.Id, "Members");
            }

            //var roleStore = new RoleStore<IdentityRole>(context);
            //var roleManager = new RoleManager<IdentityRole>(roleStore);

            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);

            //if (!context.Users.Any(u => u.UserName == "dwiajik"))
            //{
            //    var user = new ApplicationUser { UserName = "dwiajik" };
            //    userManager.Create(user, "asdflkjh");
            //    roleManager.Create(new IdentityRole { Name = "Super User" });
            //    userManager.AddToRole(user.Id, "Super User");
            //}

            //if (!context.Users.Any(u => u.UserName == "user"))
            //{
            //    var user = new ApplicationUser { UserName = "user" };
            //    userManager.Create(user, "asdflkjh");
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //    userManager.AddToRole(user.Id, "User");
            //}

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
