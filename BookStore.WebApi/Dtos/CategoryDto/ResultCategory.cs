using BookStore.EnttityLayer.Concrete;

namespace BookStore.WebApi.Dtos.CategoryDto
{
    public class ResultCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //[JsonIgnore]
        
    }
}
