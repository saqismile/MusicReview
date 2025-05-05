using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicReview.Application.Interfaces;
using MusicReview.Application.Services;
using MusicReview.Domain.Entities;
using MusicReview.Domain.Interfaces;
using MusicReview.Infrastructure.Logging;
using MusicReview.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicReview.Console
{
    public static class RegisterDI
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IAppConfiguration, AppConfiguration>();            
            services.AddHttpClient();
            services.AddSingleton<IAppLogger,AppLogger>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<ISongService, SongService>();

            return services;
        }

       
    }
}
