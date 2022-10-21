using marketplace.Data;
using marketplace.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MarketplaceDbContext>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<IAdsRepository, AdsRepository>();
builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();
