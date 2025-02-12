using Microsoft.AspNetCore.Builder;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;


namespace APICoreBase.Extensions
{
    public static class LoggerExtension
    {
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                  .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Host.UseSerilog();
            return builder;
        }
    }
}
 
