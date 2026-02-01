using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendInfoApp.Middleware {
    public class GlobalExceptionMiddleware {
        private readonly ILogger<GlobalExceptionMiddleware> oLogger;
        private readonly RequestDelegate oRequests;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger) {
            this.oLogger = logger;
            this.oRequests = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                oLogger.LogInformation("A request came in");
                await oRequests(context);
                oLogger.LogInformation("Request has been handled");
            } catch (Exception e) {
                oLogger.LogError(e, e.Message);

                ProblemDetails oDetails = new ProblemDetails() {
                    Detail = "Internal Server Error",
                    Instance = "Error",
                    Status = 500,
                    Title = "Server Error",
                    Type = "Error",
                };

                string sResponse = JsonConvert.SerializeObject(oDetails);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(sResponse);
            }
        }
    }
}
