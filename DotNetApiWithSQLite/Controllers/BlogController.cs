using DotNetApiWithSQLite.DbServices;
using DotNetApiWithSQLite.Model;
using DotNetApiWithSQLite.Queries;
using DotNetApiWithSQLite.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetApiWithSQLite.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly BlogService _blogService;

        public BlogController(ILogger<BlogController> logger, BlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        [HttpGet("CreateTable")]
        public async Task<IActionResult> CreateBlogTable()
        {
            return Ok(await _blogService.CreateBlogTable());
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(BlogModel requestModel)
        {
            return Ok(await _blogService.Create(requestModel));
        }

        // GET: api/<BlogController>
        [HttpGet]
        public async Task<IEnumerable<BlogDataModel>> Get()
        {

            var model = await _blogService.GetAll();
            return model;
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BlogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
