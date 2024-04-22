using DotNetApiWithSQLite.Controllers;
using DotNetApiWithSQLite.DbServices;
using DotNetApiWithSQLite.Model;
using DotNetApiWithSQLite.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

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

        public async Task<int> Create(BlogModel requestModel)
        {
            var res = await _sQLiteDbContextService.ExecuteAsync(SQLiteDbQuery.Insert, requestModel);
            return res;
        }

        public async Task<int> CreateBlogTable()
        {
            int res = await _sQLiteDbContextService.ExecuteAsync(SQLiteDbQuery.CreateBlogTable);
            return res;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogModel>> GetAll()
        {
            var model = _sQLiteDbContextService.Query<BlogModel>(SQLiteDbQuery.GetAll);
            return model;
        }

        public Task<BlogDataModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(string id, BlogModel updateReqModel)
        {
            updateReqModel.BlogId = id;
            int res = await _sQLiteDbContextService.ExecuteAsync(SQLiteDbQuery.Update, updateReqModel);
            return res;
        }
    }
}
