using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BalotoResults.Models;
using System.Linq;
using System;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class ResultController : Controller
    {
        private readonly ResultsContext _context;

        public ResultController(ResultsContext context)
        {
            _context = context;

            if (_context.Results.Count() == 0)
            {
                _context.Results.Add(new Result { 
                    Year = 2018,
                    Date = DateTime.Now 
                    });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Result> GetAll()
        {
            return _context.Results.ToList();
        }

        [HttpGet("{id}", Name = "GetResult")]
        public IActionResult GetById(long id)
        {
            var result = _context.Results.FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return new ObjectResult(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Result result)
        {
            if (result == null)
            {
                return BadRequest();
            }

            _context.Results.Add(result);
            _context.SaveChanges();

            return CreatedAtRoute("GetResult", new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Result result)
        {
            if (result == null || result.Id != id)
            {
                return BadRequest();
            }

            var resultBD = _context.Results.FirstOrDefault(t => t.Id == id);
            if (resultBD == null)
            {
                return NotFound();
            }

            resultBD.IsPrize = result.IsPrize;
            resultBD.Number = result.Number;

            _context.Results.Update(resultBD);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _context.Results.FirstOrDefault(t => t.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Results.Remove(result);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}