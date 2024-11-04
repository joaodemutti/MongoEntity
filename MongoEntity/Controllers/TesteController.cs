using Microsoft.AspNetCore.Mvc;

namespace MongoEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TesteController> _logger;
        private readonly MongoContext _md;

        public TesteController(ILogger<TesteController> logger, MongoContext md)
        {
            _logger = logger;
            _md = md;
        }

        [HttpGet]
        public IEnumerable<Teste> Get()
        {
            return _md.Testes.ToList();
        }

        [HttpPut]
        public void Put(string teste)
        {
            _md.Testes.Add(new Teste() { Name = teste,Id = new Guid()});
            _md.SaveChanges();
        }

        [HttpPut("Items")]
        public void PutItems(Guid teste, List<string> items)
        {
            foreach (var item in items)
                 _md.TesteItems.AddRange(new TesteItem() { Name=item,Id=new Guid(),TesteId=teste,CreatedAt=DateTime.UtcNow});
            _md.SaveChanges();
        }
    }
}
