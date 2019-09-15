using System;
using System.Collections.Generic;
using System.Linq;
using Lunchbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lunchbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity> : Controller where TEntity : DbEntity
    {
        private readonly LunchboxContext _context;

        protected BaseController(LunchboxContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TEntity> Get() {
            return _context.Set<TEntity>().ToList();
        }

        [HttpGet("{id}")]
        public TEntity Get(int id) {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return CreatedAtAction(nameof(entity), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TEntity entity)
        {
            if(id != entity.Id)
            {
                return BadRequest();
            }
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
