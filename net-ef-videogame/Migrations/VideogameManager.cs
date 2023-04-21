using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame.Migrations
{
    public class VideogameManager
    {

        public static void InsertVideogame()
        {
            using var context = new VideogameDbContext();
            Console.WriteLine("Insert the videogame details:");

            string name, overview;
            DateTime releaseDate;
            int softwareHouseId;

            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine() ?? throw new ArgumentNullException(nameof(name));

                if (!string.IsNullOrEmpty(name))
                    break;

                Console.WriteLine("Invalid input. Please enter a non-empty name.");
            }

            while (true)
            {
                Console.Write("Overview: ");
                overview = Console.ReadLine() ?? throw new ArgumentNullException(nameof(overview));

                if (!string.IsNullOrEmpty(overview))
                    break;

                Console.WriteLine("Invalid input. Please enter a non-empty overview.");
            }

            while (true)
            {
                Console.Write("Release date (dd-mm-yyyy): ");
                string date = Console.ReadLine() ?? throw new ArgumentNullException(nameof(date));

                if (DateTime.TryParse(date, out releaseDate))
                    break;

                Console.WriteLine("Invalid input. Please enter a valid release date in the format dd-mm-yyyy.");
            }

            while (true)
            {
                Console.Write("Software house ID: ");
                string idSoftwareHouse = Console.ReadLine() ?? throw new ArgumentNullException(nameof(idSoftwareHouse));

                if (int.TryParse(idSoftwareHouse, out softwareHouseId))
                {
                    var validSoftwareHouse = context.SoftwareHouses.Find(softwareHouseId);

                    if (validSoftwareHouse != null)
                        break;

                    Console.WriteLine($"Error: software house with ID {softwareHouseId} not found");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid software house ID.");
                }
            }

            // retrieve the software house with the specified ID from the database
            var softwareHouse = context.SoftwareHouses.Find(softwareHouseId);

            // create a new Videogame instance
            var videogame = new Videogame
            {
                Name = name,
                Overview = overview,
                ReleaseDate = releaseDate,
                SoftwareHouse = softwareHouse
            };

            // add the new Videogame to the context and save changes to the database
            context.Videogames.Add(videogame);
            context.SaveChanges();

            Console.WriteLine("Videogame added successfully");
        }

        public static void SearchVideogameById()
        {
            using var context = new VideogameDbContext();

            Console.Write("Insert the videogame ID: ");
            string gameId = Console.ReadLine() ?? throw new ArgumentNullException(nameof(gameId));

            if (!int.TryParse(gameId, out int id))
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
                return;
            }

            var videogame = context.Videogames.Include(v => v.SoftwareHouse).FirstOrDefault(v => v.Id == id);

            if (videogame == null)
            {
                Console.WriteLine($"Videogame with ID {id} not found.");
                return;
            }

            videogame.PrintDetails();
        }

        public static void SearchVideogameByName()
        {
            using var context = new VideogameDbContext();

            Console.Write("Insert the name of the videogame to search: ");
            string searchName = Console.ReadLine() ?? throw new ArgumentNullException(nameof(searchName));

            var videogames = context.Videogames
                .Where(m => m.Name != null && m.Name.Contains(searchName))
                .Include(m => m.SoftwareHouse)
                .ToList();

            if (videogames.Count == 0)
            {
                Console.WriteLine($"No videogame found with name '{searchName}'");
                return;
            }

            foreach (var videogame in videogames)
            {
                videogame.PrintDetails();
            }
        }


        public static void DeleteVideogame()
        { 
        }

        public static void InsertSoftwareHouse()
        {
        }
    }
}
