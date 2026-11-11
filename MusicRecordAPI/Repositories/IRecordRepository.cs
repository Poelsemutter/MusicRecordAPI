using MusicRecordAPI.Models;
namespace MusicRecordAPI.Repositories

{
    public interface IRecordRepository
    {
        IEnumerable<Record> GetAllRecords();
        Record GetRecordById(int id);
        Record AddRecord(Record record);
        Record UpdateRecord(Record record);
        Record DeleteRecord(int id);
    }
}
