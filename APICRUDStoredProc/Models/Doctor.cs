namespace APICRUDStoredProc.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Registration { get; set; }
        public string? DateofIssue { get; set; }
        public string? DateofValid { get; set; }
    }
}
