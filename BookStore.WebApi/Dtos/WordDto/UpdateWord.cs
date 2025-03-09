namespace BookStore.WebApi.Dtos.WordDto
{
    public class UpdateWord
    {
        public int WordId { get; set; }
        public string WordContent { get; set; }
        public string WordWriter { get; set; }
    }
}
