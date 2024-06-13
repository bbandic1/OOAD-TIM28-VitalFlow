using System.Text;

namespace VitalFlow
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Logiranje informacija o dolaznom zahtjevu
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            // Logiranje informacija o tijelu zahtjeva (ako je potrebno)
            if (context.Request.Method == "POST")
            {
                string body = await GetRequestBody(context.Request);
                _logger.LogInformation($"Request Body: {body}");
            }

            await _next(context);
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                string body = await reader.ReadToEndAsync();
                request.Body.Position = 0;
                return body;
            }
        }
    }

}
