using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace net_ef_videogame
{
    [Table("videogames")] // il nome della tabella che sarà associata alla classe Videogame
    public class Videogame 
    {
        [Key] // specifica che la proprietà Id è la chiave primaria della tabella
        [Column("id")] // specifica il nome della colonna a cui si riferisce la proprietà
        public int Id { get; set; } 

        [Column("name")] 
        [Required] // specifica che il valore della proprietà è obbligatorio
        [MaxLength(64)] // specifica la lunghezza massima del valore della proprietà
        public string? Name { get; set; } 

        [Column("overview")] 
        [Required] 
        [MaxLength(500)] 
        public string? Overview { get; set; }

        [Column("release_date")]
        [Required] 
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("SoftwareHouse")] // specifica che la proprietà SoftwareHouse è una foreign key che fa riferimento alla classe SoftwareHouse
        [Column("software_house_id")] 
        [Required] 
        public int SoftwareHouseId { get; set; } 

        public SoftwareHouse? SoftwareHouse { get; set; } // la proprietà SoftwareHouse rappresenta la relazione molti-a-uno tra la tabella videogames e la tabella softwarehouses
    }
}
