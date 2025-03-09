using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStore.EnttityLayer.Concrete
{
    public  class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(400)]
        public string ProductDesc { get; set; }

        [StringLength(100)]
        public string ProductWriterName { get; set; }
        public string ProductImageUrl { get; set; }


        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
        //[JsonIgnore]
        public Category Category { get; set; }


    }
}
