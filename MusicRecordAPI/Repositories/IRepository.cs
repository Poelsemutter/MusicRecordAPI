using MusicRecordAPI.Models;

namespace MusicRecordAPI.Repositories

{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllRecords(string? title = null, string? artist = null);
        T? GetRecordById(int id);
        T? AddRecord(T record);
        T? UpdateRecord(T record);
        T? DeleteRecord(int id);
    }
}
