namespace MyDictionaryAPI.DTOs.Term
{
    //This DTO is used to create a new term in the dictionary.
    public class CreateTermDto
    {

        public string Term { get; set; }
        public string Definition { get; set; }

    }
}
