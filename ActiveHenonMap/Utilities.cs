using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Man2
{
    public static class Utilities
    {
        public static int SurfaceWidth = 0;
        public static int SurfaceHeight = 0;
        public static double MinX = 0;
        public static double MaxX = 0;
        public static double MinY = 0;
        public static double MaxY = 0;
        public static double scaleX = 0;
        public static double scaleY = 0; 


        public static void SetRatios()
        {
            scaleX = (double)SurfaceWidth  / (MaxX - MinX);
            scaleY = (double)SurfaceHeight / (MaxY - MinY);
        }

        public static MyPointInt ConvertToScreenCoordinates(double map_X, double map_Y, Color pt_color, int diameter)
        {
            if (SurfaceWidth == 0 || SurfaceHeight == 0)
            {
                throw new Exception("SurfaceWidth and SurfaceHeight must be set before calling ConvertToScreenCoordinates");
            }

            return new MyPointInt((int)((map_X - MinX) * scaleX),
                                  (int)((map_Y - MinY) * scaleY),
                                  pt_color,
                                  diameter);
        }


        // public static MyPointList AddXYAxis()
        // {
        //     MyPointIntList
        // }


        public static MyPoint ConvertFromScreenCoordinates(MyPointInt pt)
        {
            if (SurfaceWidth == 0 || SurfaceHeight == 0)
            {
                throw new Exception("SurfaceWidth and SurfaceHeight must be set before calling ConvertToScreenCoordinates");
            }

            double x = (pt.X / scaleX) + MinX;
            double y = (pt.Y / scaleY) + MinY;

            return new MyPoint(x, y, pt.ptColor, pt.Diameter);
        }
    }
}
