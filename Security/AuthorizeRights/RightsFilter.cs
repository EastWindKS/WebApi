using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Context;

namespace WebAPI.Security.AuthorizeRights;

[AttributeUsage(AttributeTargets.Method)]
public class RightsFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor is not ControllerActionDescriptor descriptor) return;
        var actionName = descriptor.ActionName;
        var controllerName = descriptor.ControllerName;
        var applicationUserId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var officeId = int.Parse(context.HttpContext.User.FindFirst("Office")?.Value!);

        try
        {
            var secureEmployeeDbContext = new AuthenticateDbContext(new DbContextOptions<AuthenticateDbContext>());
            var rights = secureEmployeeDbContext.AspNetUserRights
                .Where(a => a.AspNetUserId == applicationUserId
                            && a.OfficeId == officeId
                            && a.RightControllerAction.Name == actionName && a.RightControllerAction.RightController.Name == controllerName)
                .ToList();

            if (rights.Any())
            {
                return;
            }

            throw new UnauthorizedAccessException();
        }
        catch (UnauthorizedAccessException)
        {
            throw new UnauthorizedAccessException("has no permission");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}