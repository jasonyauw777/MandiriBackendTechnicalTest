using BookMicroserviceWebAPI.Model;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Data.SqlClient;

namespace BookMicroserviceWebAPI.Repository
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        void AddBook(string Title, string Author);
        void UpdateBook(int id, string Title, string Author);
        void DeleteBook(int id);
    }

    public class BookRepository : IBookRepository
    {
        public static string GetConnectionStrings(string name)
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")[name];
        }

        public List<Book> GetBooks()
        {

            var res = new List<Book>();
            var defaultConnection = GetConnectionStrings("DefaultConnection"); 
            using (SqlConnection connection = new SqlConnection(defaultConnection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Book", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book();
                            book.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            book.Title = reader.GetString(reader.GetOrdinal("Title"));
                            book.Author = reader.GetString(reader.GetOrdinal("Author"));
                            res.Add(book);
                        }
                    }
                }
            }
            return res;
        }

        public void AddBook(string Title, string Author)
        {
            var defaultConnection = GetConnectionStrings("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(defaultConnection))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Book (Title, Author) VALUES (@Title, @Author)", connection))
                {
                    cmd.Parameters.AddWithValue("Title", Title);
                    cmd.Parameters.AddWithValue("Author", Author);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBook(int id, string Title, string Author)
        {
            var defaultConnection = GetConnectionStrings("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(defaultConnection))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Book SET Title = @Title, Author = @Author WHERE Id = @Id", connection))
                {
                    cmd.Parameters.AddWithValue("Title", Title);
                    cmd.Parameters.AddWithValue("Author", Author);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(int id) 
        {
            var defaultConnection = GetConnectionStrings("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(defaultConnection))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Book WHERE Id = @Id", connection))
                {
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
