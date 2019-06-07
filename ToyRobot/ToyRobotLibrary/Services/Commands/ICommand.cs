using ToyRobotLibrary.Models;

namespace ToyRobotLibrary.Services.Commands
{
    public interface ICommand
    {
        bool IsAvailableAsFirst { get; }

        void Parse(string commandString);
        string Exec(ref ToyRobot toyRobot, TableTop tableTop);
    }
}