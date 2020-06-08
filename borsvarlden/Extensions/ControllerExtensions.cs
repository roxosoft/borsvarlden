using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace borsvarlden.Extensions
{
    public static class ControllerExtensions
    {
        public static string GetCookie(this Controller contoller,  string cookieName)
             => contoller.HttpContext.Request.Cookies[cookieName];

        public static void SetCookie(this Controller controller,string cookieName)
        {
            controller.HttpContext.Response.Cookies.Append(cookieName, DateTime.Now.ToString(), new CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                Secure = false,
                IsEssential = true,
                Expires = DateTime.Now.AddMonths(1)
            });
        }
    }
}
