using DotNetApiWithSQLite.Controllers;
using DotNetApiWithSQLite.Model;

namespace DotNetApiWithSQLite.Services
{
    public class BlogService : IBlogService
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogService _blogService;

        public BlogService(ILogger<BlogController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }


        public Task Create(BlogCreateRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogDataModel>> GetAll()
        {
            var model = await _blogService.GetAll();
            return model;
        }

        public Task<BlogDataModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, BlogUpdateRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
