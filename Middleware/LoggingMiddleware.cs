namespace UserManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 逻辑：记录请求信息
            Console.WriteLine($"[Request] {context.Request.Method} {context.Request.Path}");

            await _next(context); // 传递给下一个中间件
        }
    }
}