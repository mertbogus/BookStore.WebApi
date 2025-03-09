using BookStore.EntityLayer.Concrete;
using BookStore.EnttityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccessLayer.Abstract
{
    public interface IWordDal : IGenericDal<Word>
    {
        Word GetLastWord();
    }
}
