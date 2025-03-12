using Man2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveHenonMap
{
    public class HenonMapData: IDisposable
    {

        #region Properties

        public double PhaseAngle { get; set; }
        public double StartingX { get; set; }
        public double StartingY { get; set; }
        public double IncrementX { get; set; }
        public double IncrementY { get; set; }

        public int NumOrbits { get; set; }
        public int PtsPerOrbit { get; set; }

        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }

        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }

        #endregion



        #region String versions of properties

        public string sPhaseAngle { 
            set
            {
                double pa = 0;

                if (double.TryParse(value, out pa))
                    this.PhaseAngle = pa;
                else
                    this.PhaseAngle = 0.0;
            }
        }

        public string sStartingX
        {
            set
            {
                double sx = 0;

                if (double.TryParse(value, out sx))
                    this.StartingX = sx;
                else
                    this.StartingX = 0.0;
            }
        }

        public string sStartingY
        {
            set
            {
                double sy = 0;

                if (double.TryParse(value, out sy))
                    this.StartingY = sy;
                else
                    this.StartingY = 0.0;
            }
        }

        public string sIncrementX
        {
            set
            {
                double ix = 0;

                if (double.TryParse(value, out ix))
                    this.IncrementX = ix;
                else
                    this.IncrementX = 0.0;
            }
        }

        public string sIncrementY
        {
            set
            {
                double sy = 0;

                if (double.TryParse(value, out sy))
                    this.IncrementY = sy;
                else
                    this.IncrementY = 0.0;
            }
        }

        public string sNumOrbits
        {
            set
            {
                int no = 0;

                if (int.TryParse(value, out no))
                    this.NumOrbits = no;
                else
                    this.NumOrbits = 0;
            }
        }

        public string sPtsPerOrbit
        {
            set
            {
                int po = 0;

                if (int.TryParse(value, out po))
                    this.PtsPerOrbit = po;
                else
                    this.PtsPerOrbit = 0;
            }
        }

        public string sMinX
        {
            set
            {
                double po = 0;

                if (double.TryParse(value, out po))
                    this.MinX = po;
                else
                    this.MinX = 0;
            }
        }
        public string sMaxX
        {
            set
            {
                double po = 0;

                if (double.TryParse(value, out po))
                    this.MaxX = po;
                else
                    this.MaxX = 0;
            }
        }
        public string sMinY
        {
            set
            {
                double po = 0;

                if (double.TryParse(value, out po))
                    this.MinY = po;
                else
                    this.MinY = 0;
            }
        }
        public string sMaxY
        {
            set
            {
                double po = 0;

                if (double.TryParse(value, out po))
                    this.MaxY = po;
                else
                    this.MaxY = 0;
            }
        }

        public string sImageWidth
        {
            set
            {
                int no = 0;

                if (int.TryParse(value, out no))
                    this.ImageWidth = no;
                else
                    this.ImageWidth = 0;
            }
        }
        public string sImageHeight
        {
            set
            {
                int po = 0;

                if (int.TryParse(value, out po))
                    this.ImageHeight = po;
                else
                    this.ImageHeight = 0;
            }
        }

        #endregion



        #region Constructors

        public HenonMapData(double phaseAngle, double startingX, double startingY,
                            double incrementX, double incrementY,
                            int numOrbits, int ptsPerOrbit,
                            double minX, double maxX, double minY, double maxY,
                            int imgWidth, int imgHeight)
        {
            this.PhaseAngle     = phaseAngle;
            this.StartingX      = startingX;
            this.StartingY      = startingY;
            this.IncrementX     = incrementX;
            this.IncrementY     = incrementY;
            this.NumOrbits      = numOrbits;
            this.PtsPerOrbit    = ptsPerOrbit;
            this.MinX           = minX;
            this.MaxX           = maxX;
            this.MinY           = minY;
            this.MaxY           = maxY;
            this.ImageWidth     = imgWidth;
            this.ImageHeight    = imgHeight;
        }

        public HenonMapData(double phaseAngle, double startingX, double startingY,
                            double incrementX, double incrementY,
                            int numOrbits, int ptsPerOrbit) : this(phaseAngle, startingX, startingY, incrementX, incrementY, numOrbits, ptsPerOrbit, -1.0, 1.0, -1.0, 1.0, 1, 1) { }

        public HenonMapData() : this(0.0, 0.0, 0.0, 0.0, 0.0, 0, 0, 0.0, 0.0, 0.0, 0.0, 0, 0) { }



        public HenonMapData(string phaseAngle, string startingX, string startingY,
                            string incrementX, string incrementY,
                            string numOrbits, string ptsPerOrbit,
                            string minX, string maxX, string minY, string maxY,
                            string imgWidth, string imgHeight)
        {
            this.sPhaseAngle    = phaseAngle;
            this.sStartingX     = startingX;
            this.sStartingY     = startingY;
            this.sIncrementX    = incrementX;
            this.sIncrementY    = incrementY;
            this.sNumOrbits     = numOrbits;
            this.sPtsPerOrbit   = ptsPerOrbit;
            this.sMinX          = minX;
            this.sMaxX          = maxX;
            this.sMinY          = minY;
            this.sMaxY          = maxY;
            this.sImageWidth    = imgWidth;
            this.sImageHeight   = imgHeight;
        }

        public HenonMapData(string phaseAngle, string startingX, string startingY,
                            string incrementX, string incrementY,
                            string numOrbits, string ptsPerOrbit) : this(phaseAngle, startingX, startingY, incrementX, incrementY, numOrbits, ptsPerOrbit, "-1", "1", "-1", "1", "1", "1") { }


        public MyPointList HenonMapPoints { get; set; }

        #endregion



        #region Other Methods

        public override string ToString()
        {
            return $"A: {this.PhaseAngle}, start: ({this.StartingX}, {this.StartingY})...";
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public HenonMapData Clone()
        {
            return new HenonMapData(PhaseAngle, StartingX, StartingY, IncrementX, IncrementY, NumOrbits, PtsPerOrbit, MinX, MaxX, MinY, MaxY, ImageWidth, ImageHeight);
        }

        #endregion

    }
}
