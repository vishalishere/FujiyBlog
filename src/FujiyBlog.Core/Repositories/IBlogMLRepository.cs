﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FujiyBlog.Core.DomainObjects;

namespace FujiyBlog.Core.Repositories
{
    public interface IBlogMLRepository
    {
        void AddPost(Post blogMLPost);
    }
}
