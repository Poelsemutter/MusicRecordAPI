namespace MusicRecordAPI.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Duration { get; set; } // Duration in seconds
        public int PublicationYear { get; set; }



        public Record()
        {
        }

        public Record(string title, string artist, int duration, int publicationYear)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            PublicationYear = publicationYear;
        }

        public override string ToString()
        {
            return $"Record: {Title} by {Artist}, Duration: {Duration} seconds, Published: {PublicationYear}";
        }
    }
}
