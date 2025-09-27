namespace API.Application.DTO
{
    public class Likes
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public int UserId { get; set; }
        public int BoardId { get; set; }
    }
}
