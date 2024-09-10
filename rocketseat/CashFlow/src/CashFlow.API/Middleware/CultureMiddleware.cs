using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        List<CultureInfo> supportedLanguages = [.. CultureInfo.GetCultures(CultureTypes.AllCultures)];
        CultureInfo defaultCulture = new("en");
        
        string? requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        if (
               !string.IsNullOrEmpty(requestedCulture)
            && supportedLanguages.Exists(l => l.Name.Equals(requestedCulture))
        ) { 
            defaultCulture = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = defaultCulture;
        CultureInfo.CurrentUICulture = defaultCulture;

        await next(context);

    }
}
