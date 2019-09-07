using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public string Color { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
