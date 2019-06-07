using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotLibrary.Models
{
    public class TableTop
    {
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public TableTop()
        {
            _width = 0;
            _height = 0;
        }

        public TableTop(int width, int height)
        {
            _width = width;
            _height = height;
        }        
    }
}
