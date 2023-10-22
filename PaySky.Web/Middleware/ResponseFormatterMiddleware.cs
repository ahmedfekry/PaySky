using Newtonsoft.Json;

namespace PaySky.Web.Middleware
{
    public class ResponseFormatterMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseFormatterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized || context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                await context.Response.WriteAsync(
                    JsonConvert.SerializeObject(new ResponseModel("Unauthorize access")));
            }
        }
    }

    public class ResponseModel
    {
        public ResponseModel(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
