using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialsWebApi.DTOs;
using TutorialsWebApi.Models;
using AutoMapper;

namespace TutorialsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomsController : ControllerBase
    {
        private readonly TutorialsDBContext _context;

        public ClassRoomsController(TutorialsDBContext context)
        {
            _context = context;
        }

        // GET: api/ClassRooms
        [HttpGet]
        public IEnumerable<ClassRoomDTO> GetClassRoom()
        {
            return Mapper.Map<IEnumerable<ClassRoomDTO>>(_context.ClassRoom.OrderBy(cr => cr.ClassName));
        }

        // GET: api/ClassRooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classRoom = await _context.ClassRoom.SingleOrDefaultAsync(cr => cr.Id == id);

            if (classRoom == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<ClassRoomDTO>(classRoom));
        }

        // PUT: api/ClassRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassRoom([FromRoute] int id, [FromBody] ClassRoomDTO classRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(Mapper.Map<ClassRoom>(classRoom)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClassRooms
        [HttpPost]
        public async Task<IActionResult> PostClassRoom([FromBody] ClassRoomDTO classRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ClassRoom.Add(Mapper.Map<ClassRoom>(classRoom));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassRoom", new { id = classRoom.Id }, classRoom);
        }

        // DELETE: api/ClassRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classRoom = await _context.ClassRoom.SingleOrDefaultAsync(cr => cr.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            _context.ClassRoom.Remove(classRoom);
            await _context.SaveChangesAsync();

            return Ok(Mapper.Map<ClassRoomDTO>(classRoom));
        }

        private bool ClassRoomExists(int id)
        {
            return _context.ClassRoom.Any(e => e.Id == id);
        }
    }
}