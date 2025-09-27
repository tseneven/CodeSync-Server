using backend.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Infrastructure.Entities
{
    [Table("Boards")]
    public class Boards
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string username { get; set; }

        [Required]
        [MaxLength(200)]
        public string text { get; set; }

        [Required]
        public bool haveImage { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public int repost { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User user { get; set; }
        public ICollection<Likes> Likes { get; set; }

    }
}
