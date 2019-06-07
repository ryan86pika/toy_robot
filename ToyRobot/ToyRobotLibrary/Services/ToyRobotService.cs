using System;
using ToyRobotLibrary.Models;

namespace ToyRobotLibrary.Services
{
    public class ToyRobotService
    {
        private TableTop _tableTop;
        private ToyRobot _toyRobot;

        public ToyRobotService()
        {
            _tableTop = new TableTop();
            _toyRobot = new ToyRobot();
        }

        public ToyRobotService(TableTop tableTop)
        {
            _tableTop = tableTop;
            _toyRobot = new ToyRobot();
        }

        public ToyRobotService(int width, int height)
            : this(new TableTop(width, height)) { }

        public void SetWidth(int width)
        {
            _tableTop.Width = width;
        }

        public void SetHeight(int height)
        {
            _tableTop.Height = height;
        }

        public string SendCommand(string command)
        {
            ICommand parsedCommand = CommandsService.Parse(command);
            return parsedCommand.Exec(ref _toyRobot, _tableTop);
        }
    }
}
