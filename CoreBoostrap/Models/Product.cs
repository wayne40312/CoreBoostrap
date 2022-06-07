using System;
using System.Collections.Generic;

#nullable disable

namespace CoreBoostrap.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderdetails = new HashSet<Orderdetail>();
            Reviews = new HashSet<Review>();
            Wishlists = new HashSet<Wishlist>();
        }

        public int ProductId { get; set; }
        public int ProductCatId { get; set; }
        public int ProductBrandId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int UnitPrice { get; set; }
        public int InStock { get; set; }
        public DateTime? ShelfDate { get; set; }
        public string ImagePath { get; set; }

        public virtual Productbrand ProductBrand { get; set; }
        public virtual Productcategory ProductCat { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}
