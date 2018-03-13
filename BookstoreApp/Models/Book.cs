﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public int AuthorID { get; set; }

        [Required]
        public int CategoryID { get; set; }
        
    }
}
