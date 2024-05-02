using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Contracts.CountryContract;
using Project.Data;
using Project.MapConfig;
using Project.Repositories;
using Project.Repositories.CountryRepo;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Step 5: Adding DbContext
// arsns - 05/01/2024 23:22:56

builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DCS"));
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Step 1: Adding CORS Policy
// arsns - 05/01/2024 22:57:16

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

// Step 3: Adding Serilog
// arsns - 05/01/2024 23:06:48

builder.Host.UseSerilog(
    (context, loggerConfiguration) => loggerConfiguration
    .WriteTo
    .Console()
    .ReadFrom
    .Configuration(context.Configuration)
);

// Step 6: Adding Automapper
// arsns - 05/02/2024 00:43:40

builder.Services.AddAutoMapper(typeof(MapperConfig));

// Step 7: Add Dependency Injection
// arsns - 05/02/2024 21:51:11

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Step 4: Using Serilog
// arsns - 05/01/2024 23:15:20

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

// Step 2: Using CORS Policy
// arsns - 05/01/2024 22:58:03

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
