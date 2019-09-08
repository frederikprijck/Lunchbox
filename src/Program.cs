using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lunchbox.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NpgsqlTypes;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace Lunchbox
{
    public class Program
    {
        public static int Main(string[] args)
        {

            try
            {
                CreateWebHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception exc)
            {
                Log.Fatal(exc, "Host ended unexpectedly");
                return -1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            Log.Logger =
                new LoggerConfiguration()
                    .MinimumLevel.Warning()
                    .WriteTo.Console()
                    .WriteTo.PostgreSQL(SerilogConfig.ConnectionString, SerilogConfig.TableName, SerilogConfig.ColumnWriters,
                                        respectCase: true, restrictedToMinimumLevel: LogEventLevel.Warning)
                    .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine("[Serilog] " + msg));

            return WebHost.CreateDefaultBuilder(args)
                        .UseSerilog()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>();
        }
    }
}
