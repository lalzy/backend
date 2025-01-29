// See https://aka.ms/new-console-template for more information
String? input;

RentingService rentingService = new RentingService();
List<BorrowReceipt> borrowedBooks = new List<BorrowReceipt>();

while(true){
    Console.WriteLine("");
    Console.WriteLine("=== Welcome to the renting service ===");
    Console.WriteLine("exit[0] - to exit");
    Console.WriteLine("list[1] - to list all books");
    Console.WriteLine("borrow[2] - to borrow a book");
    Console.WriteLine("return[3] - to return a book");
    Console.Write(">> ");
    input = Console.ReadLine();
    Console.Clear();
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
                BorrowReceipt? receipt = rentingService.rentBook(input);
                if(receipt != null){
                    borrowedBooks.Add(receipt);
                    Console.WriteLine(String.Format("Title = {0}, Date borrowed=[{1}], Due Date=[{2}]", receipt.title, receipt.borrowDate, receipt.returnDate));
                }else{
                    Console.WriteLine("Book is not available.");
                }
            }
            break;
        case "3":
        case "return":
            Console.WriteLine("What book would you like to borrow?");
            Console.Write(">> ");
            input = Console.ReadLine();
            if(input != null){
                BorrowReceipt? br = borrowedBooks.FirstOrDefault(entry=>entry.title.Equals(input, StringComparison.OrdinalIgnoreCase));
                if (br == null){
                    Console.WriteLine("No such book has been borrowed");
                }else{
                    ReturnReceipt? rp = rentingService.ReturnBook(input, br.borrowDate);

                    if(rp == null){
                        Console.WriteLine("We have no recod of this book");
                    }else{
                        Console.WriteLine($"Thanks! for returning {input}");
                    }
                }
                // foreach(BorrowReceipt br in borrowedBooks){
                //     if(br.title.ToLower() == input.ToLower()){
                //         rentingService.ReturnBook(input, br.borrowDate);
                //         break;
                //     }
                // }

            }
            break;
        default:
            Console.WriteLine("Invalid Selection!");
            break;
    }

    Console.WriteLine("");
    Console.WriteLine("-----------");
}