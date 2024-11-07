namespace MongoEntity
{
    public static class LinqExtensions
    {
        public static IEnumerable<Teste> JoinItems(this IEnumerable<Teste> testes, MongoContext md)
            => testes
                .AsEnumerable()
                .GroupJoin(
                    md.TesteItems, 
                    x => x.Id, 
                    x => x.TesteId, 
                    (teste, items) => teste.Join(items)
                );

        public static IEnumerable<TesteItem> JoinTeste(this IEnumerable<TesteItem> items, MongoContext md)
            => items
            .AsEnumerable()
            .Join(
                md.Testes,
                x => x.TesteId,
                x => x.Id,
                (item, teste) => item.Join(teste)
            );
    }
}
