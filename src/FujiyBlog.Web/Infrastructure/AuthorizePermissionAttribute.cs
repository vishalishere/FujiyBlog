﻿using System;
using System.Linq;
using System.Web.Mvc;
using FujiyBlog.Core.DomainObjects;

namespace FujiyBlog.Web.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizePermissionAttribute : AuthorizeAttribute
    {
        public AuthorizePermissionAttribute(params Permission[] permissions)
        {
            if (permissions == null)
            {
                throw new ArgumentNullException("permissions");
            }

            Roles = string.Join(",", permissions.Select(r => r.ToString()));
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.HttpContext.Response.StatusCode = 401;
            filterContext.HttpContext.Response.WriteFile("~/errors/401.htm"); 
            filterContext.HttpContext.Response.End();
        }
    }
}