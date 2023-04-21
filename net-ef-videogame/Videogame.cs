using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace net_ef_videogame
{
    [Table("videogames")] // Specifies the name of the table that will be associated with the Videogame class
    public class Videogame 
    {
        [Key] // Specifies that the Id property is the primary key of the table
        [Column("id")] // Specifies the name of the column that the property refers to
        public int Id { get; set; } 

        [Column("name")]
        [Required] // Specifies that the value of the property is required
        [MaxLength(64)] // Specifies the maximum length of the value of the property
        public string? Name { get; set; } 

        [Column("overview")] 
        [Required] 
        [MaxLength(500)] 
        public string? Overview { get; set; }

        [Column("release_date")]
        [Required] 
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("SoftwareHouse")] // Specifies that the SoftwareHouse property is a foreign key that references the SoftwareHouse class
        [Column("software_house_id")] 
        [Required] 
        public int SoftwareHouseId { get; set; }

        public SoftwareHouse? SoftwareHouse { get; set; } // The SoftwareHouse property represents the many-to-one relationship between the videogames table and the softwarehouses table

        public void PrintDetails()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Overview: {Overview}");
            Console.WriteLine($"Release Date: {ReleaseDate:dd/MM/yyyy}");
            Console.WriteLine($"Software House: {SoftwareHouse?.Name ?? "Unknown"}\n");
        }
    }
}
