using BookStore.EnttityLayer.Concrete;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebUI.Dtos.ProductDtos
{
    public class CreateProductDto
    {

       
        public string ProductName { get; set; }

        
        public string ProductDesc { get; set; }

       
        public string ProductWriterName { get; set; }

        public string ProductImageUrl { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
        

    }
}
