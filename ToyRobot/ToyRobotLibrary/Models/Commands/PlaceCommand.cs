using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotLibrary.Models.Exception;

namespace ToyRobotLibrary.Models.Commands
{
    public class PlaceCommand : ICommand
    {
        #region Fields
        private ToyRobot _parsedPlacement;
        #endregion

        #region Properties
        public bool IsAvailableAsFirst => true;
        #endregion

        public PlaceCommand()
        {
            _parsedPlacement = new ToyRobot();
        }

        public void Parse(string commandString)
        {
            var firstStepSplit = commandString.Split(' ');
            if (firstStepSplit.Length != 2 || (firstStepSplit.Length == 2 && firstStepSplit[0] != "PLACE")) throw new ParsingStringCommandException("Not valid command inputed");

            int x = 0, y = 0;
            var secondStepSplit = firstStepSplit[1].Split(',');
            if (secondStepSplit.Length != 3) throw new ParsingStringCommandException("Not valid command inputed");
            else if (!int.TryParse(secondStepSplit[0], out x) || !int.TryParse(secondStepSplit[1], out y)) throw new ParsingStringCommandException("Not valid command inputed");
            else if (x < 0 || y < 0) throw new ParsingStringCommandException("Not valid command inputed");

            _parsedPlacement.X = x;
            _parsedPlacement.Y = y;

            switch (secondStepSplit[2])
            {
                case "NORTH": _parsedPlacement.Facing = FacingEnum.NORTH; break;
                case "EAST": _parsedPlacement.Facing = FacingEnum.EAST; break;
                case "SOUTH": _parsedPlacement.Facing = FacingEnum.SOUTH; break;
                case "WEST": _parsedPlacement.Facing = FacingEnum.WEST; break;
                default: throw new ParsingStringCommandException("Not valid command inputed");
            }
        }

        public string Exec(ref ToyRobot toyRobot, TableTop tableTop)
        {
            if(_parsedPlacement.X < 0 || _parsedPlacement.X > tableTop.Width) throw new InvalidCommandException("The toy robot can not be placed out from the table");
            else if (_parsedPlacement.Y < 0 || _parsedPlacement.Y > tableTop.Height) throw new InvalidCommandException("The toy robot can not be placed out from the table");

            toyRobot.X = _parsedPlacement.X;
            toyRobot.Y = _parsedPlacement.Y;
            toyRobot.Facing = _parsedPlacement.Facing.Value;

            return null;
        }
    }
}
