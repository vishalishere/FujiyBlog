﻿using System.Linq;
using FujiyBlog.Core.DomainObjects;
using FujiyBlog.Core.Repositories;

namespace FujiyBlog.EntityFramework
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(FujiyBlogDatabase database)
            : base(database)
        {
        }

        public bool EmailExistsWithAnotherUser(string email, int userId)
        {
            return Database.Users.Any(x => x.Email == email && x.Id != userId);
        }
    }
}