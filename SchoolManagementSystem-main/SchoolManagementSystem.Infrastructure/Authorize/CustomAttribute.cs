using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolManagementSystem.Infrastructure.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["JwtUser"];
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            //else
            //{
            //    //int roleId = Convert.ToInt32(user[1].Value);
            //    //List<Permission> permissions = new UnitOfWork.UnitOfWork()
            //    //    .PerList(3);
            //    //List<Permission> permissions = new UnitOfWork.UnitOfWork()
            //    //    .GenericRepository<Permission>()
            //    //    .Where(per => per.RoleID == roleId)
            //    //    .ToList();
            //    ////List<Permission> permissions = JsonConvert.DeserializeObject<List<Permission>>(user[1].Value);
            //    //var controllerName = context.ActionDescriptor.RouteValues["controller"];
            //    //var actionName = context.ActionDescriptor.RouteValues["action"];
            //    //bool controllerAllow = permissions.Any(perm => perm.Page.Route == controllerName);

            //    //if (!controllerAllow)
            //    //{
            //    //    context.Result = new JsonResult(new { message = "Unauthorized" })
            //    //    {
            //    //        StatusCode = StatusCodes.Status401Unauthorized
            //    //    };
            //    //    return;
            //    //}

            //    //foreach (var item in permissions.Where(x => x.Page.Route == controllerName))
            //    //{
            //    //    bool isUnauthorized = (actionName.Equals("Post", StringComparison.OrdinalIgnoreCase) && !item.Create) ||
            //    //  (actionName.Equals("Get", StringComparison.OrdinalIgnoreCase) && !item.View) ||
            //    //  (actionName.Equals("Delete", StringComparison.OrdinalIgnoreCase) && !item.Delete) ||
            //    //  (actionName.Equals("Put", StringComparison.OrdinalIgnoreCase) && !item.Update);

            //    //    if (isUnauthorized)
            //    //    {
            //    //        context.Result = new JsonResult(new { message = "Unauthorized" })
            //    //        {
            //    //            StatusCode = StatusCodes.Status401Unauthorized
            //    //        };
            //    //        return;
            //    //    }
            //    //}
            //}
        }
    }
}