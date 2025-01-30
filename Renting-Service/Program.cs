var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RentingService rentingService = new RentingService();

// rentingService.rentBook;
// rentingService.ListAllBooks
// rentingService.ReturnBook

app.MapGet("/", () => {
    var bookList = rentingService.ListAllBooks().Select(entry=>entry.Key);

    return Results.Ok(bookList);
});

app.Run();

