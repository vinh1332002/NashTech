namespace assignment1.DTOs
{
    public class AddStudentResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { set; get; }
        public string? City { set; get; }
        public string? State { set; get; }
    }
}