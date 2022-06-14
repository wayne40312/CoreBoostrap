using CoreBoostrap.Commons;
using CoreBoostrap.Models;
using CoreBoostrap.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

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
        public IActionResult MemberList(int page = 1, int pageSize = 10) {
      
            var memberList = _context.Members;
            var paded = memberList.ToPagedList(page, pageSize);
          
            return View(paded);
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

        
        // 修改資料
        public IActionResult Edit() {
            int id = getMemId();

            var mem = _context.Members;

            var selMem = mem.FirstOrDefault(x => x.MemId == id);

                if(selMem == null) {
                    return RedirectToAction("Edit");
                }

            return View(new MemberViewModel() { MemberOb = selMem });
        }


        // 修改資料Post
        [HttpPost]
        public IActionResult Edit(MemberViewModel m) {
            getMemId();

            _context.Add(m);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // 取出使用者資訊
        private int getMemId() {
            int MemId = 1;
            if(User.Claims.Any()) {

                // 取出藏有使用者資訊的JSON字串
                Claim loginUserClaim = User.Claims.FirstOrDefault(x => x.Type.Equals("loginUser"));
                // 透過Helper.Get 取回存有使用者資訊的物件
                LoginUser loginUser = CLoginUserHelper.ToCLoginUser(loginUserClaim);

                MemId = loginUser.UserID;
                string name = loginUser.UserName;
            }
            return (MemId);
        }

    }
}
