using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie
{
  public class LoggerMiddleware
  {
    //через данный объект сможем обращаться к следующему компоненту в конвейере и передавать ему управление обработкой запросов
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    //конструктор 
    public LoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
      _next = next;
      _logger = loggerFactory.CreateLogger<LoggerMiddleware>();
    }

    //когда компонент получет запрос на обработку, этот метод обрабатывает запрос
    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      finally
      {
        _logger.LogInformation(
            "Request {method} {url} => {statusCode}",
            context.Request?.Method,
            context.Request?.Path.Value,
            context.Response?.StatusCode);
        _logger.LogInformation(new EventId(1), $"Request URL [{UriHelper.GetDisplayUrl(context.Request)}]");
      }
    }
  }
  //Позволяет подключать этот мидлваре в startup.cs
  public static class ValueExtensions
  {
    public static IApplicationBuilder UseLogger(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<LoggerMiddleware>();
    }
  }
}
