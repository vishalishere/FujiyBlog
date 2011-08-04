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
namespace T4MVC {
    public class ThemesController {

        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            static readonly _Default s_Default = new _Default();
            public _Default Default { get { return s_Default; } }
            public partial class _Default{
                static readonly _Account s_Account = new _Account();
                public _Account Account { get { return s_Account; } }
                public partial class _Account{
                    public readonly string ChangePassword = "~/Views/Themes/Default/Account/ChangePassword.cshtml";
                    public readonly string ChangePasswordSuccess = "~/Views/Themes/Default/Account/ChangePasswordSuccess.cshtml";
                    public readonly string ForgotPassword = "~/Views/Themes/Default/Account/ForgotPassword.cshtml";
                    public readonly string ForgotPasswordSuccess = "~/Views/Themes/Default/Account/ForgotPasswordSuccess.cshtml";
                    public readonly string LogOn = "~/Views/Themes/Default/Account/LogOn.cshtml";
                }
                static readonly _Comment s_Comment = new _Comment();
                public _Comment Comment { get { return s_Comment; } }
                public partial class _Comment{
                    public readonly string Comments = "~/Views/Themes/Default/Comment/Comments.cshtml";
                    public readonly string DoComment = "~/Views/Themes/Default/Comment/DoComment.cshtml";
                }
                static readonly _Contact s_Contact = new _Contact();
                public _Contact Contact { get { return s_Contact; } }
                public partial class _Contact{
                    public readonly string Index = "~/Views/Themes/Default/Contact/Index.cshtml";
                }
                static readonly _Page s_Page = new _Page();
                public _Page Page { get { return s_Page; } }
                public partial class _Page{
                    public readonly string Details = "~/Views/Themes/Default/Page/Details.cshtml";
                }
                static readonly _Post s_Post = new _Post();
                public _Post Post { get { return s_Post; } }
                public partial class _Post{
                    public readonly string Archive = "~/Views/Themes/Default/Post/Archive.cshtml";
                    public readonly string Details = "~/Views/Themes/Default/Post/Details.cshtml";
                    public readonly string Index = "~/Views/Themes/Default/Post/Index.cshtml";
                    public readonly string Post = "~/Views/Themes/Default/Post/Post.cshtml";
                }
                static readonly _Shared s_Shared = new _Shared();
                public _Shared Shared { get { return s_Shared; } }
                public partial class _Shared{
                    public readonly string _Layout = "~/Views/Themes/Default/Shared/_Layout.cshtml";
                    public readonly string Error = "~/Views/Themes/Default/Shared/Error.cshtml";
                }
            }
        }
    }

}

#endregion T4MVC
#pragma warning restore 1591
