using BookStore.EnttityLayer.Concrete;

namespace BookStore.WebApi.Dtos.CategoryDto
{
    public class UpdateCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
