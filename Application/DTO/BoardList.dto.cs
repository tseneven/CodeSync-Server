namespace API.Application.DTO
{
    public class BoardList
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string text { get; set; }
        public bool haveImage { get; set; }
        public DateTime date { get; set; }
        public List<LikesDTO> likes { get; set; } 
        public int countLikes { get; set; }
        public int repost { get; set; }
    }
}
