using CoreBoostrap.Commons;
using CoreBoostrap.Models;
using CoreBoostrap.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CoreBoostrap.Controllers
{
    public class LoginController : Controller
    {
        private readonly SunflowerDBContext _context;

        public LoginController(SunflowerDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // 登入畫面
        public IActionResult Login() {
            if (User.Claims.Any()) {
                return RedirectToAction("MemberList", "Member");
            }
            return View();
        }
               
        [HttpPost]
        public IActionResult Login(LoginViewModel login) {
            Member memUser = _context.Members.FirstOrDefault(e => e.MemEmail.Equals(login.Account) && e.MemPassword.Equals(login.Password));
            if (memUser != null) {
                if (memUser.MemEmail == login.Account && memUser.MemPassword == login.Password) {
                    SetCookieAuthentication(memUser);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        // 把會員物件做成一個身分識別物件，並將資訊藏在Claim(Cookie)
        private void SetCookieAuthentication(Member mem) {
           
            IList<Claim> claims = new List<Claim>() {
            new Claim(ClaimTypes.Role,Convert.ToString(LoginUserType.Member))
            };

            LoginUser loginUser = new LoginUser {
                Role = LoginUserType.Member,
                UserID = mem.MemId,
                UserName = mem.MemName
            };

            string loginUserString = CLoginUserHelper.ToString(loginUser);
            claims.Add(new Claim("loginUser", loginUserString));

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity
                (claims, CookieAuthenticationDefaults.AuthenticationScheme));

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                });
        }

    }
}
