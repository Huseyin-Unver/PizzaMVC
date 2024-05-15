using Microsoft.AspNet.Identity.EntityFramework;
using PizzaMVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaMVC.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>

    {
        public IdentityDataContext() : base("dataConnection")
        {
                
        }


    }
}