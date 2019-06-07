using System;
using System.Linq;
using ToyRobotLibrary.Models;
using ToyRobotLibrary.Models.Commands;
using ToyRobotLibrary.Models.Exception;

namespace ToyRobotLibrary.Services
{
    public class CommandsService
    {
        public static ICommand Parse(string commandString)
        {
            ICommand result = null;
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