namespace BackendTestAPI.Models.Entities
{
    public class Feedback
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Contactnumber { get; set; }
        public string Email { get; set; }
        public DateTime ReceivedDate { get; set; }

    }
}
