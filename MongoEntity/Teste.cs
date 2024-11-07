using MongoDB.Bson.Serialization.Attributes;

namespace MongoEntity
{
    public class Teste
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [BsonIgnore]
        public virtual IEnumerable<TesteItem> Items { get; set; }
        public virtual Teste Join(IEnumerable<TesteItem> items) 
        { 
            this.Items = items;
            return this;
        }
    }
}
