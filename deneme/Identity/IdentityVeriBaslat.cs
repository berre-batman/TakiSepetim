using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using deneme.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace deneme.Identity
{
    public class IdentityVeriBaslat : CreateDatabaseIfNotExists<IdentityVeriBaglam>
    {
        protected override void Seed(IdentityVeriBaglam context)
        {
            //Rolleri
            if(!context.Roles.Any(i=> i.Name=="admin")) 
            {
                var store=new RoleStore<ApplicationRole>(context);
                var manager =new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() {Name="admin",Description="admin rolü"};
                manager.Create(role);

            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() {Name="user",Description="user rolü" };
                manager.Create(role);

            }

            //userlar

            if (!context.Users.Any(i => i.Name == "berrebatman"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name="Berre",Surname="Batman",UserName="berrebtmn",Email="berrebatman@gmail.com"};

                
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "aycabatman"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "Ayça", Surname = "Batman", UserName = "aycabtmn", Email = "aycabatman@gmail.com" };


                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }


            base.Seed(context);
        }
    }
}