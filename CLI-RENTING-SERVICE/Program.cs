// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting Renting Service");

String? input;

while(true){
    input = Console.ReadLine();
    if(input == null){
        Environment.Exit(1);
    }

    switch(input){
        case "0":
            Environment.Exit(0);
            break;
        case "1":
            break;
        case "2":
            break;
        default:
            Console.WriteLine("Invalid Selection!");
            break;
    }

    Console.WriteLine(String.Format("Echo: {0}", input));
}