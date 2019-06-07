using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotLibrary.Models.Exception;

namespace ToyRobotLibrary.Models.Commands
{
    public class RightCommand : ICommand
    {
        public bool IsAvailableAsFirst => false;

        public void Parse(string commandString)
        {
            var firstStepSplit = commandString.Split(' ');
            if (firstStepSplit.Length != 1 || (firstStepSplit.Length == 1 && firstStepSplit[0] != "RIGHT")) throw new ParsingStringCommandException("Not valid command inputed");
        }

        public string Exec(ref ToyRobot toyRobot, TableTop tableTop)
        {
            if (toyRobot.Facing == null) throw new InvalidFacingException("The first command should be 'PLACE X,Y,F'");

            if (toyRobot.Facing == FacingEnum.WEST) toyRobot.Facing = FacingEnum.NORTH;
            else toyRobot.Facing++;

            return null;
        }
    }
}
