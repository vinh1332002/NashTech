using assignment1.Middlewares;

namespace assignment1.Extensions
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoginMiddlewares>();
        }
    }
}