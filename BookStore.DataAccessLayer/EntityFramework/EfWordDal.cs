using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.Repositories;
using BookStore.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.EntityFramework
{
    public class EfWordDal : GenericRepository<Word>, IWordDal
    {
        public EfWordDal(BookStoreContext context) : base(context)
        {
        }

        public Word GetLastWord()
        {
            using var context = new BookStoreContext();
            var words= context.Words.OrderByDescending(x => x.WordId).FirstOrDefault();
            return words;
        }
    }
}
