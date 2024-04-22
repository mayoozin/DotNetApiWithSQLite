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

        [HttpPost("Update")]
        public async Task<IActionResult> Update(BlogModel requestModel)
        {
            return Ok(await _blogService.Update(requestModel));
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(BlogModel requestModel)
        {
            return Ok(await _blogService.Delete(requestModel));
        }

        // GET: api/<BlogController>
        [HttpGet]
        public async Task<IEnumerable<BlogModel>> Get()
        {
            var model = await _blogService.GetAll();
            return model;
        }
    }
}
