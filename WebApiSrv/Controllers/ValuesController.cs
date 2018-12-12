using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSrv.Models;

namespace WebApiSrv.Controllers
{
    public class ValuesController : ApiController
    {
        private BookContext _bookContext = new BookContext();
        // GET api/values
        public IEnumerable<Book> GetBooks()
        {
            return _bookContext.Books;
        }

        // GET api/values/5
        public Book GetBook(int id)
        {
            var book = _bookContext.Books.Find(id);
            return book;
        }

        // POST api/values
        [HttpPost]
        public void AddBook([FromBody]Book book)
        {
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if(id == book.Id)
            {
                _bookContext.Entry(book).State = System.Data.Entity.EntityState.Modified;
                _bookContext.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var book = _bookContext.Books.Find(id);
            if(book != null)
            {
                _bookContext.Books.Remove(book);
                _bookContext.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
