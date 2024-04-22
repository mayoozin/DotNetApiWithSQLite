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

        public async Task<int> Delete(BlogModel reqModel)
        {
            int res = await _sQLiteDbContextService.ExecuteAsync(SQLiteDbQuery.Delete, reqModel);
            return res;
        }

        public async Task<IEnumerable<BlogModel>> GetAll()
        {
            var model = await _sQLiteDbContextService.QueryAsync<BlogModel>(SQLiteDbQuery.GetAll);
            return model;
        }

        public Task<BlogDataModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(BlogModel updateReqModel)
        {
            int res = await _sQLiteDbContextService.ExecuteAsync(SQLiteDbQuery.Update, updateReqModel);
            return res;
        }
    }
}
