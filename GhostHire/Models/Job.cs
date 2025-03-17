namespace GhostHire.Models
{
    public class Job
    {
        public int jobID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int jobType { get; set; }
        public int budget { get; set; }
        public string deadline { get; set; }
    }
}
