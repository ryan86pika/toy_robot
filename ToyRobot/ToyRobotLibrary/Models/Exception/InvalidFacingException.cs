﻿using System;

namespace ToyRobotLibrary.Models.Exception
{
    public class InvalidFacingException : System.Exception
    {
        public InvalidFacingException() : base()
        {
        }

        public InvalidFacingException(string message) : base(message)
        {
        }
    }
}
