using Microsoft.EntityFrameworkCore;
using MusicRecordAPI.Models;

namespace MusicRecordAPI.Data
{
    public class MusicRecordDbContext : DbContext
    {
        public MusicRecordDbContext(DbContextOptions<MusicRecordDbContext> options) : base(options)
        {
        }
        public DbSet<Record> Records { get; set; }
    }
}
