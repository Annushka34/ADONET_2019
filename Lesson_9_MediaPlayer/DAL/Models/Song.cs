using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string SongName { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public int SingerId { get; set; }
        [ForeignKey("SingerId")]
        public Singer Singer { get; set; }

        public ICollection<UserSong> UserSongs { get; set; }
    }
}
