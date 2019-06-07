using System;

namespace ToyRobotLibrary.Models.Exception
{
    public class InvalidCommandException : System.Exception
    {
        public InvalidCommandException() : base()
        {
        }

        public InvalidCommandException(string message) : base(message)
        {
        }
    }
}
