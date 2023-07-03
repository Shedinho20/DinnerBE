using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DinnerWithMe.Api.Controllers;

[ApiController]
public class ApiController:ControllerBase
{
     protected IActionResult Problem(List<Error> errors)
     {
        //set error here to display code error in Problem factory
        HttpContext.Items["errors"] = errors;

        var firstError = errors[0];

        var statusCode = firstError.Type switch{
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode:statusCode,title:firstError.Description);
     }
    
}