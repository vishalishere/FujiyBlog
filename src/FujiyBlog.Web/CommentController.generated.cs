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
namespace FujiyBlog.Web.Controllers {
    public partial class CommentController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CommentController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult DoComment() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.DoComment);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Approve() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Approve);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Disapprove() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Disapprove);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Delete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CommentController Actions { get { return MVC.Comment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Comment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Comment";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string DoComment = "DoComment";
            public readonly string Approve = "Approve";
            public readonly string Disapprove = "Disapprove";
            public readonly string Delete = "Delete";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants {
            public const string DoComment = "DoComment";
            public const string Approve = "Approve";
            public const string Disapprove = "Disapprove";
            public const string Delete = "Delete";
        }


        static readonly ActionParamsClass_DoComment s_params_DoComment = new ActionParamsClass_DoComment();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DoComment DoCommentParams { get { return s_params_DoComment; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DoComment {
            public readonly string id = "id";
            public readonly string parentCommentId = "parentCommentId";
        }
        static readonly ActionParamsClass_Approve s_params_Approve = new ActionParamsClass_Approve();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Approve ApproveParams { get { return s_params_Approve; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Approve {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Disapprove s_params_Disapprove = new ActionParamsClass_Disapprove();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Disapprove DisapproveParams { get { return s_params_Disapprove; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Disapprove {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete {
            public readonly string id = "id";
            public readonly string deleteReplies = "deleteReplies";
        }
        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Comments = "~/Views/Comment/Comments.cshtml";
            public readonly string DoComment = "~/Views/Comment/DoComment.cshtml";
            public readonly string NewComment = "~/Views/Comment/NewComment.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_CommentController: FujiyBlog.Web.Controllers.CommentController {
        public T4MVC_CommentController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult DoComment(int id, int? parentCommentId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.DoComment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "parentCommentId", parentCommentId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Approve(int id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Approve);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Disapprove(int id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Disapprove);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Delete(int id, bool deleteReplies) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "deleteReplies", deleteReplies);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
