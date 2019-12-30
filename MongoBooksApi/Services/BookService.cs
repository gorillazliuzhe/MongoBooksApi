using MongoBooksApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MongoBooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            
            var database = client.GetDatabase(settings.DatabaseName); // Mongo 数据库
            
            // GetCollection<TDocument>(collection) 
            // TDocument 表示存储在集合中的 CLR 对象类型
            // collection 表示集合名称
            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        // 返回集合中与提供的搜索条件匹配的所有文档
        public List<Book> Get() => _books.Find(book => true).ToList();

        public Book Get(string id) => _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        // 插入提供的对象作为集合中的新文档
        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        // 将与提供的搜索条件匹配的单个文档替换为提供的对象
        public void Update(string id, Book bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);

        // 删除与提供的搜索条件匹配的单个文档
        public void Remove(Book bookIn) => _books.DeleteOne(book => book.Id == bookIn.Id);
        // 删除与提供的搜索条件匹配的单个文档
        public void Remove(string id) => _books.DeleteOne(book => book.Id == id);
    }
}
