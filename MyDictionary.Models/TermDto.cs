namespace MyDictionary.Models;

public class TermDto
{
    //This DTO is used to represent a term in the dictionary when retrieving data from the API.

    public int Id { get; set; }       // maps from entity: word_id
    public string Term { get; set; }  // maps from entity: word
    public string Definition { get; set; } // maps from entity: mea

}
