using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace MongoBooksApi.Models
{
    public class Book
    {
        [BsonId] // 指定为文档的主键
        [BsonRepresentation(BsonType.ObjectId)] // 将参数作为类型 string 而非 ObjectId 结构传递。 Mongo 处理从 string 到 ObjectId 的转换
        public string Id { get; set; }

        [BsonElement("Name")] // Name 的属性值表示 MongoDB 集合中的属性名称
        [JsonProperty("Name")]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
