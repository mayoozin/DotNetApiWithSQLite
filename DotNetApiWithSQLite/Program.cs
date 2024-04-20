using DotNetApiWithSQLite.Controllers;
using DotNetApiWithSQLite.DbServices;
using DotNetApiWithSQLite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IBlogService, BlogService>();
builder.Services.AddScoped<BlogService>();

builder.Services.AddScoped(n =>
{
    string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sqlite");
    Directory.CreateDirectory(folderPath);
    //string filePath = Path.Combine(folderPath, builder.Configuration.GetSection("DbFileName").Value!);
    //string connectionString = $"Data Source={filePath};Version=3;";
    string connectionString = "Data Source=Blog.db;Version=3;";
    return new SQLiteDbContextService(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
