using BookstoreApp.Data;

namespace BookstoreApp.Client
{
    class StartUp
    {
        static void Main()
        {
            var db = new BookstoreContext();
        }
    }
}
