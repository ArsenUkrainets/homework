using API.Context;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookContext context;
        public BookController(BookContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBook(Book book)
        {
            if (book != null)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }
        [HttpGet]
        [Route("DeleteBook/{id}")]
        public ActionResult DeleteBook([FromRoute] int id)
        {
            if (id != 0)
            {
                context.Books.Remove(context.Books.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }
        [HttpPost]
        [Route("EditBook")]
        public ActionResult EditBook([FromBody] Book book)
        {
            if (book != null)
            {
                context.Books.Update(book);
                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }
        [HttpGet]
        [Route("GetSingleBook/{id}")]
        public Book GetSingleBook([FromRoute] int id)
        {
            if(id != 0)
            {
                return context.Books.FirstOrDefault(x => x.Id == id); 
            }
            return null;
        }
    }
}
