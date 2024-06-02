namespace SchoolManagementSystem.StartUp.Middlewares
{
    public abstract class BaseMiddleware
    {
        protected bool IsApiEndpoint(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/api");
        }
    }
}