namespace MyDictionaryAPI.DTOs.Term
{
    //This DTO is used to update an existing term in the dictionary
    public class UpdateTermDto
    {
        public string Term { get; set; }
        public string Definition { get; set; }

    }
}
