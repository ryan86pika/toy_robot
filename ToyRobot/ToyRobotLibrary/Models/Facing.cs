using System;

namespace ToyRobotLibrary.Models
{
    public enum FacingEnum { NORTH, EAST, SOUTH, WEST }

    public class FacingConvert
    {
        public static string ToString(FacingEnum? facing)
        {
            if (facing == null) return "(null)";
            else if (facing == FacingEnum.NORTH) return "NORTH";
            else if (facing == FacingEnum.EAST) return "EAST";
            else if (facing == FacingEnum.SOUTH) return "SOUTH";
            else return "WEST";
        }
    }
}
