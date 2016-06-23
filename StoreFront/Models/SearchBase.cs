using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.Models
{
    //[Table(Name = "Products")]
    //public class SearchBase : CustomerBase
    //{
       
    //    [Column(IsPrimaryKey = true)]
    //    public int ProductID { get; set; }
    //    [Column]
    //    public string ProductName { get; set; }
    //    [Column]
    //    public string ProductDesription { get; set; }
    //    [Column]
    //    public string Price { get; set; }

    //}

    public class SearchBase : CustomerBase
    {
        [Display(Description = "Type your search request here: ")]
        public string SearchText { get; set; }

        public List<SearchResult> Results { get; set; }

        public SearchBase()
        {
            Results = new List<SearchResult>();
        }
    }

    public class SearchResult
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageFile { get; set; }
    }
}