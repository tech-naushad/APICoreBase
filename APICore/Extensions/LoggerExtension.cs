using Microsoft.AspNetCore.Builder;
using Serilog;


namespace APICore.Extensions
{
    public static class LoggerExtension
    {
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, services, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
            );
            //Log.Logger = new LoggerConfiguration()
            //    // .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //     // .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            //    .ReadFrom.Configuration(builder.Configuration)
            //    //.Enrich.FromLogContext()                
            //    .CreateLogger();

            //builder.Host.UseSerilog();
            return builder;
        }
    }
}

