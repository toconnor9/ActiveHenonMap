using ActiveHenonMap;
using System;
using System.Drawing;


namespace Man2
{
    public static class HenonMap
    {
        public static MyPointList Calculate(HenonMapData data)
        {
            MyPointList allPoints = new MyPointList();
            MyPoint currPoint = new MyPoint();

            double lastX, lastY;
            double currX, currY;
            int currPt = 0;

            double COSA = Math.Cos(data.PhaseAngle);
            double SINA = Math.Sin(data.PhaseAngle);


            for (int J = 0; J < data.NumOrbits; J++)
            {
                lastX = data.StartingX + (J * data.IncrementX);
                lastY = data.StartingY + (J * data.IncrementY);

                for (int I = 0; I < data.PtsPerOrbit; I++)
                {
                    currX = (lastX * COSA) - ((lastY - (lastX * lastX)) * SINA);
                    currY = (lastX * SINA) + ((lastY - (lastX * lastX)) * COSA);

                    currPoint = new MyPoint(currX, currY, Color.Black, 1);

                    allPoints.points.Add(currPoint);

                    lastX = currX;
                    lastY = currY;

                    currPt++;
                }
            }


            return allPoints;
        }

        public static MyPointList Calculate(double phaseAngle,
                                            double startingPtX, double startingPtY,
                                            double incrementX, double incrementY,
                                            int numberOfOrbits, int pointsPerOrbit)
        {
            MyPointList allPoints = new MyPointList();
            HenonMapData data = new HenonMapData(phaseAngle,
                                                 startingPtX,    startingPtY,
                                                 incrementX,     incrementY,
                                                 numberOfOrbits, pointsPerOrbit);

            return Calculate(data);
        }
    }
}
