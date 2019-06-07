using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using ToyRobotLibrary.Services;

namespace ToyRobotApp
{
    public class ToyRobotConsole
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ToyRobotConsole));

        public static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            try
            {
                log.Info("INIT - TOY ROBOT");

                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();

                ToyRobotService _toyRobot = new ToyRobotService();

                log.Info("SETUP - TOY ROBOT");

                int width = int.Parse(configuration["width"]);
                int height = int.Parse(configuration["height"]);

                _toyRobot.SetWidth(width);
                _toyRobot.SetHeight(height);

                log.Info("START - TOY ROBOT");

                while (1 == 1)
                {
                    try
                    {
                        var output = _toyRobot.SendCommand(Console.ReadLine());
                        if (output != null) Console.WriteLine(output);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
