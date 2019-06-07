using ToyRobotLibrary.Exception;
using ToyRobotLibrary.Models;

namespace ToyRobotLibrary.Services.Commands
{
    public class MoveCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MoveCommand));

        public bool IsAvailableAsFirst => false;

        public void Parse(string commandString)
        {
            var firstStepSplit = commandString.Split(' ');
            if (firstStepSplit.Length != 1 || (firstStepSplit.Length == 1 && firstStepSplit[0] != "MOVE")) throw new ParsingStringCommandException("Not valid command inputed");
        }

        public string Exec(ref ToyRobot toyRobot, TableTop tableTop)
        {
            log.Info(string.Format("Exec: {0} - {1}", toyRobot, tableTop));

            if (toyRobot.Facing == null) throw new InvalidFacingException("The first command should be 'PLACE X,Y,F'");

            else if (toyRobot.Facing.Equals(FacingEnum.NORTH) && (toyRobot.Y + 1) <= tableTop.Height) toyRobot.Y++;
            else if (toyRobot.Facing.Equals(FacingEnum.EAST) && (toyRobot.X + 1) <= tableTop.Width) toyRobot.X++;
            else if (toyRobot.Facing.Equals(FacingEnum.SOUTH) && (toyRobot.Y - 1) >= 0) toyRobot.Y--;
            else if (toyRobot.Facing.Equals(FacingEnum.WEST) && (toyRobot.X - 1) >= 0) toyRobot.X--;
            else throw new InvalidCommandException("The toy robot can not falling from the table");

            log.Info(string.Format("Exec - Result: {0}", toyRobot));

            return null;
        }
    }
}
