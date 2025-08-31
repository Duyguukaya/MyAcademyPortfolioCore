namespace Portfolio.Web.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string StartYear { get; set; }
        public string? EndYear { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
