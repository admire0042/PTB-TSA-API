using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;
using Shared.BaseResponse;
using Shared.Exceptions;

namespace Api.Middleware
{

    public class ErrorHandlingMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ErrorHandlingMiddleware> _logger;

            public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task Invoke(HttpContext context, IWebHostEnvironment env)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    //log the error
                    _logger.LogError($"Something went wrong." +
                    $"\n Exception: {ex}" +
                    $"\n Message: {ex.Message}" +
                    $"\n StackTrace: {ex.StackTrace}");

                    //handle the exception
                    await HandleExceptionAsync(context, ex, env, _logger);
                }
            }

            private static Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env,
            ILogger<ErrorHandlingMiddleware> logger)
            {
                //ErrorResponse errorResponse;
                var errorMessage = string.Empty;
                var response = context.Response;
                switch (exception)
                {
                    case var _ when exception is ValidationFaliedException validationException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = validationException.Message.Replace(" \r\n --", "");
                        errorMessage = errorMessage.Replace(" Severity: Error", "");
                        errorMessage = errorMessage.Split(":")[2];
                        break;
                    case var _ when exception is BadRequestException badRequestException:
                        // bad request error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = badRequestException.Message;
                        break;
                    case var _ when exception is NotFoundException notFoundException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorMessage = notFoundException.Message;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = exception.Message;
                        break;
                }

                var error = new Result
                (
                    false,
                    errorMessage,
                    errorMessage,
                    response.StatusCode.ToString()
                );
                
                var result = JsonConvert.SerializeObject(error, Formatting.Indented);
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = response.StatusCode;
                return context.Response.WriteAsync(result);

            }
    }

        public static class CustomExceptionHandlerMiddlewareExtensions
        {
            public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ErrorHandlingMiddleware>();
            }
        }
    }


