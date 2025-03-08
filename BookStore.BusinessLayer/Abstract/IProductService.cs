using BookStore.EnttityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Abstract
{
    public  interface IProductService : IGenericService<Product>
    {
        Task< int> TGetProductCount();
        Task<Product> GetRandomProductAsync();
    }
}
