using DotNetApiWithSQLite.Controllers;
using DotNetApiWithSQLite.DbServices;
using DotNetApiWithSQLite.Model;
using DotNetApiWithSQLite.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApiWithSQLite.Services
{
    public class BlogService
    {
        private readonly ILogger<BlogController> _logger;
        private readonly SQLiteDbContextService _sQLiteDbContextService;

        public BlogService(ILogger<BlogController> logger, SQLiteDbContextService sQLiteDbContextService)
        {
            _logger = logger;
            _sQLiteDbContextService = sQLiteDbContextService;
        }


        public Task Create(BlogCreateRequestModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet("CreateTable")]
        public async Task<int> CreateBlogTable()
        {
            int res = _sQLiteDbContextService.Execute(SQLiteDbQuery.CreateBlogTable);
            return res;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogDataModel>> GetAll()
        {
            var model = _sQLiteDbContextService.Query<BlogDataModel>(SQLiteDbQuery.GetAll);
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
