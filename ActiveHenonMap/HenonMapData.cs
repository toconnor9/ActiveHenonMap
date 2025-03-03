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
        public double PhaseAngle { get; set; }
        public double StartingX { get; set; }
        public double StartingY { get; set; }
        public double IncrementX { get; set; }
        public double IncrementY { get; set; }

        public int NumOrbits { get; set; }
        public int PtsPerOrbit { get; set; }

        
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


        public HenonMapData(double phaseAngle, double startingX, double startingY,
                            double incrementX, double incrementY,
                            int numOrbits, int ptsPerOrbit)
        {
            this.PhaseAngle = phaseAngle;
            this.StartingX = startingX;
            this.StartingY = startingY;
            this.IncrementX = incrementX;
            this.IncrementY = incrementY;
            this.NumOrbits = numOrbits;
            this.PtsPerOrbit = ptsPerOrbit;
        }

        public HenonMapData() : this(0.0, 0.0, 0.0, 0.0, 0.0, 0, 0) { }

        public HenonMapData(string phaseAngle, string startingX, string startingY,
                            string incrementX, string incrementY,
                            string numOrbits, string ptsPerOrbit)
        {
            this.sPhaseAngle = phaseAngle;
            this.sStartingX = startingX;
            this.sStartingY = startingY;
            this.sIncrementX = incrementX;
            this.sIncrementY = incrementY;
            this.sNumOrbits = numOrbits;
            this.sPtsPerOrbit = ptsPerOrbit;
        }


        public MyPointList HenonMapPoints { get; set; }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
