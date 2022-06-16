using CoreBoostrap.Models;
using CoreBoostrap.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreBoostrap.Controllers
{
    public class ProductController : Controller
    {
        ILogger<ProductController> _logger;

        private readonly SunflowerDBContext _context;

        IWebHostEnvironment _enviroment;

        public ProductController(ILogger<MemberController> logger, SunflowerDBContext context, IWebHostEnvironment e)
        {
            //_logger = logger;
            _context = context;
            _enviroment = e;
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel p) {
            string photoName = Guid.NewGuid().ToString() + ".jpg";
            p.ImagePath = photoName;
            p.Photo.CopyTo(new FileStream(_enviroment.WebRootPath + @"\img\shopping-img\prod-img\" + photoName, FileMode.Create));



            Product pudd = new Product()
            {
                ProductCatId = p.ProductCatId,
                ProductBrandId = p.ProductBrandId,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                InStock = p.InStock,
                ShelfDate = p.ShelfDate,
                ImagePath = p.ImagePath,
                ProductDescription = p.ProductDescription
            };


            _context.Add(pudd);
            _context.SaveChanges();

            return RedirectToAction("ProductList");
        }

        // 產品列表
        public IActionResult ProductList(int page = 1, int pageSize = 10) {
            var productlist = from o in _context.Products
                              orderby o.ProductBrand
                              select new ProductViewModel {
                                  ProductCatName = o.ProductCat.ProductCatName,
                                  ProductBrandName = o.ProductBrand.ProductBrandName,
                                  ProductId = o.ProductId,
                                  ProductCatId = o.ProductCatId,
                                  ProductBrandId = o.ProductBrandId,
                                  ProductName = o.ProductName,
                                  UnitPrice = o.UnitPrice,
                                  InStock = o.InStock,
                                  ShelfDate = o.ShelfDate,
                                  ProductDescription = o.ProductDescription,
                                  ImagePath = o.ImagePath
                              };
           

            List<ProductViewModel> LPV = new List<ProductViewModel>();
            foreach (var item in productlist) {
                LPV.Add(item);
            }
            var aa = LPV.ToPagedList(page, pageSize);

            
            return View(aa);
        }

        public IActionResult ProductEdit()
        {
            var productlist = from o in _context.Products
                              orderby o.ProductBrand
                              select new ProductViewModel
                              {
                                  ProductCatName = o.ProductCat.ProductCatName,
                                  ProductBrandName = o.ProductBrand.ProductBrandName,
                                  ProductId = o.ProductId,
                                  ProductCatId = o.ProductCatId,
                                  ProductBrandId = o.ProductBrandId,
                                  ProductName = o.ProductName,
                                  UnitPrice = o.UnitPrice,
                                  InStock = o.InStock,
                                  ShelfDate = o.ShelfDate,
                                  ProductDescription = o.ProductDescription,
                                  ImagePath = o.ImagePath

                              };
            List<ProductViewModel> LPV = new List<ProductViewModel>();
            foreach (var item in productlist)
            {
                LPV.Add(item);
            }
            return View(LPV);
        }

        [HttpPost]
        public IActionResult ProductEdit(ProductViewModel pvm)
        {
            var productlist = from o in _context.Products
                              orderby o.ProductBrand
                              select new ProductViewModel
                              {
                                  ProductCatName = o.ProductCat.ProductCatName,
                                  ProductBrandName = o.ProductBrand.ProductBrandName,
                                  ProductId = o.ProductId,
                                  ProductCatId = o.ProductCatId,
                                  ProductBrandId = o.ProductBrandId,
                                  ProductName = o.ProductName,
                                  UnitPrice = o.UnitPrice,
                                  InStock = o.InStock,
                                  ShelfDate = o.ShelfDate,
                                  ProductDescription = o.ProductDescription,
                                  ImagePath = o.ImagePath

                              };
            List<ProductViewModel> LPV = new List<ProductViewModel>();
            foreach (var item in productlist)
            {
                LPV.Add(item);
            }
            return View(LPV);
        }
    }
}
