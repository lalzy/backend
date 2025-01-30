var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RentingService rentingService = new RentingService();

// rentingService.rentBook;
// rentingService.ListAllBooks
// rentingService.ReturnBook

app.MapGet("/books", () => {
    var bookList = rentingService.ListAllBooks().Select(entry=>entry.Key);

    return Results.Ok(bookList);
});

app.MapPost("/borrow", (BorrowRequest borrowRequest)=>{
    BorrowReceipt? br = rentingService.rentBook(borrowRequest.Title);
    if(br == null){
        return Results.BadRequest("Not available");
    }else{
        // return Results.Accepted($"Book: {br.Title}");
        return Results.Ok(br);
    }
});

app.Run();

