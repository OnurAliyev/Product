using Product.Core.Utilities.Helpers;
using Product.Core.Utilities.Exceptions;
using Product.Core.Entities;

string appStart = "Application started...";
string Welcome = "Welcome!";
Console.SetCursorPosition((Console.WindowWidth - appStart.Length) / 2, Console.CursorTop);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(appStart);
Console.SetCursorPosition((Console.WindowWidth - Welcome.Length) / 2, Console.CursorTop);
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(Welcome);
Console.ResetColor();

Directory.CreateDirectory(@".\ProductDB");
if (!File.Exists(@".\ProductDB\product.txt"))
{
    File.Create(@".\ProductDB\product.txt");
}
bool runApp = true;
while (runApp)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("1 == Create product\n" +
                      "2 == Get list products\n" +
                      "0 == Close app\n" +
                      " ");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Chosse the option >> ");
    Console.ResetColor();

    string? option = Console.ReadLine();
    int IntOption;
    bool IsInt = int.TryParse(option, out IntOption);
    if (IsInt)
    {
        if (IntOption >= 0 && IntOption <= 2)
        {
            switch (IntOption) 
            {
                case (int)Menu.Create:
                    try
                    {
                        Console.Write("Enter product's id: ");
                        int productId;
                        while(!int.TryParse(Console.ReadLine(), out productId))
                        {
                            throw new WrongFormatException("Wrong format id! Please try again...");
                        }
                        Console.Write("Enter product's name: ");
                        string? productName=Console.ReadLine();
                        while (String.IsNullOrEmpty(productName))
                        {
                            throw new EmptyNameException("Product's name can't be null or empty");
                        }
                        Console.Write("Enter product's category: ");
                        string? productCategory = Console.ReadLine();
                        while (String.IsNullOrEmpty(productCategory))
                        {
                            throw new EmptyNameException("Product's category can't be null or empty");
                        }
                        Console.Write("Enter product's price: ");
                        decimal productPrice;
                        while(!decimal.TryParse(Console.ReadLine(),out productPrice))
                        {
                            throw new WrongFormatException("Wrong format id! Please try again...");
                        }
                        Product.Core.Entities.Product product = new(productId, productName, productCategory, productPrice);
                        StreamWriter sw = new(@".\ProductDB\product.txt");
                        sw.WriteLine($"ID:{product.Id}; " +
                                     $"Name: {product.Name}; " +
                                     $"Category: {product.Category}; " +
                                     $"Price: {product.Category};" +
                                     $"Created time: {product.CreatedTime} ");
                        sw.Close();

                    }
                    catch(Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        goto case (int)Menu.Create;
                    }
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter correct number!");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter correct format!");
        Console.ResetColor();
    }
}
