using System.Text;
using WebAppMiniDI;


#region All services
 /*
var builder = WebApplication.CreateBuilder(args);
IServiceCollection allServices = builder.Services;

var app = builder.Build();


app.Run(async context =>
{
    var sb = new StringBuilder();
    sb.Append("<h1>All services</h1>");
    sb.Append("<table>");
    sb.Append("<tr><th>Type</th><th>Lifetime</th></tr>");
    foreach (var svc in allServices)
    {
        sb.Append("<tr>");
        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
        sb.Append($"<td>{svc.Lifetime}</td>");
        sb.Append("</tr>");
    }
    sb.Append("</table>");
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync(sb.ToString());
});

app.Run();
  */
#endregion


#region simple DI
 /*
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ITimeService, ShortTimeService>();
//or
//builder.Services.AddTransient<ITimeService, LongTimeService>();

var app = builder.Build();

app.Run(async context =>
{
    var timeService = app.Services.GetService<ITimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});

app.Run();
 */
#endregion

#region DI
 /*
var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<ITimeService, ShortTimeService>();
builder.Services.AddTransient<TimeMessage>();

var app = builder.Build();

app.Run(async context =>
{
    var timeMessage = context.RequestServices.GetService<TimeMessage>();
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
});

app.Run();
 */
#endregion

#region DI scopes
// /*
var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<ICounter, RandomCounter>();
builder.Services.AddTransient<CounterService>();

// or

//builder.Services.AddScoped<ICounter, RandomCounter>();
//builder.Services.AddScoped<CounterService>();

// or

//builder.Services.AddSingleton<ICounter, RandomCounter>();
//builder.Services.AddSingleton<CounterService>();

var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

app.Run();

// */
#endregion