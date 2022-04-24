// See https://aka.ms/new-console-template for more information
//setup our DI

using DataLoader;
using DonorApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json")
    .AddEnvironmentVariables()
    .Build();

var serviceCollection = new ServiceCollection()
    .AddLogging(logBuilder =>
    {
        logBuilder.ClearProviders();
        logBuilder.AddConsole();
        logBuilder.AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning);
    })
    .AddTransient<IDataLoader, DataLoader.DataLoader>()
    .AddTransient<IDonorDbContext, DonorDbContext>();


var connectionString = config.GetSection("Database").GetValue<string>("ConnectionString");
serviceCollection.AddDbContext<DonorDbContext>(opt => opt.UseNpgsql(connectionString));

var serviceProvider = serviceCollection.BuildServiceProvider();

var dataLoader = serviceProvider.GetRequiredService<IDataLoader>();
await dataLoader.Load();