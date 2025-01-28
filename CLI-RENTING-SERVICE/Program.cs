// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting Renting Service");

String? input;

while(true){
    input = Console.ReadLine();
    if(input == null){
        Environment.Exit(1);
    }else if(input.ToLower() == "exit"){
        Environment.Exit(0);
    }

    Console.WriteLine(String.Format("Echo: {0}!", input));
}