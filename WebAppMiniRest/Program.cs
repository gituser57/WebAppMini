using System.Text;

#region template
 /*
var app = WebApplication.Create(args);
app.Map("/", () => "First app: Hello wold");
app.Run();

 */
#endregion

#region middleware
/*

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("<p>Hello user!</p>");
    await next.Invoke();
});

app.Use(async (context, next) =>
{
    await Task.Delay(1000);
    await context.Response.WriteAsync("<p>Hope, you are doing well</p>");
    await next.Invoke();
});


app.Run(async (context) =>
{
    await Task.Delay(1000); 
    await context.Response.WriteAsync("<p>Good bye, user...</p>");
});

app.Run();

 */
#endregion

#region Routing
// /*

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Map("/", () => "Mini ASP NET application");

// Sum?a=5&b=6
app.Map("/Sum", (int a, int b) => $"{a} + {b} = {a + b}");

// Sum1?a=5&b=6&c=8
app.Map("/Sum1", (async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var paramList = context.Request.Query;
    int paramsSum = 0;
    
    //paramsSum = Int32.Parse(context.Request.Query["a"]) + Int32.Parse(context.Request.Query["b"] +
    //    Int32.Parse(context.Request.Query["c"]));
    
    foreach (var param in paramList)
    {
        paramsSum += Int32.Parse(param.Value);
    }
    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
        $"<p>QueryString: {context.Request.QueryString}</p>" +
        $"<p> Parametrs Sum is {paramsSum}");
}));

app.Map("/Fail", (async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Resource Not Found");
}));

app.Map("/Redirect", (async (context) =>
{
    context.Response.Redirect("/Fail");
}));

app.Run();
// */
#endregion


//var builder = WebApplication.CreateBuilder();

//var app = builder.Build();

//app.Run(async (context) => await context.Response.WriteAsync("Hello"));
//app.Run();

//var builder = WebApplication.CreateBuilder();
//var app = builder.Build();
//app.Run(HandleRequst);
//app.Run();

//async Task HandleRequst(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello");
//}






