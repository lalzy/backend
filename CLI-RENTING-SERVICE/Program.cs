// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting Renting Service");

String? input;

while(true){
    input = Console.ReadLine();
    if(input == null){
        Environment.Exit(1);
    }
    
    switch(input.ToLower()){
        case "0":
        case "exit":
            Environment.Exit(0);
            break;
        case "list":
            break;
        case "borrow":
            break;
        case "return":
            break;
        default:
            Console.WriteLine("Invalid Selection!");
            break;
    }

    Console.WriteLine(String.Format("Echo: {0}", input));
}