using ToyRobotLibrary.Exception;
using ToyRobotLibrary.Models;

namespace ToyRobotLibrary.Services.Commands
{
    public class LeftCommand : ICommand
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LeftCommand));

        public bool IsAvailableAsFirst => false;

        public void Parse(string commandString)
        {
            var firstStepSplit = commandString.Split(' ');
            if (firstStepSplit.Length != 1 || (firstStepSplit.Length == 1 && firstStepSplit[0] != "LEFT")) throw new ParsingStringCommandException("Not valid command inputed");
        }

        public string Exec(ref ToyRobot toyRobot, TableTop tableTop)
        {
            log.Info(string.Format("Exec: {0} - {1}", toyRobot, tableTop));

            if (toyRobot.Facing == null) throw new InvalidFacingException("The first command should be 'PLACE X,Y,F'");

            if (toyRobot.Facing == FacingEnum.NORTH) toyRobot.Facing = FacingEnum.WEST;
            else toyRobot.Facing--;

            log.Info(string.Format("Exec - Result: {0}", toyRobot));

            return null;
        }
    }
}
