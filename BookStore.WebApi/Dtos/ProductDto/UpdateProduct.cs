﻿namespace BookStore.WebApi.Dtos.ProductDto
{
    public class UpdateProduct
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public string ProductWriterName { get; set; }
        public string ProductImageUrl { get; set; }


        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
