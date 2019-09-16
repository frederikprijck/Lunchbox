using System;
using System.Collections.Generic;
using System.Linq;
using Lunchbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
            Log.Debug($"GET request on resource {0}", typeof(TEntity));
            return _context.Set<TEntity>().ToList();
        }

        [HttpGet("{id}")]
        public TEntity Get(int id) {
            Log.Debug($"GET request on resource {0} with ID {1}", typeof(TEntity), id);
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TEntity entity)
        {
            Log.Debug($"POST request on resource {0}", typeof(TEntity));

            // Check before cast. 'as' turns entity into null when it fails
            if (entity is AuditableDbEntity) {
                (entity as AuditableDbEntity).CreatedBy = "System";
                (entity as AuditableDbEntity).CreatedOn = DateTime.Now;
                (entity as AuditableDbEntity).ModifiedBy = "System";
                (entity as AuditableDbEntity).ModifiedOn = DateTime.Now;
            }
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TEntity entity)
        {
            Log.Debug($"PUT request on resource {0}", typeof(TEntity));

            if (id != entity.Id)
            {
                Log.Debug($"Error in PUT request on resource {0}: Route ID is {1} but Entity ID is {2}", typeof(TEntity), id, entity.Id);
                return BadRequest();
            }
            if (entity is AuditableDbEntity)
            {
                (entity as AuditableDbEntity).ModifiedBy = "System";
                (entity as AuditableDbEntity).ModifiedOn = DateTime.Now;
            }
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] TEntity entity)
        {
            Log.Debug($"DELETE request on resource {0}", typeof(TEntity));

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
