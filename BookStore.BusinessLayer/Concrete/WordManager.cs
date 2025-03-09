using BookStore.BusinessLayer.Abstract;
using BookStore.DataAccessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLayer.Concrete
{
    public class WordManager : IWordService
    {
        private readonly IWordDal _wordDal;

        public WordManager(IWordDal wordDal)
        {
            _wordDal = wordDal;
        }

        public void Add(Word entity)
        {
            _wordDal.Add(entity);
        }

        public void Delete(int id)
        {
            _wordDal.Delete(id);
        }

        public List<Word> GetAll()
        {
            return _wordDal.GetAll();
        }

        public Word GetById(int id)
        {
           return _wordDal.GetById(id);
        }

        public Word GetLastWord()
        {
            return _wordDal.GetLastWord();
        }

        public void Update(Word entity)
        {
            _wordDal.Update(entity);
        }
    }
}
