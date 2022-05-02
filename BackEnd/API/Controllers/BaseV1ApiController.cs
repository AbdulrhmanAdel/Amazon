using api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/v1/[controller]")]
public abstract class BaseV1ApiController : BaseApiController
{
}