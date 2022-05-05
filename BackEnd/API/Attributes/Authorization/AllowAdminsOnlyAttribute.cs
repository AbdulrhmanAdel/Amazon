using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Attributes.Authorization;

public class AllowAdminsOnlyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var isAdminClaim = context.HttpContext.User.FindFirst(claim => claim.Type == "IsAdmin")?.Value.ToString();
        if (isAdminClaim == null || !bool.Parse(isAdminClaim))
        {
            context.Result = new ForbidResult();
            return;
        }
        
        base.OnActionExecuting(context); 
    }
}