using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotLibrary.Models.Exception
{
    public class ParsingStringCommandException : System.Exception
    {
        public ParsingStringCommandException() : base()
        {
        }

        public ParsingStringCommandException(string message) : base(message)
        {
        }
    }
}
