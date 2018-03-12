using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public int BookID { get; set; }
    }
}
