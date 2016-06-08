using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace StoreFront.Models
{
    public class blog
    {
        public int BlogID { get; set; }
        public int Name { get; set; }

    }

    public class TestingBlogContext: DbContext
    {
        public TestingBlogContext(): base("StoreFrontConnectionString1")
            {
            }

        public DbSet<blog> blogs { get; set; }
    }
}