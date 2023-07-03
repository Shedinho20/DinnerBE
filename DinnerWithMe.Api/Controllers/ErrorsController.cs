using Microsoft.AspNetCore.Mvc;

namespace DinnerWithMe.Api.Controllers;

public class ErrorsController:ApiController
{
    [Route("/error")]
      public IActionResult Error(){

        return Problem(statusCode:500,title: "An error occurred while processing your request");
      }  
}
