using E_Ticaret_WebApplication.Data;
using E_Ticaret_WebApplication.Repositories.Concretes;
using E_Ticaret_WebApplication.Repositories.Interfaces;
using E_Ticaret_WebApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<TrendyolContext>(option =>
{
    option.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); 

builder.Services.AddScoped<CategoryService>(); 


builder.Services.AddScoped<IProductRepository, ProductRepository>(); 

builder.Services.AddScoped<ProductService>(); 


builder.Services.AddScoped<IUserRepository, UserRepository>(); 

builder.Services.AddScoped<UserService>(); 

builder.Services.AddScoped<ICartRepository, CartRepository>(); 

builder.Services.AddScoped<CartService>(); 


builder.Services.AddScoped<ICartItemRepository, CartItemRepository>(); 
builder.Services.AddScoped<CartItemService>(); 

var app = builder.Build();


app.UseStaticFiles(); 
app.UseRouting();


app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGet("/", () => Results.Redirect("/index.html"));

app.MapControllers();

app.Run();







