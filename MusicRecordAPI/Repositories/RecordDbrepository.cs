using MusicRecordAPI.Data;
using MusicRecordAPI.Models;

namespace MusicRecordAPI.Repositories
{
    public class RecordDbRepository : IRepository<Record>
    {
        private readonly MusicRecordDbContext _context;

        public RecordDbRepository(MusicRecordDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Record> GetAllRecords()
        {
            return _context.Records.ToList();
        }

        public Record? GetRecordById(int id)
        {
            return _context.Records.FirstOrDefault(r => r.Id == id);
        }

        public Record AddRecord(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();
            return record;
        }

        public Record? UpdateRecord(Record record)
        {
            var existingRecord = GetRecordById(record.Id);
            if (existingRecord == null)
            {
                return null;
            }

            existingRecord.Title = record.Title;
            existingRecord.Artist = record.Artist;
            existingRecord.Duration = record.Duration;
            existingRecord.PublicationYear = record.PublicationYear;
            _context.SaveChanges();
            return existingRecord;
        }

        public Record? DeleteRecord(int id)
        {
            var recordToDelete = GetRecordById(id);
            if (recordToDelete == null)
            {
                return null;
            }

            _context.Records.Remove(recordToDelete);
            _context.SaveChanges();
            return recordToDelete;
        }
    }
}