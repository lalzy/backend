// See https://aka.ms/new-console-template for more information
String? input;

RentingService rentingService = new RentingService();

while(true){
    Console.WriteLine("");
    Console.WriteLine("=== Welcome to the renting service ===");
    Console.WriteLine("exit or 0 - to exit");
    Console.WriteLine("list or 1 - to list all books");
    Console.WriteLine("borrow or 2 - to borrow a book");
    Console.WriteLine("return or 2 - to return a book");
    Console.WriteLine("");

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
            rentingService.ListAllBooks();
            break;
        case "2":
        case "borrow":
            break;
        case "3":
        case "return":

            break;
        default:
            Console.WriteLine("Invalid Selection!");
            break;
    }

    Console.WriteLine("");
    Console.WriteLine("-----------");
    Console.WriteLine("");
}