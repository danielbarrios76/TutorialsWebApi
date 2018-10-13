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
    public class StudentsClassRoomsController : ControllerBase
    {
        private readonly TutorialsDBContext _context;

        public StudentsClassRoomsController(TutorialsDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentsClassRooms
        [HttpGet]
        public IEnumerable<StudentsClassRoomDTO> GetStudentsClassRoom()
        {
            return (Mapper.Map<IEnumerable<StudentsClassRoomDTO>>(_context.StudentsClassRoom));
        }

        // GET: api/StudentsClassRooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentsClassRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentsClassRoom = await _context.StudentsClassRoom.SingleOrDefaultAsync(scr => scr.Id == id);

            if (studentsClassRoom == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<StudentsClassRoomDTO>(studentsClassRoom));
        }

        // PUT: api/StudentsClassRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsClassRoom([FromRoute] int id, [FromBody] StudentsClassRoomDTO studentsClassRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentsClassRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(Mapper.Map<StudentsClassRoom>(studentsClassRoom)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsClassRoomExists(id))
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

        // POST: api/StudentsClassRooms
        [HttpPost]
        public async Task<IActionResult> PostStudentsClassRoom([FromBody] StudentsClassRoomDTO studentsClassRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentsClassRoom.Add(Mapper.Map<StudentsClassRoom>(studentsClassRoom));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsClassRoom", new { id = studentsClassRoom.Id }, studentsClassRoom);
        }

        // DELETE: api/StudentsClassRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsClassRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentsClassRoom = await _context.StudentsClassRoom.SingleOrDefaultAsync(scr => scr.Id == id);
            if (studentsClassRoom == null)
            {
                return NotFound();
            }

            _context.StudentsClassRoom.Remove(studentsClassRoom);
            await _context.SaveChangesAsync();

            return Ok(Mapper.Map<StudentsClassRoomDTO>(studentsClassRoom));
        }

        private bool StudentsClassRoomExists(int id)
        {
            return _context.StudentsClassRoom.Any(e => e.Id == id);
        }
    }
}