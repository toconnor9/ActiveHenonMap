using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Man2
{
    
    public class MyPointInt
    {
        
        #region Properties
        
        public int X { get; set; }
        public int Y { get; set; }
        public Color ptColor { get; set; }
        public int Diameter { get; set; }

        #endregion


        #region Constructor

        public MyPointInt(int x, int y, Color ptColor, int diameter)
        {
            this.X = x;
            this.Y = y;
            this.ptColor = ptColor;
            this.Diameter = diameter;
        }

        public MyPointInt(int x, int y, Color ptColor) : this(x, y, ptColor, 1) { }

        public MyPointInt(int x, int y) : this(x, y, Color.Black, 1) { }

        public MyPointInt() : this(0, 0, Color.Black) { }

        #endregion


        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }

    public class MyPointIntList
    {

        #region Properties

        public List<MyPointInt> points { get; set; }

        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinY { get; set; }
        public int MaxY { get; set; }

        #endregion


        #region Constructor

        public MyPointIntList()
        {
            points = new List<MyPointInt>();
        }

        #endregion


        #region Public Methods
        
        public void AddRange(MyPointIntList newPoints)
        {
            this.points.AddRange(newPoints.points);
        }

        public int Add(List<MyPointInt> newPoints)
        {
            int numPointsAdded = 0;

            foreach (MyPointInt currPt in newPoints)
            {
                if (!this.points.Contains(currPt))
                {
                    this.points.Add(currPt);
                    numPointsAdded++;
                }
            }

            return numPointsAdded;
        }

        public void Add(MyPointInt newPoint)
        {
            this.points.Add(newPoint);
        }

        public void Add(int newX, int newY, Color color, int diameter)
        {
            this.points.Add(new MyPointInt(newX, newY, color, diameter));
        }

        public void Add(int newX, int newY)
        {
            this.points.Add(new MyPointInt(newX, newY));
        }

        #endregion

        #region Indexer

        public MyPointInt this[int index]
        {
            get { return this.points[index]; }
            set { this.points[index] = value; }
        }

        // public Enumerator<MyPointIntList> Enumerator GetEnumerator()
        // {
        //     return this.points.GetEnumerator();
        // }

        #endregion

    }
}
