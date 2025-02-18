﻿namespace ToyRobotLibrary.Models
{
    public class ToyRobot
    {
        #region Fields
        private int _x = 0;
        private int _y = 0;
        private FacingEnum? _facing = null;
        #endregion

        #region Properties
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public FacingEnum? Facing { get => _facing; set => _facing = value; }
        #endregion

        public override string ToString() => string.Format("ToyRobot ( x : {0}, y : {1}, facing: {2} )", _x, _y, FacingConvert.ToString(_facing));
    }
}
