using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using deneme.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace deneme.Identity
{
    public class IdentityVeriBaglam:IdentityDbContext<ApplicationUser>
    {
        public IdentityVeriBaglam() : base("dataConnection")
        {

        }
    }
}