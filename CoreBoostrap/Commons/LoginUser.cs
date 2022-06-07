using CoreBoostrap.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreBoostrap.Commons
{
    public class LoginUser
    {
        public LoginUserType Role { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public string UserPhotoPath { get; set; }
    }

    public static class CLoginUserHelper
    {
        /// <summary>
        /// 取回 CLoginUser物件
        /// </summary>
        /// <param name="claim">傳入的Claim物件 ClaimTypes="loginUser"</param>
        /// <returns></returns>
        public static LoginUser ToCLoginUser(Claim claim)
        {
            LoginUser loginUser = JsonConvert.DeserializeObject<LoginUser>(claim.Value);
            return loginUser;
        }
        /// <summary>
        /// 將CLoginUser 轉成JSON字串
        /// </summary>
        /// <param name="loginUser">Authorized物件</param>
        /// <returns></returns>
        public static string ToString(LoginUser loginUser)
        {
            string loginUserString = JsonConvert.SerializeObject(loginUser);
            return loginUserString;
        }
    }
}
