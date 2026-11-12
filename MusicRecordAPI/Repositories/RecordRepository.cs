using MusicRecordAPI.Models;
namespace MusicRecordAPI.Repositories
{
    public class RecordRepository : IRecordRepository<Record>
    {
        private readonly List<Record> _records = new List<Record>();
        private int _nextId;
        public RecordRepository(List<Record> records)
        {
            _records = records;
            _nextId = 1;
        }
        public IEnumerable<Record> GetAllRecords()
        {

            var recordCopy = new List<Record>(_records);
            return recordCopy;
        }

        public Record GetRecordById(int id)
        {

            return _records.FirstOrDefault(r => r.Id == id);
        }
        public Record AddRecord(Record record)
        {
            _records.Add(record);
            record.Id = _nextId++;
            return record;
        }
        public Record UpdateRecord(Record record)
        {
            var existingRecord = GetRecordById(record.Id);
            if (existingRecord != null)
            {
                existingRecord.Title = record.Title;
                existingRecord.Artist = record.Artist;
                existingRecord.Duration = record.Duration;
                existingRecord.PublicationYear = record.PublicationYear;
            }
            return null;
        }
        public Record DeleteRecord(int id)
        {
            var recordToDelete = GetRecordById(id);
            if (recordToDelete != null)
            {
                _records.Remove(recordToDelete);
                return recordToDelete;
            }
            return null;
        }

    }
}
