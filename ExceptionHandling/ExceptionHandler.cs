using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorObject = new ErrorStructure()
            {
                Status = context.Response.StatusCode,
                Message = "Internal server error.",
            };

            if(exception is GenericException)
            {
                errorObject.Exception = exception.Message;
            } else
            {
                errorObject.Exception = "Encontramos um problema durante o processamento. Entre em contato com o TI!";
            }

            return context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(errorObject));
        }
    }
}
