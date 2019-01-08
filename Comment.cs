namespace proj2
{
    public class Comment
    {
        public string id { get; set; }
        public string parent_id { get; set; }
        public string link_id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string body { get; set; }
        public string subreddit_id { get; set; }
        public string subreddit { get; set; }
        public int score { get; set; }
        public string created_utc { get; set; }
    }
}
