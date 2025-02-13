using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EnttityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfcategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfcategoryDal(BookStoreContext context) : base(context)
        {
        }
    }
}
