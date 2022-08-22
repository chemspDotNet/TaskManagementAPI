using System;
using System.Collections.Generic;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{

    public class QuoteRepository : IQuoteRepository
    {
        private List<Quote> quotes = new List<Quote>();
        private int _nextId = 1;

        public QuoteRepository()
        {
            Add(new Quote()
            {

                Description = "This a house insurance",
                QuoteId = _nextId,
                DueDate = DateTime.Now,
                Premium = 200,
                Sales = "Paul",
                QuoteType = "House"
            });


        }

        public IEnumerable<Quote> GetAll()
        {
            return quotes;
        }

        public Quote Get(int id)
        {
            return quotes.Find(q => q.QuoteId == id);
        }

        public Quote Add(Quote item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.QuoteId = _nextId++;
            quotes.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            quotes.RemoveAll(q => q.QuoteId == id);
        }

        public bool Update(Quote item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = quotes.FindIndex(q => q.QuoteId == item.QuoteId);
            if (index == -1)
            {
                return false;
            }
            quotes.RemoveAt(index);
            quotes.Add(item);
            return true;
        }
    }
}