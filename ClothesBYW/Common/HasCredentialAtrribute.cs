using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Web.Routing;

namespace ClothesBYW.Common
{
    public class HasCredentialAtrribute: AuthorizeAttribute
    {
        public string RoleID { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (EmployeeLogin)HttpContext.Current.Session[CC.USER_SESSION];
            if (session == null)
            {
                return false;
            }

            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.Username); // Call another method to get rights of the user from DB

            if (privilegeLevels.Contains(this.RoleID) || session.UserGroupID == CommonConstant.ADMIN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Administrator/Views/Shared/_401.cshtml"
            };
        }
        private List<string> GetCredentialByLoggedInUser(string userName)
        {
            var credentials = (List<string>)HttpContext.Current.Session[CC.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}