using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Vanitha_WebApi_Day_2_HandsOn.Models
{
    public class CustomExceptionFilter : Exception
    {
        public void OnException(HttpActionExecutedContext context)
           {
               if (context.Exception is BadRequestException)
               {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
               }
           } 
    }
}
