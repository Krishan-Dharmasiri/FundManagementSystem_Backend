
using FundManagementSystem.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace FundManagementSystem.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch(exception)
            {
                case FundManagementSystem.Application.Exceptions.ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    //result = JsonSerializer.Serialize(validationException.ValidationErrors);
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            if(result == string.Empty)
            {
                //result = JsonSerializer.Serialize(new { Error = exception.Message });
                result = "Source : Custom Middleware, Internal Server Error. Please contact the admin";
            }

            return context.Response.WriteAsync(result);
        }
    }
}
