namespace Portfolio.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int ProjectName { get; set; }
        public int Description { get; set; }
        public int ImageUrl { get; set; }
        public int GithubUrl { get; set; }

        //navigation property
       // public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
