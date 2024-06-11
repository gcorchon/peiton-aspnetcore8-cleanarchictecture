using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Peiton.Api.Extensions
{
    public static class ControllerBaseExtension
    {
        public static IActionResult PaginatedResult<T>(this ControllerBase controller, IEnumerable<T> data, int total)
        {
            return PaginatedResult(controller, data, new Dictionary<string, string> { { "X-Total-Count", total.ToString() } });
        }

        public static IActionResult PaginatedResult<T>(this ControllerBase controller, IEnumerable<T> data, Dictionary<string, string> headers)
        {
            var result = new ObjectResult(data)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            foreach (var header in headers)
            {
                controller.Response.Headers.Append(header.Key, header.Value);
            }

            return result;
        }
    }
}
