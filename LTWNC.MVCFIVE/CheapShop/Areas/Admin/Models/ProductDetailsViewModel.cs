using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheapShop.Models;

namespace CheapShop.Areas.Admin.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Picture> Picture { get; set; }
        public List<ProductHistory> ProductHistory { get; set; }
        public ProductProfile ProductProfile { get; set; }
    }
}