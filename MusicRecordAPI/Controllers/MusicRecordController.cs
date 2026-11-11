using Microsoft.AspNetCore.Mvc;
using MusicRecordAPI.Repositories;

namespace MusicRecordAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicRecordController : ControllerBase
    {
        private readonly IRecordRepository _repository;

        public MusicRecordController(IRecordRepository repository)
        {
            _repository = repository;
        }
    }
}
