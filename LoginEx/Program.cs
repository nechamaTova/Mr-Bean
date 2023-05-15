using Business;
using Microsoft.EntityFrameworkCore;
using Repository;
using NLog.Web;
using LoginEx;

//using AutoMapper;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseNLog();

// Add services to the container.

builder.Services.AddTransient<IUserBusiness, UserBusiness>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderBusiness, OrderBusiness>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IPasswordBusiness, PasswordBusiness>();
builder.Services.AddControllers();
builder.Services.AddDbContext<Store214089435Context>(options => options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("school")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseerrorHandlingMiddleware();

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Use(async (context, next) =>
{
    await next(context);
    if (context.Response.StatusCode == 404)
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("./wwwroot/pages/404.html");
    }
});

app.Run();
