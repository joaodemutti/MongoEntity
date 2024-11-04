namespace MongoEntity
{
    public class Teste
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TesteItem> Items { get; set; }
    }
}
