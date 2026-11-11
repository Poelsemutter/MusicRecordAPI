using Microsoft.AspNetCore.Mvc;
using MusicRecordAPI.Repositories;
using MusicRecordAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace MusicRecordAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class MusicRecordController : ControllerBase
    {
        private readonly IRecordRepository _repository;

        public MusicRecordController(IRecordRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Record>> GetAllRecords()
        {
            var records = _repository.GetAllRecords();
            return Ok(records);
        }

        [HttpGet("{id}")]
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
        public ActionResult<Record> UpdateRecord(Record record)
        {
            var updatedRecord = _repository.UpdateRecord(record);
            if (updatedRecord == null)
            {
                return NotFound();
            }
            return Ok(updatedRecord);
        }
        [HttpDelete("{id}")]
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
