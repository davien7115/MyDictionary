using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MyDictionary.Models
{
    [SwaggerSchema("Specifies the database context for the library")]
    [Table("words", Schema = "app")]
    public class LibraryModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Identity Number")]
        public int word_id { get; set; }

        [Required]
        [Column("word", TypeName = "varchar(120)")]
        [SwaggerSchema("The foreign word")]
        public string word { get; set; }

        [Required]
        [Column("mean", TypeName = "varchar(120)")]
        [SwaggerSchema("That is the meaning of the foreign word")]
        public string mean { get; set; }
    }
}