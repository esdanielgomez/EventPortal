using EventPortal.BL.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventPortal.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConsole();
                })
                .Build();
    }

    public class CalendarSpeakers
    {
        public int NumberOfDay { get; set; }
        public DateTime Date { get; set; }
        public List<SessionModel> Sessions { get; set; }
    }
}
