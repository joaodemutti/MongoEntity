using MongoDB.Bson.Serialization.Attributes;

namespace MongoEntity
{
    public class TesteItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        [BsonIgnore]
        public virtual Teste Teste { get; set; }
        public Guid TesteId { get; set; }
        public virtual TesteItem Join(Teste teste)
        {
            teste.Items = null;
            this.Teste = teste;
            return this;
        }
    }
}
