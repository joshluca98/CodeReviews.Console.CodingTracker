namespace CodingTracker.joshluca98.Models
{
    internal class CodingSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Duration { get; set; }
    }
}