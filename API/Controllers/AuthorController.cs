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
    public class AuthorController : ControllerBase
    {
        private readonly BookContext context;
        public AuthorController(BookContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        [HttpPost]
        [Route("AddAuthor")]
        public ActionResult AddAuthor(Author author)
        {
            if (author != null)
            {
                context.Authors.Add(author);
                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }
        [HttpGet]
        [Route("DeleteAuthor/{id}")]
        public ActionResult DeleteAuthor([FromRoute] int id)
        {
            if (id != 0)
            {
                context.Authors.Remove(context.Authors.FirstOrDefault(x => x.Id == id));
                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }
        [HttpPost]
        [Route("EditAuthor")]
        public ActionResult EditAuthor([FromBody] Author author)
        {
            if (author != null)
            {
                context.Authors.Update(author);
                context.SaveChanges();
                return new OkResult();
            }
            return new BadRequestResult();
        }
    }
}
