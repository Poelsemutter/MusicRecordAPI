using MusicRecordAPI.Models;
namespace MusicRecordAPI.Repositories
{
    public class RecordRepository : IRepository<Record>
    {
        private readonly List<Record> _records = new List<Record>();
        private int _nextId;
        public RecordRepository(List<Record> records)
        {
            _records = records;
            _nextId = 1;
        }
        public IEnumerable<Record> GetAllRecords(string? title = null, string? artist = null)
        {
            var recordCopy = new List<Record>(_records);
            if (title != null)
            {
                recordCopy = recordCopy.Where(r => r.Title.Contains(title)).ToList();
            }
            if (artist != null)
            {
                recordCopy = recordCopy.Where(r => r.Artist.Contains(artist)).ToList();
            }
            return recordCopy;
        }

        public Record? GetRecordById(int id)
        {
            if (id != null)
            {
               return _records.FirstOrDefault(r => r.Id == id);
            }
            else
                return null;
        }
        public Record? AddRecord(Record record)
        {
            _records.Add(record);
            record.Id = _nextId++;
            return record;
        }
        public Record? UpdateRecord(Record record)
        {
            var existingRecord = GetRecordById(record.Id);
            if (existingRecord != null)
            {
                existingRecord.Title = record.Title;
                existingRecord.Artist = record.Artist;
                existingRecord.Duration = record.Duration;
                existingRecord.PublicationYear = record.PublicationYear;
                return existingRecord;
            }
            return null;
        }
        public Record? DeleteRecord(int id)
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
