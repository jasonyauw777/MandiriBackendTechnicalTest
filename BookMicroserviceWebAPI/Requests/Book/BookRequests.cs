namespace BookMicroserviceWebAPI.Requests.Book
{
    public class BookRequests
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class UpdateBookRequests
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class DeleteBookRequest
    {
        public int Id { get; set; }
    }
}
