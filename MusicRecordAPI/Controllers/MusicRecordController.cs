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
        private readonly IRecordRepository<Record> _repository;

        public MusicRecordController(IRecordRepository<Record> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Record>> GetAllRecords()
        {
            var records = _repository.GetAllRecords();
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Record> UpdateRecord(Record record)
        {
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
