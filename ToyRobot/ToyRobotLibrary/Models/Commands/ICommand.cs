namespace ToyRobotLibrary.Models
{
    public interface ICommand
    {
        bool IsAvailableAsFirst { get; }

        void Parse(string commandString);
        //string Exec(ref int x, ref int y, ref FacingEnum facing);
        string Exec(ref ToyRobot toyRobot, TableTop tableTop);
    }
}