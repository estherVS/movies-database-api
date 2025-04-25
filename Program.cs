using Microsoft.EntityFrameworkCore;
using Movies.Api.Data;
using Movies.Api.Interfaces;
using Movies.Api.Repository;
using Movies.Api.Seed;

var builder = WebApplication.CreateBuilder(args);

if (args.Contains("--import-csv"))
{
    var csvPath = args.FirstOrDefault(a => a.EndsWith(".csv"));

    if (csvPath == null) 
    {
        Console.Write("Invalid CSV Path");
        return;
    }

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

    var importer = new CsvImporter();
    await importer.ImportCsvAsync(csvPath, connectionString);
    Console.WriteLine("CSV imported successfully! =)");
    return;
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();