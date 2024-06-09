using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Peiton.Api.Extensions
{
    public static class ControllerBaseExtension
    {
        public static IActionResult PaginatedResult<T>(this ControllerBase controller, IEnumerable<T> data, int total)
        {
            var result = new ObjectResult(data)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            controller.Response.Headers.Append("X-Total-Count", total.ToString());

            return result;
        }
    }
}
