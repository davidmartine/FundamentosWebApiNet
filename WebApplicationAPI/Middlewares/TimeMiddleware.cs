namespace WebApplicationAPI.Middlewares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;

        public TimeMiddleware(RequestDelegate nextrequest)
        {
            next= nextrequest;
        }

        public async Task invoke(HttpContext context)
        {
            await next(context);

            if (context.Request.Query.Any(x => x.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
            
        }

        
    }

    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
