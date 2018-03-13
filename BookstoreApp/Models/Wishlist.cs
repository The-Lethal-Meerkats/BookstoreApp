﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual int UserID { get; set; }

        [Required]
        public int BookID { get; set; }
    }
}
