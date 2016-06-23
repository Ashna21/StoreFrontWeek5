using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace StoreFront.Models
{
    //[Table(Name ="Users")]
    //public class CustomerBase
    //{
    //   [Column(IsPrimaryKey = true)]
    //   public int UserId { get; set;}
    //   [Column]
    //   public string FirstName { get; set; }
    //   [Column]
    //   public string LastName { get; set; }
    //   [Column]
    //   public string UserName { get; set; }
    //   [Column]
    //   public string EmailAddress { get; set; }

    //}

    public class CustomerBase
    {
        public string Name { get; set; }
    }
}