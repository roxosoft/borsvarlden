namespace borsvarlden.Models
{
    public class JobCandidateApply
    {
        public int Id { get; set; }
        public int JobAdvertId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cv { get; set; }

        public JobAdvert JobAdvert { get; set; }
    }
}