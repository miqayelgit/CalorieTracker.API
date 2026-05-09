using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.API.Controllers;

public abstract class BaseController : ControllerBase
{
    protected virtual Guid UserId => GetAuthorizedUserId();

    private Guid GetAuthorizedUserId()
    {
        var nameIdentifier = User.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        
        return nameIdentifier != null 
            ? Guid.Parse(nameIdentifier.Value)
            : Guid.Empty;
    }
}