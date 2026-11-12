using Microsoft.AspNetCore.Mvc;
using MusicRecordAPI.Repositories;
using MusicRecordAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace MusicRecordAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class MusicRecordController : ControllerBase
    {
        private readonly IRepository<Record> _repository;

        public MusicRecordController(IRepository<Record> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Record>> GetAllRecords([FromQuery] string? title = null, [FromQuery] string? artist = null)
        {
            var records = _repository.GetAllRecords(title, artist);
            return Ok(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> GetRecordById(int id)
        {
            var record = _repository.GetRecordById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Record> AddRecord(Record record)
        {
            var addedRecord = _repository.AddRecord(record);
            return CreatedAtAction(nameof(GetRecordById), new { id = addedRecord.Id }, addedRecord);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> UpdateRecord(int id, Record record)
        {
            record.Id = id;
            var updatedRecord = _repository.UpdateRecord(record);
            if (updatedRecord == null)
            {
                return NotFound();
            }
            return Ok(updatedRecord);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> DeleteRecord(int id)
        {
            var deletedRecord = _repository.DeleteRecord(id);
            if (deletedRecord == null)
            {
                return NotFound();
            }
            return Ok(deletedRecord);
        }
    }
}
