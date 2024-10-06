using Core.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IMongoClient>(sp => { var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value; return new MongoClient(settings.ConnectionString); });
builder.Services.AddScoped(sp => { var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value; var client = sp.GetRequiredService<IMongoClient>(); return client.GetDatabase(settings.DatabaseName); });


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure cors
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowLocal",
       builder =>
       {
           builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
       });
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

app.UseCors("AllowLocal");

app.Run();
