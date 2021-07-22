using FileProcessor.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace FileProcessor.API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected ObjectResult BadRequest(string field)
        {
            throw new BadRequestException($"{field} value has to be provided");
        }
    }
}
