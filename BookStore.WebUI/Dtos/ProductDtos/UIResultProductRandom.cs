using BookStore.EnttityLayer.Concrete;

namespace BookStore.WebUI.Dtos.ProductDtos
{
    public class UIResultProductRandom
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public string ProductWriterName { get; set; }

        public string ProductImageUrl { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public class ProductResponseDto
        {
            public List<UIResultProductRandom> Data { get; set; }
        }
    }
}
