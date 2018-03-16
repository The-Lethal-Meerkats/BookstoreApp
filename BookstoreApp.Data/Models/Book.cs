namespace BookstoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Isbn { get; set; }

        public string ImageUrl { get; set; }

        public string BookName { get; set; }


        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }      
        public virtual Category Category { get; set; }

        public int ImageId { get; set; }
        public virtual BookImage BookImage { get; set; }
    }
}
