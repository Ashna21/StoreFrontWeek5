using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StoreFront.Models
{
    public class CustomerBaseViewModel
    {
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

    
    }
    public class CustomerBaseViewModelContext : DbContext
    {
        public CustomerBaseViewModelContext() : base("StoreFrontConnectionString1")
        {
        }

        public System.Data.Entity.DbSet<StoreFront.Models.CustomerBaseViewModel> CustomerBaseViewModels { get; set; }
    }


}