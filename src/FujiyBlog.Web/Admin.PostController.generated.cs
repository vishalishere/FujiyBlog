// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace FujiyBlog.Web.Areas.Admin.Controllers {
    public partial class PostController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected PostController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ViewResult Index() {
            return new T4MVC_ViewResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Edit() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult EditPost() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.EditPost);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Delete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult DeleteConfirmed() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult AddCategory() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.AddCategory);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public PostController Actions { get { return MVC.Admin.Post; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "Admin";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Post";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string Edit = "Edit";
            public readonly string EditPost = "Edit";
            public readonly string Delete = "Delete";
            public readonly string DeleteConfirmed = "Delete";
            public readonly string AddCategory = "AddCategory";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Create = "~/Areas/Admin/Views/Post/Create.cshtml";
            public readonly string Delete = "~/Areas/Admin/Views/Post/Delete.cshtml";
            public readonly string Edit = "~/Areas/Admin/Views/Post/Edit.cshtml";
            public readonly string Index = "~/Areas/Admin/Views/Post/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_PostController: FujiyBlog.Web.Areas.Admin.Controllers.PostController {
        public T4MVC_PostController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ViewResult Index(int? page) {
            var callInfo = new T4MVC_ViewResult(Area, Name, ActionNames.Index);
            callInfo.RouteValueDictionary.Add("page", page);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(int? id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult EditPost(int? id, string tags, System.Collections.Generic.IEnumerable<int> selectedCategories) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.EditPost);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("tags", tags);
            callInfo.RouteValueDictionary.Add("selectedCategories", selectedCategories);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(int id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult DeleteConfirmed(int id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult AddCategory(string name) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.AddCategory);
            callInfo.RouteValueDictionary.Add("name", name);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
