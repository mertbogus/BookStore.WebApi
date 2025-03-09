using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EnttityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(BookStoreContext context) : base(context)
        {
        }
        public int GetProductCount()
        {
            var context = new BookStoreContext();
            int value = context.Products.Count();
            return value;
        }

        public async Task<Product> GetProductByIndexAsync(int index)
        {
            // Belirtilen index'teki ürünü döndürür
            var context = new BookStoreContext();
            return await context.Products.Skip(index).FirstOrDefaultAsync();
        }

        public List<Product> GetCategoryAndProduct()
        {
            using var context = new BookStoreContext();
            return context.Products
                .Include(x => x.Category)
                .ToList();
        }

    }
}
