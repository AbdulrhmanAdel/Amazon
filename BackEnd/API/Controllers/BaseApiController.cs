using System.Collections.Generic;
using API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult ItemResult<T>(T data)
        {
            return Ok(new PayloadedResponse<T>(data));
        }

        protected IActionResult PagedResult<T>(T data, int totalCount)
        {
            return Ok(new PagedResponse<T>(data, totalCount));
        }
        protected IActionResult ListResult<T>(IEnumerable<T> data)
        {
            return Ok(data);
        }

        protected IActionResult InvalidRequest(IEnumerable<string> errors = null)
        {
            if (errors == null)
            {
                return BadRequest(new BaseResponse(errors));
            }

            return BadRequest();
        }

        
        protected IActionResult InvalidRequest(string error)
        {
            if (error == null)
            {
                return BadRequest(new BaseResponse(new string[] { error }));
            }

            return BadRequest();
        }
    }
}