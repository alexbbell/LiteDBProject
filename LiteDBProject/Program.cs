using LiteDBProject.Data.LiteDB;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();


builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.Converters.Add(new NullableDateTimeConverter());
//});

//Добавление CORS
var configuration = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(options =>
{
    var frontEndURL = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontEndURL).AllowAnyMethod().AllowAnyHeader();
    });

});

var liteDBConnectionString = configuration["LiteDbOptions:LiteDBConnectionString"];
//builder.Services.AddScoped<IDbContext, LiteDbContext>();   
builder.Services.AddScoped<IDbContext, LiteDbContext>();



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
