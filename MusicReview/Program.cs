using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicReview.Application.Interfaces;
using MusicReview.Application.Services;
using MusicReview.Console;
using MusicReview.Domain.Interfaces;


var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        services.AddServices(context.Configuration);
    });

using var host = builder.Build();
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

var logger = services.GetRequiredService<IAppLogger>();
Console.WriteLine("===================================Music Review=======================================");
Console.WriteLine("Enter a song genre:");
var genre = Console.ReadLine()?.Trim().ToLower();
try
{
    var songService = services.GetRequiredService<ISongService>();
    var songs = await songService.GetSongsByGenreAsync(genre);

    if (!songs.Any())
    {
        Console.WriteLine("No songs found for the given genre.");
        logger.LogInfo($"No songs found for genre: {genre}");
        return;
    }

    Console.WriteLine($"\nSongs in genre '{genre}':");
    foreach (var song in songs)
    {
        Console.WriteLine($"- {song.Name} by {song.ArtistName}");
    }

    var fileName = $"Songs_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
    File.WriteAllLines(fileName, songs.Select(s => $"{s.Name} - {s.ArtistName}"));
    Console.WriteLine($"\nSaved to bin/file: {fileName}");
    logger.LogInfo($"Saved {songs.Count} songs to {fileName}");
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred. Check the logs.");
    logger.LogError(ex.ToString());
}
