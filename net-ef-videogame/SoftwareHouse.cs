using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_ef_videogame
{
    [Table("softwarehouses")] // the name of the table in the database that will be associated with the SoftwareHouse class
    public class SoftwareHouse 
    {
        [Key] // specifies that the Id property is the primary key of the table
        [Column("id")] // specifies the name of the column in the database table that the property refers to
        public int Id { get; set; } 

        [Column("name")]
        [Required] // specifies that the value of the property is required
        [MaxLength(32)] // specifies the maximum length of the value of the property
        public string? Name { get; set; } 

        [Column("city")] 
        [Required] 
        [MaxLength(64)] 
        public string? City { get; set; }

        // The Videogames property is of type List<Videogame> and represents the one-to-many relationship between the softwarehouses table and the videogames table
        public List<Videogame>? Videogames { get; set; } // a software house can produce multiple videogames
    }
}
