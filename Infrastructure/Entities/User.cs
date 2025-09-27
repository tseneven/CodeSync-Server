
using API.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Infrastructure.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Hash_Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Salt { get; set; } 
        
        [Required]
        [MaxLength(100)]
        public string Readme { get; set; }

        public ICollection<Boards> Boards { get; set; }
        public ICollection<Likes> Likes { get; set; }

    }
}
