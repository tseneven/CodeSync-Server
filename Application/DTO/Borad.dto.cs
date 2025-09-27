namespace API.Application.DTO
{
    public class BoardDTO
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? text { get; set; }
        public bool? haveImage { get; set; }
        public DateTime? date { get; set; }
        public int? repost { get; set; }
    }
}
