﻿using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "API";
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://localhost/5001")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                //.UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
