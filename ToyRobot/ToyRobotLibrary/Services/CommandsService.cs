using System;
using System.Linq;
using ToyRobotLibrary.Exception;
using ToyRobotLibrary.Services.Commands;

namespace ToyRobotLibrary.Services
{
    public class CommandsService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CommandsService));

        public static ICommand Parse(string commandString)
        {
            ICommand result = null;
            log.Info(string.Format("commandString - parse: {0}", commandString));
            var splittedCommand = commandString.Split(' ');
            if (splittedCommand.Contains("PLACE"))
                result = new PlaceCommand();
            else if (splittedCommand.Contains("MOVE"))
                result = new MoveCommand();
            else if (splittedCommand.Contains("LEFT"))
                result = new LeftCommand();
            else if (splittedCommand.Contains("RIGHT"))
                result = new RightCommand();
            else if (splittedCommand.Contains("REPORT"))
                result = new ReportCommand();
            else
                throw new InvalidCommandException("Command not recognized.");

            result.Parse(commandString);

            return result;
        }
    }
}