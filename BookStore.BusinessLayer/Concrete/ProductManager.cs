using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EnttityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public async Task<Product> GetRandomProductAsync()
        {
            int count = await TGetProductCount();
            if (count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, count);
            return await _productDal.GetProductByIndexAsync(randomIndex); ;
        }

        public async Task<int> TGetProductCount()
        {
            return _productDal.GetProductCount();

        }

        public void Update(Product entity)
        {
            _productDal.Update(entity); 
        }


    }
}
