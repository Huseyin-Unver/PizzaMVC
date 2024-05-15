using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PizzaMVC.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaMVC.Identity
{
    public class IdentityInitializer : DropCreateDatabaseIfModelChanges<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "admin", Description ="Yönetici"};

                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "Kullanıcı" };

                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "hsyn"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "hüseyin", SurName ="ünver", UserName="hsynunver", Email ="hsynunver@gmail.com"};

                manager.Create(user, "hsynunver");

                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }
            if (!context.Users.Any(i => i.Name == "deneme"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "deneme", SurName = "deneme", UserName = "deneme", Email = "deneme@gmail.com" };

                manager.Create(user, "deneme");
                manager.AddToRole(user.Id, "user");

            }



            base.Seed(context);
        }
    }
}