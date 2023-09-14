using api;
using api.Model;
using infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IArticleService, ArticleService>(); //--need to have this here
builder.Services.AddTransient<IArticleRepository, ArticleRepository>(); //--need to have this here

builder.Services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseCors(options =>

{

    options.SetIsOriginAllowed(origin => true)

        .AllowAnyMethod()

        .AllowAnyHeader()

        .AllowCredentials();

});
app.MapControllers();

app.Run();
