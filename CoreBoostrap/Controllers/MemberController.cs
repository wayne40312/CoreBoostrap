using CoreBoostrap.Models;
using CoreBoostrap.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace CoreBoostrap.Controllers
{
    public class MemberController : Controller
    {
        ILogger<MemberController> _logger;

        private readonly SunflowerDBContext _context;
    
       
        public MemberController(ILogger<MemberController> logger, SunflowerDBContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }


        // 會員列表
        public IActionResult MemberList(int? page) {
            var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)
            int pageSize = 10; // Get 25 students for each requested page.
            var onePageOfStudents = _context.Members.ToPagedList(pageNumber, pageSize);
            return View(onePageOfStudents); // Send 25 students to the page.
            //var memberList = _context.Members;
            //return View(memberList);
        }

        
        // 註冊帳號
        public IActionResult Register() {
            //ViewBag.CityId = _context.Cities;

            return View();
        }


        // 註冊帳號Post
        [HttpPost]
        public IActionResult Register(Member m) {
            _context.Add(m);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
