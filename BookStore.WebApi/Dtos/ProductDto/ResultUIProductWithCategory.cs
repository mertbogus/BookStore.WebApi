namespace BookStore.WebApi.Dtos.ProductDto
{
    public class ResultUIProductWithCategory
    {
        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public string ProductWriterName { get; set; }
        public string ProductImageUrl { get; set; }


        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        public string CategoryName { get; set; }
        //[JsonIgnore]
    }
}
