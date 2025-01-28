// See https://aka.ms/new-console-template for more information
String? input;

RentingService rentingService = new RentingService();
List<BorrowReceipt> borrowedBooks = new List<BorrowReceipt>();

while(true){
    Console.WriteLine("");
    Console.WriteLine("=== Welcome to the renting service ===");
    Console.WriteLine("exit or 0 - to exit");
    Console.WriteLine("list or 1 - to list all books");
    Console.WriteLine("borrow or 2 - to borrow a book");
    Console.WriteLine("return or 2 - to return a book");
    Console.Write(">> ");

    input = Console.ReadLine();
    if(input == null){
        Environment.Exit(1);
    }
    
    switch(input.ToLower()){
        case "0":
        case "exit":
            Environment.Exit(0);
            break;
        case "1":
        case "list":
        Console.WriteLine("--------");
            foreach (var book in rentingService.ListAllBooks()){
                Console.WriteLine(String.Format("Book: {0} by {1}, Available: {2}", 
                    book.Key.title, book.Key.author, book.Value));
            }
            break;
        case "2":
        case "borrow":
            Console.WriteLine("What book would you like to borrow?");
            Console.Write(">> ");
            input = Console.ReadLine();
            if(input != null){
                BorrowReceipt receipt = rentingService.rentBook(input);
                if(receipt != null){
                    borrowedBooks.Add(receipt);
                    Console.WriteLine(String.Format("Title = {0}, Date borrowed=[{1}], Due Date=[{2}]", receipt.title, receipt.borrowDate, receipt.returnDate));
                }
            }
            break;
        case "3":
        case "return":
            Console.WriteLine("What book would you like to borrow?");
            Console.Write(">> ");
            input = Console.ReadLine();
            if(input != null){
                foreach(BorrowReceipt br in borrowedBooks){
                    if(br.title.ToLower() == input.ToLower()){
                        rentingService.ReturnBook(input, br.borrowDate);
                        break;
                    }
                }

            }
            break;
        default:
            Console.WriteLine("Invalid Selection!");
            break;
    }

    Console.WriteLine("");
    Console.WriteLine("-----------");
    Console.WriteLine("");
}