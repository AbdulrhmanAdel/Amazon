using DefaultNamespace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Identity;

public class TestController : BaseV1ApiController
{
    private readonly ICurrentUserContext _currentUserContext;

    public TestController(ICurrentUserContext currentUserContext)
    {
        _currentUserContext = currentUserContext;
    }

    [HttpGet("TestAuth")]
    [Authorize]
    public IActionResult TestAuth()
    {
        throw new NotImplementedException();
        return Ok(_currentUserContext);
    }
}