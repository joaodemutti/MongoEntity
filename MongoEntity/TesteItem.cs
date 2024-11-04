namespace MongoEntity
{
    public class TesteItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Teste Teste { get; set; }
        public Guid TesteId { get; set; }
    }
}
