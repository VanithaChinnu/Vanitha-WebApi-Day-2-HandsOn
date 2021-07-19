using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Vanitha_WebApi_Day_2_HandsOn.Models
{
  public interface IExceptionFilter
    {
        void OnException(HttpActionExecutedContext actionExecutedContext);

    }
}
