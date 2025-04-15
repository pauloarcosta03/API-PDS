using API_PDS.Model;
using API_PDS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UtilizadorService>();

// Add services to the container.
builder.Services.AddDbContext<CondoSocialContext>(options =>
{
    options.UseSqlServer("Server=PC-PAULO;Database=CondoSocialDB;Trusted_Connection=True;TrustServerCertificate=True;");
});

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

app.MapControllers();

app.Run();
