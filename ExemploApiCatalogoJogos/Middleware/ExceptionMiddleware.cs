using System.Net;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

#pragma warning disable CS0051 // Acessibilidade inconsistente: tipo de parâmetro "RequestDelegate" é menos acessível do que o método "ExceptionMiddleware.ExceptionMiddleware(RequestDelegate)"
        public ExceptionMiddleware(RequestDelegate next)
#pragma warning restore CS0051 // Acessibilidade inconsistente: tipo de parâmetro "RequestDelegate" é menos acessível do que o método "ExceptionMiddleware.ExceptionMiddleware(RequestDelegate)"
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch
            {
                await HandleExceptionAsync(context);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _ = await context.Response.WriteAsJsonAsync(new { Message = "Ocorreu um erro durante sua solicitação, por favor, tente novamente mais tarde" });
        }
    }

    public class HttpContext
    {
        public object Response { get; internal set; }
    }
}
