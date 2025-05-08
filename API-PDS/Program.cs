using API_PDS.Model;
using API_PDS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UtilizadorService>();
builder.Services.AddScoped<ContactoService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CondominioService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ContactoEmergenciaService>();
builder.Services.AddScoped<IncidenciaService>();
builder.Services.AddScoped<ReuniaoService>();

// Add services to the container.
builder.Services.AddDbContext<CondoSocialContext>(options =>
{
    options.UseSqlServer("Server=PC-PAULO;Database=CondoSocialDB;Trusted_Connection=True;TrustServerCertificate=True;");
});

builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

//para react
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//para react
app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
