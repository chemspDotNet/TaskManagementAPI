using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers
{
    [Authorize]
    public class QuotesController : ApiController
    {
        static readonly IQuoteRepository repository = new QuoteRepository();
        [HttpGet]
        public IEnumerable<Quote> GetAllQuotes()
        {
            return repository.GetAll();
        }
        [HttpGet]
        public Quote GetProduct(int id)
        {
            Quote item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        [HttpPost]
        public HttpResponseMessage PostProduct([FromBody]Quote quote)
        {
            if (ModelState.IsValid)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return errorresponse;
            }
            quote = repository.Add(quote);
            var response = Request.CreateResponse<Quote>(HttpStatusCode.Created, quote);

            string uri = Url.Link("DefaultApi", new { id = quote.QuoteId });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public IHttpActionResult PutProduct(int id, [FromBody] Quote quote)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            quote.QuoteId = id;

            if (!repository.Update(quote))
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            Quote item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }


}
