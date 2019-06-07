using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;
using ToyRobotLibrary.Services;

namespace ToyRobotApp
{
    public class ToyRobotConsole
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var configuration = builder.Build();

                ToyRobotService _toyRobot = new ToyRobotService();

                int width = int.Parse(configuration["width"]);
                int height = int.Parse(configuration["height"]);

                _toyRobot.SetWidth(width);
                _toyRobot.SetHeight(height);

                while (1 == 1)
                {
                    try
                    {
                        var output = _toyRobot.SendCommand(Console.ReadLine());
                        if (output != null) Console.WriteLine(output);
                    } catch (Exception ex) { }
                }

            } catch (Exception ex) { }
        }
    }
}
