namespace MusicRecordAPI.Repositories

{
    public interface IRecordRepository<T>
    {
        IEnumerable<T> GetAllRecords();
        T GetRecordById(int id);
        T AddRecord(T record);
        T UpdateRecord(T record);
        T DeleteRecord(int id);
    }
}
