﻿using System.Collections.Generic;
using FujiyBlog.Core.DomainObjects;

namespace FujiyBlog.Web.Areas.Admin.ViewModels
{
    public class AdminPageIndex
    {
        public IEnumerable<Page> Pages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool? Published { get; internal set; }
    }
}