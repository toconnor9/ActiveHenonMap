using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;


namespace Man2
{
    public class MyPoint
    {

        #region Properties

        public double X { get; set; }
        public double Y { get; set; }
        public Color ptColor { get; set; }
        public int Diameter { get; set; }

        #endregion


        #region Constructors

        public MyPoint(double x, double y, Color ptColor, int diameter)
        {
            this.X = x;
            this.Y = y;
            this.ptColor = ptColor;
            this.Diameter = diameter;
        }

        public MyPoint(double x, double y) : this(x, y, Color.Black, 1) { }

        public MyPoint() : this(0, 0, Color.Black, 2) {}

        #endregion


        #region Public Methods

        public MyPointInt ToMyPointInt()
        {
            return new MyPointInt((int)this.X, (int)this.Y, this.ptColor, this.Diameter);
        }

        public override string ToString()
        {
            string fmt = "#,##0.###";
            return "(" + X.ToString(fmt) + ", " + Y.ToString(fmt) + ") " + this.ptColor.R.ToString("X2") + this.ptColor.G.ToString("X2") + this.ptColor.B.ToString("X2") + this.ptColor.A.ToString("X2");
        }

        public string ToStringAlt()
        {
            string fmt = "#,0.0000";
            if (this.Diameter == 1) 
                return "(" + X.ToString(fmt) + ", " + Y.ToString(fmt) + ")";
            else
                return "(" + X.ToString(fmt) + ", " + Y.ToString(fmt) + ") ***";
        }

        public string ToStringMin()
        {
            string fmt = "#,##0.###";
            return "(" + X.ToString(fmt) + ", " + Y.ToString(fmt) + ")";
        }

        #endregion

    }

    public class MyPointList
    {
        
        #region Properties
        
        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }
        public List<MyPoint> points { get; set; }

        #endregion


        #region Constructor

        public MyPointList(double minX, double maxX, double minY, double maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
            this.points = new List<MyPoint>();
        }

        public MyPointList()
        {
            this.MinX = 0;
            this.MaxX = 0;
            this.MinY = 0;
            this.MaxY = 0;
            this.points = new List<MyPoint>();
        }

        #endregion


        #region Public Methods

        public void MakeUpData(double minX, double maxX, double minY, double maxY, int numPoints)
        {
            double width = maxX - minX;
            double height = maxY - minY;


            if (width == 0)
                width = 10;
            if (height == 0)
                height = 10;


            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;

            points = new List<MyPoint>();
            
            Random rnd = new Random();
            for (int i = 0; i < numPoints; i++)
            {
                MyPoint pt = new MyPoint();
                pt.X = minX + (rnd.NextDouble() * width);
                pt.Y = minY + (rnd.NextDouble() * height);
                pt.ptColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                points.Add(pt);
            }
        }

        public MyPointIntList ConvertThisListToScreenCoordinates(int width, int height)
        {
            Utilities.SurfaceWidth = width;
            Utilities.SurfaceHeight = height;
            Utilities.MinX = this.MinX;
            Utilities.MaxX = this.MaxX;
            Utilities.MinY = this.MinY;
            Utilities.MaxY = this.MaxY;
            Utilities.SetRatios();

            MyPointIntList newPoints = new MyPointIntList();
            newPoints.MinX = 0;
            newPoints.MaxX = width;
            newPoints.MinY = 0;
            newPoints.MaxY = height;

            foreach (MyPoint pt in this.points)
            {
                MyPointInt screenPt = Utilities.ConvertToScreenCoordinates(pt.X, pt.Y, pt.ptColor, pt.Diameter);

                newPoints.points.Add(screenPt);
            }
            
            return newPoints;
        }

        /// <summary>
        /// Convert all the points to integer data types
        /// </summary>
        /// <returns></returns>
        public MyPointIntList ConvertToIntList()
        {
            MyPointIntList screenPoints = new MyPointIntList();
            MyPointInt currPoint = null;


            screenPoints.MinX = (int)this.MinX;
            screenPoints.MaxX = (int)this.MaxX;
            screenPoints.MinY = (int)this.MinY;
            screenPoints.MaxY = (int)this.MaxY;

            foreach(MyPoint currPt in this.points)
            {
                currPoint = currPt.ToMyPointInt(); 
                screenPoints.points.Add(currPoint);
            }

            return screenPoints;
        }

        /// <summary>
        /// Convert all the points to integer data types
        /// </summary>
        /// <returns></returns>
        public MyPointIntList ConvertToIntListAndFlipVertically(int height)
        {
            MyPointIntList screenPoints = new MyPointIntList();
            MyPointInt currPoint = null;


            screenPoints.MinX = (int)this.MinX;
            screenPoints.MaxX = (int)this.MaxX;
            screenPoints.MinY = height - (int)this.MinY;
            screenPoints.MaxY = height - (int)this.MaxY;

            foreach (MyPoint currPt in this.points)
            {
                currPoint = currPt.ToMyPointInt();
                currPoint.Y = height - currPoint.Y;     // Flip the point vertically
                screenPoints.points.Add(currPoint);
            }

            return screenPoints;
        }

        public void AddRange(MyPointList newPoints)
        {
            this.points.AddRange(newPoints.points);
        }

        public double MinXInList()
        {
            double min_val = double.MaxValue;


            foreach(MyPoint currVal in this.points)
                if (currVal.X < min_val)
                    min_val = currVal.X;

            return min_val;
        }

        public double MaxXInList()
        {
            double max_val = double.MinValue;


            foreach (MyPoint currVal in this.points)
                if (currVal.X > max_val)
                    max_val = currVal.X;

            return max_val;
        }

        public double MinYInList()
        {
            double min_val = double.MaxValue;


            foreach (MyPoint currVal in this.points)
                if (currVal.Y < min_val)
                    min_val = currVal.Y;

            return min_val;
        }

        public double MaxYInList()
        {
            double max_val = double.MinValue;


            foreach (MyPoint currVal in this.points)
                if (currVal.Y > max_val)
                    max_val = currVal.Y;

            return max_val;
        }

        /// <summary>
        /// Get points that are within a certain radius of a given point
        /// </summary>
        /// <param name="x">Not the screen 'X', but the horizontal position on the map</param>
        /// <param name="y">Not the screen 'Y', but the vertical position on the map</param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public List<int> GetNearbyPoints(double x, double y, double radius)
        {
            List<int> nearbyPoints = new List<int>();


            nearbyPoints.Clear();

            MyPoint currPt;
            for (int i = 0; i < this.points.Count; i++)
            {
                currPt = this.points[i];
                if (Math.Sqrt((currPt.X - x) * (currPt.X - x) + (currPt.Y - y) * (currPt.Y - y)) <= radius)
                    nearbyPoints.Add(i);
            }

            return nearbyPoints;
        }

        public int AddPointsToList(List<MyPoint> newPoints)
        {
            int numPointsAdded = 0;

            foreach(MyPoint currPt in newPoints)
            {
                if (!this.points.Contains(currPt))
                {
                    this.points.Add(currPt);
                    numPointsAdded++;
                }
            }

            return numPointsAdded;
        }

        public override string ToString()
        {
            string str = "";
            foreach (MyPoint currPt in this.points)
            {
                str += currPt.ToString() + "\n";

                if (str.Length > 1000)
                {
                    str += "...\n";
                    break;
                }
            }
            return str;
        }

        #endregion

    }
}
