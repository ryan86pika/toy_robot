using ToyRobotLibrary.Services;
using Xunit;

namespace ToyRobotTest
{
    public class ToyRobotUnitTest
    {
        private ToyRobotService _toyRobot;

        public ToyRobotUnitTest()
        {
            _toyRobot = new ToyRobotService();
            _toyRobot.SetWidth(5);
            _toyRobot.SetHeight(5);
        }

        [Fact]
        public void Test1()
        {
            var output = _toyRobot.SendCommand("PLACE 0,0,NORTH");
            Assert.Null(output);
            output = _toyRobot.SendCommand("MOVE");
            Assert.Null(output);
            output = _toyRobot.SendCommand("REPORT");
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Equal("0,1,NORTH", output);
        }

        [Fact]
        public void Test2()
        {
            var output = _toyRobot.SendCommand("PLACE 0,0,NORTH");
            Assert.Null(output);
            output = _toyRobot.SendCommand("LEFT");
            Assert.Null(output);
            output = _toyRobot.SendCommand("REPORT");
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Equal("0,0,WEST", output);
        }

        [Fact]
        public void Test3()
        {
            var output = _toyRobot.SendCommand("PLACE 1,2,EAST");
            Assert.Null(output);
            output = _toyRobot.SendCommand("MOVE");
            Assert.Null(output);
            output = _toyRobot.SendCommand("MOVE");
            Assert.Null(output);
            output = _toyRobot.SendCommand("LEFT");
            Assert.Null(output);
            output = _toyRobot.SendCommand("MOVE");
            Assert.Null(output);
            output = _toyRobot.SendCommand("REPORT");
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Equal("3,3,NORTH", output);
        }
    }
}
