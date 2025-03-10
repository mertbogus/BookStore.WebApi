using BookStore.EnttityLayer.Concrete;

namespace BookStore.WebUI.Dtos.CategoryDtos
{
    public class ResultCategoryWithProductDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
