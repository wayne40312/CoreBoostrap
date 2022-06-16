using CoreBoostrap.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBoostrap.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel() {
            this.ProductOb = new Product();
        }
        public Product ProductOb { get; set; }

        [Key]
        public int ProductId {
            get { return this.ProductOb.ProductId; }
            set { this.ProductOb.ProductId = value; }
        }
        [DisplayName("總類")]
        public int ProductCatId {
            get { return this.ProductOb.ProductCatId; }
            set { this.ProductOb.ProductCatId = value; }
        }
        [DisplayName("品牌")]
        public int ProductBrandId {
            get { return this.ProductOb.ProductBrandId; }
            set { this.ProductOb.ProductBrandId = value; }
        }
        [DisplayName("名稱")]
        public string ProductName {
            get { return this.ProductOb.ProductName; }
            set { this.ProductOb.ProductName = value; }
        }
        [DisplayName("價格")]
        public int UnitPrice {
            get { return this.ProductOb.UnitPrice; }
            set { this.ProductOb.UnitPrice = value; }
        }
        [DisplayName("庫存")]
        public int InStock {
            get { return this.ProductOb.InStock; }
            set { this.ProductOb.InStock = value; }
        }
        [DisplayName("有效日期")]
        public DateTime? ShelfDate {
            get { return this.ProductOb.ShelfDate; }
            set { this.ProductOb.ShelfDate = value; }
        }

        [DisplayName("商品圖")]
        public string ImagePath {
            get { return this.ProductOb.ImagePath; }
            set { this.ProductOb.ImagePath = value; }
        }
        public IFormFile Photo { get; set; }

        [DisplayName("產品名")]
        public string ProductCatName { get; set; }

        [DisplayName("品牌")]
        public string ProductBrandName { get; set; }

        [DisplayName("產品描述")]
        public string ProductDescription {
            get { return this.ProductOb.ProductDescription; }
            set { this.ProductOb.ProductDescription = value; }
        }
    }
}
