
using API.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Infrastructure.Entities
{
    [Table("Likes")]
    public class Likes
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        public int BoardID { get; set; }

        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User user { get; set; }

        [ForeignKey(nameof(BoardID))]
        public Boards Boards { get; set; }
    }
}
