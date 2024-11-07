using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
            return _md.Testes.JoinItems(_md).ToList();
        }

        [HttpGet("Items")]
        public IEnumerable<TesteItem> Items()
        {
            return _md.TesteItems.JoinTeste(_md).ToList();
        }

        [HttpPost]
        public void Add(string teste)
        {
            _md.Testes.Add(new Teste() { Name = teste,Id = Guid.NewGuid()});
            _md.SaveChanges();
        }

        [HttpPost("{Id}")]
        public void AddtItems([FromRoute] Guid Id, List<string> items)
        {
            foreach (var item in items)
                 _md.TesteItems.AddRange(new TesteItem() { Name=item,Id=Guid.NewGuid(),TesteId=Id,CreatedAt=DateTime.UtcNow});
            _md.SaveChanges();
        }

    }
}
