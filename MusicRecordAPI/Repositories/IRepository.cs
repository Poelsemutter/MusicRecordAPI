using MusicRecordAPI.Models;

namespace MusicRecordAPI.Repositories

{
    public interface IRepository<T>
    {
        IEnumerable<Record> GetAllRecords(string? title = null, string? artist = null, int? publicationYear = null);
        T? GetRecordById(int id);
        T? AddRecord(T record);
        T? UpdateRecord(T record);
        T? DeleteRecord(int id);
    }
}
