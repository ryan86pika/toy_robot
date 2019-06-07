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

        public override string ToString() => string.Format("TableTop ( width : {0}, height : {1} )", _width, _height);
    }
}
