using Microsoft.AspNetCore.Mvc;
using MrHuo.OAuth.Github;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBoostrap.Controllers
{
    public class OAuthController : Controller
    {
        #region GitHub授權+回撥
        // 發起第三方授權申請
        [HttpGet("oauth/github")]
        public IActionResult Github([FromServices] GithubOAuth githubOAuth) {
            return Redirect(githubOAuth.GetAuthorizeUrl());
        }

        // 第三方授權成功後回撥方法
        [HttpGet("oauth/githubcallback")]
        public async Task<IActionResult> GithubCallback(
            [FromServices] GithubOAuth githubOAuth,
            [FromQuery] string code)
        {
            return Json(await githubOAuth.AuthorizeCallback(code));
        }
        #endregion
    }
}
