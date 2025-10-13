using System.Text.Json;
using PostsConsole;

ServerConnection server = new("http://localhost:3000/api/");

MenuOption[] menuOptions = [
    new MenuOption("Get all posts", async () => { Console.WriteLine(string.Join(", ", await server.GetPosts())); })
];
MenuOption[] loggedInOptions = [];
MenuOption[] loggedOutOptions = [
    new MenuOption("Register", async () => {Console.WriteLine(await server.Register(RequestString("Name"), RequestString("Password"), RequestOptionalString("About text"))); }),
    new MenuOption("Log in", async () => {Console.WriteLine(await server.Login(RequestString("Name"), RequestString("Password"))); })
];

while (true) await ShowMenu();

async Task ShowMenu()
{
    List<MenuOption> currentOptions = [.. menuOptions];
    if (server.IsLoggedIn)
    {
        Console.WriteLine("You're currently logged in.");
        currentOptions.AddRange(loggedInOptions);
    }
    else currentOptions.AddRange(loggedOutOptions);
    for (int i = 0; i < currentOptions.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {currentOptions[i].Name}");
    }
    await currentOptions[RequestNumber("Choose a number") - 1].Execute();
    Console.WriteLine();
}


int RequestNumber(string prompt)
{
    int number;
    do Console.Write(prompt + ": ");
    while (!int.TryParse(Console.ReadLine(), out number));
    return number;
}

static string RequestString(string prompt)
{
    string? input;
    do
    {
        Console.Write(prompt + ": ");
        input = Console.ReadLine();
    }
    while (input == null || input == "");
    return input;
}

static string RequestOptionalString(string prompt)
{
    string? input;
    do
    {
        Console.Write(prompt + "(optional): ");
        input = Console.ReadLine();
    }
    while (input == null);
    return input;
}
