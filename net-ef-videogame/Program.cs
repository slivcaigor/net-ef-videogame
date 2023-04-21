using net_ef_videogame.Migrations;

namespace net_ef_videogame
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Insert a new videogame");
                Console.WriteLine("2. Search for a videogame by ID");
                Console.WriteLine("3. Search for a videogame by name");
                Console.WriteLine("4. Delete a videogame");
                Console.WriteLine("5. Insert a new software house");
                Console.WriteLine("6. Close the program");

                key = Console.ReadKey(true);

                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        VideogameManager.InsertVideogame();
                        break;
                    case '2':
                        Console.Clear();
                        VideogameManager.SearchVideogameById();
                        break;
                    case '3':
                        Console.Clear();
                        VideogameManager.SearchVideogameByName();
                        break;
                    case '4':
                        Console.Clear();
                        VideogameManager.DeleteVideogame();
                        break;
                    case '5':
                        Console.Clear();
                        VideogameManager.InsertSoftwareHouse();
                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Console.ReadLine();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid option! Choose one of the provided options");
                        break;
                }
                Console.WriteLine();
            } while (key.KeyChar != '5');

        }
    }
}