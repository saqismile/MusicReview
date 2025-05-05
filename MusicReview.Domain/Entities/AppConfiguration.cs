using Microsoft.Extensions.Configuration;
using MusicReview.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicReview.Domain.Entities
{
    public class AppConfiguration : IAppConfiguration
    {
        public string SmdbToken { get; }
        public string SmdbUrl { get; }
        public AppConfiguration(IConfiguration config)
        {
            SmdbUrl = config["SMDbUrl"] ?? throw new InvalidOperationException("Missing SMDbUrl in configuration.");
            SmdbToken = config["SMDbToken"] ?? throw new InvalidOperationException("Missing SMDbToken in configuration.");
        }
    }
}
