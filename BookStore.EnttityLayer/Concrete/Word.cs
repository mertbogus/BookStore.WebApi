using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public  class Word
    {
        public int WordId { get; set; }
        public string WordContent { get; set; }
        public string WordWriter { get; set; }
    }
}
