using Microsoft.OpenApi.Models;
using System.Text;
using WebAppMini;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
});

app.MapGet("/", () => "Mini ASP NET application");

// Sum?a=5&b=6
app.MapGet("/Sum", (int a, int b) => $"{a} + {b} = {a + b}");

// Sum1?a=5&b=6&c=8
app.MapGet("/Sum1", (async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var paramList = context.Request.Query;
    int paramsSum = 0;
    /*
    paramsSum = Int32.Parse(context.Request.Query["a"]) + Int32.Parse(context.Request.Query["b"] +
        Int32.Parse(context.Request.Query["c"]));
    */
    foreach (var param in paramList)
    {
        paramsSum += Int32.Parse(param.Value);
    }
    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
        $"<p>QueryString: {context.Request.QueryString}</p>" +
        $"<p> Parametrs Sum is {paramsSum}");
}));

app.MapGet("/Fail", (async (context) =>
{ 
        context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Resource Not Found");
}));

app.MapGet("/Redirect", (async (context) =>
{
     context.Response.Redirect("/Fail");
}));

app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));

app.Run();


