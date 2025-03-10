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
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public void Add(Subscribe entity)
        {
            _subscribeDal.Add(entity);  
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Subscribe> GetAll()
        {
            return _subscribeDal.GetAll();
        }

        public Subscribe GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Subscribe entity)
        {
            throw new NotImplementedException();
        }
    }
}
