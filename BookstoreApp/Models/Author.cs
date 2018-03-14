using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
