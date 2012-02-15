﻿using System;
using System.Linq;
using System.Web.Mvc;
using FujiyBlog.Core.DomainObjects;
using FujiyBlog.Core.EntityFramework;
using FujiyBlog.Core.Extensions;
using FujiyBlog.Web.Infrastructure;
using FujiyBlog.Web.Models;
using System.Data.Entity;
using Microsoft.Web.Helpers;

namespace FujiyBlog.Web.Controllers
{
    public partial class CommentController : Controller
    {
        private readonly FujiyBlogDatabase db;

        public CommentController(FujiyBlogDatabase db)
        {
            this.db = db;
        }

        [AuthorizeRole(Role.CreateComments)]
        public virtual ActionResult DoComment(int id, int? parentCommentId)
        {
            if (Settings.SettingRepository.ReCaptchaEnabled && !ReCaptcha.Validate(Settings.SettingRepository.ReCaptchaPrivateKey))
            {
                return JavaScript("alert('Invalid captcha!');Recaptcha.reload();");
            }

            bool isLogged = Request.IsAuthenticated;
            Post post = db.Posts.Include(x => x.Author).WhereHaveRoles().SingleOrDefault(x => x.Id == id);

            if (post == null || !post.IsCommentEnabled || !Settings.SettingRepository.EnableComments)
            {
                throw new InvalidOperationException();
            }

            if (Settings.SettingRepository.CloseCommentsAfterDays.HasValue && post.PublicationDate.AddDays(Settings.SettingRepository.CloseCommentsAfterDays.Value) < DateTime.UtcNow)
            {
                throw new InvalidOperationException();
            }

            PostComment postComment = new PostComment
            {
                CreationDate = DateTime.UtcNow,
                IpAddress = Request.UserHostAddress,
                Post = post,
                IsApproved = isLogged || !Settings.SettingRepository.ModerateComments,
            };

            if (isLogged)
            {
                postComment.Author = db.Users.SingleOrDefault(x => x.Username == User.Identity.Name);
                postComment.IsApproved = true;
                UpdateModel(postComment, new[] { "Comment" });
            }
            else
            {
                UpdateModel(postComment, new[] { "AuthorName", "AuthorEmail", "AuthorWebsite", "Comment" });
            }

            if (parentCommentId.HasValue)
            {
                postComment.ParentComment = db.PostComments.Single(x => x.Id == parentCommentId.Value);
            }

            db.PostComments.Add(postComment);
            db.SaveChanges();

            return View("Comments", new[] { postComment });
        }

        [AuthorizeRole(Role.CreateComments)]
        public virtual ActionResult ReplyComment(int id)
        {
            PostComment comment = db.PostComments.Include(x => x.Post).Single(x => x.Id == id);

            PostComment newComment = new PostComment {Post = comment.Post, ParentComment = comment};

            return View(MVC.Themes.Views.Default.Comment.DoComment, newComment);
        }

        [AuthorizeRole(Role.ModerateComments), HttpPost]
        public virtual ActionResult Approve(int id)
        {
            return ChangeCommentStatus(id, true);
        }

        [AuthorizeRole(Role.ModerateComments), HttpPost]
        public virtual ActionResult Disapprove(int id)
        {
            return ChangeCommentStatus(id, false);
        }

        [AuthorizeRole(Role.ModerateComments), HttpPost]
        public virtual ActionResult Delete(int id)
        {
            PostComment comment = db.PostComments.Single(x => x.Id == id);
            comment.IsDeleted = true;
            comment.ModeratedBy = db.Users.Single(x => x.Username == User.Identity.Name);
            db.SaveChangesBypassingValidation();

            return Json(true);
        }

        private ActionResult ChangeCommentStatus(int id, bool approved)
        {
            PostComment comment = db.PostComments.Single(x => x.Id == id);
            comment.IsApproved = approved;
            comment.ModeratedBy = db.Users.Single(x => x.Username == User.Identity.Name);
            db.SaveChangesBypassingValidation();

            return Json(true);
        }
    }
}
