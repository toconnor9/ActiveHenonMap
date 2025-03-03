using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Man2
{
    public class MyLine
    {
        #region Properties

        public double Start_X { get; set; }
        public double Start_Y { get; set; }
        public double End_X { get; set; }
        public double End_Y { get; set; }
        public Color LineColor { get; set; }
        public int LineWidth { get; set; }
        public MyPoint Start { get { return new MyPoint(Start_X, Start_Y); } }
        public MyPoint End { get { return new MyPoint(End_X, End_Y); } }

        #endregion


        #region Constructors

        public MyLine(double start_X, double start_Y, double end_X, double end_Y, Color lineColor, int lineWidth)
        {
            Start_X = start_X;
            Start_Y = start_Y;
            End_X = end_X;
            End_Y = end_Y;
            LineColor = lineColor;
            LineWidth = lineWidth;
        }

        public MyLine(MyPoint start, MyPoint end, Color lineColor, int lineWidth) : this(start.X, start.Y, end.X, end.Y, lineColor, lineWidth) { }

        public MyLine(MyPoint start, MyPoint end) : this(start.X, start.Y, end.X, end.Y, Color.Black, 0) { }

        public MyLine() : this(0, 0, 0, 0, Color.Black, 0) { }

        #endregion


        #region Methods

        public override string ToString()
        {
            string fmt = "#,##0.#";
            return "(" + Start_X.ToString(fmt) + ", " + Start_Y.ToString(fmt) + ") (" + End_X.ToString(fmt) + ", " + End_Y.ToString(fmt) + ")";
        }

        #endregion
    }

    public class MyLineList
    {

        #region properties

        public List<MyLine> Lines { get; set; }

        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }

        #endregion


        #region Constructor

        public MyLineList()
        {
            Lines = new List<MyLine>();
        }

        #endregion


        #region Public Methods

        public void Add(MyLine line)
        {
            Lines.Add(line);
        }

        public void Add(double start_X, double start_Y, double end_X, double end_Y)
        {
            Lines.Add(new MyLine(new MyPoint(start_X, start_Y), new MyPoint(end_X, end_Y)));
        }

        public void Add(MyPoint start, MyPoint end)
        {
            Lines.Add(new MyLine(start, end));
        }

        public void Clear()
        {
            Lines.Clear();
        }

        public int Count()
        {
            return Lines.Count;
        }

        public MyLineIntList ConvertThisListToScreenCoordinates(int width, int height)
        {
            Utilities.SurfaceWidth = width;
            Utilities.SurfaceHeight = height;
            Utilities.MinX = this.MinX;
            Utilities.MaxX = this.MaxX;
            Utilities.MinY = this.MinY;
            Utilities.MaxY = this.MaxY;
            Utilities.SetRatios();

            MyLineIntList newLines = new MyLineIntList();

            foreach (MyLine ln in this.Lines)
            {
                MyPointInt startPt = Utilities.ConvertToScreenCoordinates(ln.Start_X, ln.Start_Y, ln.LineColor, ln.LineWidth);
                MyPointInt endPt   = Utilities.ConvertToScreenCoordinates(ln.End_X,   ln.End_Y,   ln.LineColor, ln.LineWidth);
                MyLineInt screenLn = new MyLineInt(startPt, endPt, ln.LineColor, ln.LineWidth);

                newLines.Lines.Add(screenLn);
            }

            return newLines;
        }

        #endregion


        #region Indexer

        public MyLine this[int index]
        {
            get { return Lines[index]; }
            set { Lines[index] = value; }
        }

        #endregion

    }


    public class MyLineInt
    {
        #region Properties

        public int Start_X { get; set; }
        public int Start_Y { get; set; }
        public int End_X { get; set; }
        public int End_Y { get; set; }
        public Color LineColor { get; set; }
        public int LineWidth { get; set; }
        public MyPointInt Start { get { return new MyPointInt(Start_X, Start_Y); } }
        public MyPointInt End { get { return new MyPointInt(End_X, End_Y); } }

        #endregion


        #region Constructors

        public MyLineInt(int start_X, int start_Y, int end_X, int end_Y, Color lineColor, int lineWidth)
        {
            Start_X = start_X;
            Start_Y = start_Y;
            End_X = end_X;
            End_Y = end_Y;
            LineColor = lineColor;
            LineWidth = lineWidth;
        }

        public MyLineInt(MyPointInt start, MyPointInt end, Color lineColor, int lineWidth) : this(start.X, start.Y, end.X, end.Y, lineColor, lineWidth) { }

        public MyLineInt(MyPointInt start, MyPointInt end) : this(start.X, start.Y, end.X, end.Y, Color.Black, 0) { }

        public MyLineInt() : this(0, 0, 0, 0, Color.Black, 0) { }

        #endregion

    }

    public class MyLineIntList
    {

        #region Properties

        public List<MyLineInt> Lines { get; set; }

        #endregion


        #region Constructors

        public MyLineIntList(int startX, int startY, int endX, int endY, Color color, int thickness)
        {
            Lines.Add(new MyLineInt(startX, startY, endX, endY, color, thickness));
        }

        public MyLineIntList(int startX, int startY, int endX, int endY)
        {
            Lines.Add(new MyLineInt(startX, startY, endX, endY, Color.Black, 0));
        }

        public MyLineIntList(MyPointInt start, MyPointInt end, Color color, int thickness)
        {
            Lines.Add(new MyLineInt(start.X, start.Y, end.X, end.Y, color, thickness) );
        }

        public MyLineIntList(MyPointInt start, MyPointInt end)
        {
            Lines.Add(new MyLineInt(start.X, start.Y, end.X, end.Y, Color.Black, 0));
        }

        public MyLineIntList()
        {
            Lines = new List<MyLineInt>();
        }

        #endregion


        #region Public Methods

        public void Add(MyLineInt line)
        {
            Lines.Add(line);
        }

        public void Add(int start_X, int start_Y, int end_X, int end_Y)
        {
            Lines.Add(new MyLineInt(new MyPointInt(start_X, start_Y), new MyPointInt(end_X, end_Y)));
        }

        public void Add(MyPointInt start, MyPointInt end)
        {
            Lines.Add(new MyLineInt(start, end));
        }

        public void Clear()
        {
            Lines.Clear();
        }

        public int Count()
        {
            return Lines.Count;
        }

        // /// <summary>
        // /// Convert all the points to integer data types
        // /// </summary>
        // /// <returns></returns>
        // public MyLineIntList ConvertToIntList()
        // {
        //     MyLineIntList screenPoints = new MyLineIntList();
        //     MyLineInt currLine = null;
        // 
        //     foreach (MyLineInt currLn in this.Lines)
        //     {
        //         currLine = currLn.ToMyLineInt();
        //         screenPoints.Lines.Add(currLine);
        //     }
        // 
        //     return screenPoints;
        // }

        #endregion


        #region Indexer

        public MyLineInt this[int index]
        {
            get { return Lines[index]; }
            set { Lines[index] = value; }
        }

        #endregion

    }
}
