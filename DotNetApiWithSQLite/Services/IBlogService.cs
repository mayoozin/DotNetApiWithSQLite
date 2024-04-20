using DotNetApiWithSQLite.Model;

namespace DotNetApiWithSQLite.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDataModel>> GetAll();
        Task<BlogDataModel> GetById(int id);
        Task Create(BlogCreateRequestModel model);
        Task Update(int id, BlogUpdateRequestModel model);
        Task Delete(int id);
    }
}
