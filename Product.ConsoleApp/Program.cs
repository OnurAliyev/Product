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
    Console.WriteLine("1 == Create product\n"+
                      "2 == Get list products\n"+
                      "0 == Close app\n"+
                      " ");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Chosse the option >> ");
    Console.ResetColor();
    Console.ReadLine();
}
