using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_ef_videogame
{
    [Table("softwarehouses")] // il nome della tabella che sarà associata alla classe SoftwareHouse
    public class SoftwareHouse 
    {
        [Key] //  specifica che la proprietà Id è la chiave primaria della tabella
        [Column("id")] // specifica il nome della colonna nella tabella del database a cui si riferisce la proprietà
        public int Id { get; set; } 

        [Column("name")] 
        [Required] // specifica che il valore della proprietà è obbligatorio
        [MaxLength(32)] // specifica la lunghezza massima del valore della proprietà
        public string? Name { get; set; } 

        [Column("city")] 
        [Required] 
        [MaxLength(64)] 
        public string? City { get; set; } 

        // La proprietà Videogames è di tipo List<Videogame> e rappresenta la relazione uno-a-molti tra la tabella softwarehouses e la tabella videogames
        public List<Videogame>? Videogames { get; set; } // una software house può aver prodotto più videogiochi
    }
}
