using CoreBoostrap.Commons;
using CoreBoostrap.Models;
using CoreBoostrap.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreBoostrap.Controllers
{
    public class ProductController : Controller
    {
        ILogger<ProductController> _logger;

        private readonly SunflowerDBContext _context;

        IWebHostEnvironment _enviroment;

        public ProductController(ILogger<MemberController> logger, SunflowerDBContext context, IWebHostEnvironment e) {
            //_logger = logger;
            _context = context;
            _enviroment = e;
        }
        public IActionResult Index() {
            return View();
        }

        // 新增產品
        public IActionResult CreateProduct() {
            return View();
        }

        // 新增產品HttpPost
        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel p) {
            string photoName = Guid.NewGuid().ToString() + ".jpg";
            p.ImagePath = photoName;
            p.Photo.CopyTo(new FileStream(_enviroment.WebRootPath + @"\img\shopping-img\prod-img\" + photoName, FileMode.Create));

            Product pudd = new Product() {
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
           

            List<ProductViewModel> lpn = new List<ProductViewModel>();
            foreach (var item in productlist) {
                lpn.Add(item);
            }
            var aa = lpn.ToPagedList(page, pageSize);
            
            return View(aa);
        }

        // 產品修改
        public IActionResult ProductEdit(int id)
        {
            var product = _context.Products;

            var selProduct = product.FirstOrDefault(c => c.ProductId == id);
            if (selProduct == null)

                return RedirectToAction("ProductList");

            var newProduct = from p in _context.Products
                          where p.ProductId == id
                          select new ProductViewModel {
                              ProductId = id,
                              ProductName = p.ProductName,
                              ProductBrandId = p.ProductBrandId,
                              ProductBrandName = p.ProductBrand.ProductBrandName,
                              ProductCatId = p.ProductCatId,
                              ProductCatName = p.ProductCat.ProductCatName,
                              ImagePath = p.ImagePath,
                              InStock = p.InStock,
                              UnitPrice = p.UnitPrice,
                              ShelfDate = p.ShelfDate,
                              ProductDescription = p.ProductDescription
                          };

            ProductViewModel pvm = newProduct.FirstOrDefault();
            return View(pvm);
        }

        // 產品修改HttpPsot
        [HttpPost]
        public IActionResult ProductEdit(ProductViewModel pvm) {
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
            return View(LPV);
        }

        // 取使用者的ID
        [Authorize]
        private int getMemId() {
            int MemId = 1;
            if (User.Claims.Any()) {
                // 取出藏有使用者資訊的Json字串
                Claim loginUserClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("loginUser"));
                // 透過Helper.Get取回存有使用者資訊的物件
                LoginUser loginUser = CLoginUserHelper.ToCLoginUser(loginUserClaim);
                // LoginUserType type = loginUser.Role;
                MemId = loginUser.UserID;
                string name = loginUser.UserName;
            }
            return (MemId);
        }
    }
}
