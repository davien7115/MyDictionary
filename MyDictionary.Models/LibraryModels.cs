using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MyDictionaryModels
{
    [SwaggerSchema("Specifies the database context for the library")]
    [Table("words", Schema = "app")]
    public class LibraryModels
    {
        [Key]
        public int word_id { get; set; }

        [SwaggerSchema("The foreign word")]
        public string word { get; set; }

        [SwaggerSchema("That is the meaning of the foreign word")]
        public string mean { get; set; }
    }
}