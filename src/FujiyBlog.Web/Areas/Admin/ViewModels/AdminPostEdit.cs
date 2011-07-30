﻿using System.Collections.Generic;
using System.Web.Mvc;
using FujiyBlog.Core.DomainObjects;

namespace FujiyBlog.Web.Areas.Admin.ViewModels
{
    public class AdminPostEdit
    {
        public AdminPostSave Post { get; set; }
        public IEnumerable<Tag> AllTags { get; set; }
        public IEnumerable<Category> AllCategories { get; set; }
        public IEnumerable<SelectListItem> AllUsers { get; set; }
    }
}