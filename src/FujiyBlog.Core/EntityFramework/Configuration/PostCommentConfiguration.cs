﻿using System.Data.Entity.ModelConfiguration;
using FujiyBlog.Core.DomainObjects;

namespace FujiyBlog.Core.EntityFramework.Configuration
{
    public class PostCommentConfiguration : EntityTypeConfiguration<PostComment>
    {
        public PostCommentConfiguration()
        {
            Property(b => b.AuthorName).IsUnicode(false);
            Property(b => b.AuthorEmail).IsUnicode(false);
            Property(b => b.AuthorWebsite).IsUnicode(false);
            Property(b => b.Comment).IsUnicode(false).IsMaxLength();
            Property(b => b.IpAddress).IsUnicode(false);
            Property(b => b.Avatar).IsUnicode(false);

            HasOptional(t => t.ParentComment).WithMany(t => t.NestedComments);
        }
    }
}
