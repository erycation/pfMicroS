﻿


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace tsogosun.com.MSProfileAdmin.Shared.Utils
{
    public static class HttpContextExtension
    {
        public static UserManager<TUser> GetUserManager<TUser>(this HttpContext context) where TUser : class
        {
            return context.RequestServices.GetRequiredService<UserManager<TUser>>();
        }
    }
}