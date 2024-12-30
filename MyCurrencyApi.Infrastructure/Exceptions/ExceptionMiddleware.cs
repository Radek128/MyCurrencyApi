using Microsoft.AspNetCore.Http;
using MyCurrencyApi.Domain.Exceptions;
using System.Text.Json;

namespace MyCurrencyApi.Infrastructure.Exceptions
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception, context);
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var (statusCode, error) = exception switch
            {
                EntityNotFoundException => (StatusCodes.Status404NotFound,
                    new Error(StatusCodes.Status404NotFound.ToString(), exception.Message)),
                BusinessException => (StatusCodes.Status400BadRequest,
                    new Error(StatusCodes.Status400BadRequest.ToString(), exception.Message)),
                _ => (StatusCodes.Status500InternalServerError, new Error("error", "There was an error."))
            };

            context.Response.StatusCode = statusCode;
            var message = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(message);
        }

        private record Error(string Code, string Reason);
    }
    }
