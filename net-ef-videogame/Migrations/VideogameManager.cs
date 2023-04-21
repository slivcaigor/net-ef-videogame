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
                Console.Write("Release date (dd/mm/yyyy): ");
                string date = Console.ReadLine() ?? throw new ArgumentNullException(nameof(date));

                if (DateTime.TryParse(date, out releaseDate))
                    break;

                Console.WriteLine("Invalid input. Please enter a valid release date in the format dd-mm-yyyy.");
            }

            // display all software houses
            Console.WriteLine("Software Houses:");
            var softwareHouses = context.SoftwareHouses.ToList();
            foreach (var availableSoftwareHouse in softwareHouses)
            {
                Console.WriteLine($"[{availableSoftwareHouse.Id}] {availableSoftwareHouse.Name}");
            }

            // choose a valid software house ID
            while (true)
            {
                Console.Write("Choose the software house ID: ");
                string idSoftwareHouse = Console.ReadLine() ?? throw new ArgumentNullException(nameof(idSoftwareHouse));

                if (int.TryParse(idSoftwareHouse, out softwareHouseId))
                {
                    var validSoftwareHouse = softwareHouses.FirstOrDefault(s => s.Id == softwareHouseId);

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
            using var context = new VideogameDbContext();
            Console.Write("Enter the ID of the videogame to delete: ");

            int id;
            while (true)
            {
                string gameId = Console.ReadLine() ?? throw new ArgumentNullException(nameof(gameId));

                if (int.TryParse(gameId, out id))
                    break;

                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }

            var videogame = context.Videogames.Find(id);

            if (videogame == null)
            {
                Console.WriteLine($"Error: videogame with ID {id} not found");
                return;
            }

            context.Videogames.Remove(videogame);
            context.SaveChanges();

            Console.WriteLine($"Videogame {videogame.Name} with ID {videogame.Id} has been deleted.");
        }

        public static void InsertSoftwareHouse()
        {
            using var context = new VideogameDbContext();
            Console.WriteLine("Insert the software house details:");

            string name, city;

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
                Console.Write("City: ");
                city = Console.ReadLine() ?? throw new ArgumentNullException(nameof(city));

                if (!string.IsNullOrEmpty(city))
                    break;

                Console.WriteLine("Invalid input. Please enter a non-empty city.");
            }

            // create a new SoftwareHouse instance
            var softwareHouse = new SoftwareHouse
            {
                Name = name,
                City = city
            };

            // add the new SoftwareHouse to the context and save changes to the database
            context.SoftwareHouses.Add(softwareHouse);
            context.SaveChanges();

            Console.WriteLine("Software house added successfully");
        }

    }
}
