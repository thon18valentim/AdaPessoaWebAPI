namespace AdaPessoaWebApplication.Middlewares
{
  public class AccountAuthorization
  {
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public AccountAuthorization(RequestDelegate next, ILoggerFactory logFactory)
    {
      _next = next;
      _logger = logFactory.CreateLogger("AccountAuthorization");
    }

    public async Task Invoke(HttpContext httpContext)
    {
      _logger.LogInformation("AccountAuthorization executing...");

      var profile = httpContext.Request.Headers["Profile"];

      //if (profile == "admin")
      //{
      //  await _next(httpContext); // calling next middleware
      //}
      //else if (profile == "professor")
      //{
      //  // TODO
      //}
      //else if (profile == "leitor")
      //{
      //  // TODO
      //}

      if (profile == "Ada")
      {
        await _next(httpContext);
      }
      else
      {
        httpContext.Response.StatusCode = 401;
        await httpContext.Response.WriteAsJsonAsync(new
        {
          Message = "Perfil não autorizado"
        });
      }
    }
  }
}
