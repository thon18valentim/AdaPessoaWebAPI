namespace AdaPessoaWebApplication.Middlewares
{
  public static class AccountAuthorizationExtensions
  {
    public static IApplicationBuilder UseAccountAuthorization(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<AccountAuthorization>();
    }
  }
}
