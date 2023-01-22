using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Kizilpinar Svitlana");
app.MapGet("home/info", (context) =>
{
    StringBuilder b = new StringBuilder();
    if (context.Request.Query.ContainsKey("firstname"))
    {
        string firstname = context.Request.Query["firstname"];
        b.AppendLine($"<div style='color: green; font-size: 18px'>Firstname: {firstname}</div>");
    }
    if (context.Request.Query.ContainsKey("lastname"))
    {
        string lastname = context.Request.Query["lastname"];
        b.AppendLine($"<div style='color: green; font-size: 18px'>Lastname: {lastname}</div>");
    }
    return context.Response.WriteAsync(b.ToString());
});
app.Map("home/date", (context) =>
{
    StringBuilder sb = new StringBuilder();
    string date = DateTime.Now.ToString("dd/MM/yyyy");
    context.Response.Headers.ContentType = "text/html; charset=utf-8";
    sb.AppendLine($"<h2 style='color: navy;'>Name of application: {app.Environment.ApplicationName}</h2>");
    sb.AppendLine($"<h2>{date}</h2>");
    return context.Response.WriteAsync(sb.ToString());   
});
app.Map("home/list", (context) =>
{
    StringBuilder sb = new StringBuilder();
    sb.AppendLine($"<ul><li>show firstname and lastname</li><li>show current date</li><li>show list</li></ul>");
    context.Response.Headers.Add("Content-Type", "text/html;charset=utf-8");
    return context.Response.WriteAsync(sb.ToString());
});
app.Map("home/", (context) =>
{
    context.Response.Headers.ContentType = "text/html; charset=utf-8";
    return context.Response.WriteAsync("<h2 style='color: navy;'>Start</h2>");
});

app.Run();