using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace arnold
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            // Get configuration parameters from .json and / or command line.
            IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", true, true)
                   .AddCommandLine(args)
                   .Build();

            // enable logging.
            ILogger log = LoggerFactory.Create(builder =>
            {
                builder.AddSimpleConsole( opts => {
                    opts.SingleLine = true;                                      
                });

            }).CreateLogger("Arnold");

            
            log.LogInformation(string.Format("Arnold. version: {0}", Assembly.GetEntryAssembly().GetName().Version.ToString()));

            // stop close
            Console.ReadKey();
        }
    }
}
