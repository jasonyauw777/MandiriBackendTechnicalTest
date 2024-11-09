using BookMicroserviceWebAPI.Model;
using BookMicroserviceWebAPI.Repository;

namespace BookMicroserviceWebAPI.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        void AddBook(string Title, string Author);
        void UpdateBook(int id, string Title, string Author);
        void DeleteBook(int id);

    }

    public class BookService : IBookService
    {
        private readonly IBookRepository repository;

        public BookService(IBookRepository bookRepository)
        {
            repository = bookRepository;
        }

        public List<Book> GetBooks() 
        {
            var res = repository.GetBooks();
            return res;
        }

        public void AddBook(string Title, string Author)
        {
            repository.AddBook(Title, Author);
        }
        public void UpdateBook(int id, string Title, string Author) 
        {
            repository.UpdateBook(id, Title, Author);
        }
        public void DeleteBook(int id)
        {
            repository.DeleteBook(id);
        }
    }
}
