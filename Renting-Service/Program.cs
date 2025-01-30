var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (String x = "") => {
    //var jsonPayload = new {message = "Hello", content = "testing testing"};
    //return Results.Ok(jsonPayload);
});

app.MapPost("/", (BorrowRequest requestBody) => {
    Console.WriteLine($"{requestBody.Message}");
    Console.WriteLine($"{requestBody.Number}");
    return Results.Accepted("");
});

app.MapPut("/{articleId}", (int articleId) => {
    Console.WriteLine(articleId);
    return Results.Accepted();
});

app.MapDelete("/", () => {
    return Results.Created();
});

app.Run();

