using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public interface IQuoteRepository
    {
        
            IEnumerable<Quote> GetAll();
            Quote Get(int id);
            Quote Add(Quote item);
            void Remove(int id);
            bool Update(Quote item);
      
}
}
