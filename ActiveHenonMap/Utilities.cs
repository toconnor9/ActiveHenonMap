using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                                  (int)((MaxY - map_Y) * scaleY),
                                  pt_color,
                                  diameter);
        }

        public static MyPoint ConvertFromScreenCoordinates(int image_X, int image_Y)
        {
            return ConvertFromScreenCoordinates(new MyPointInt(image_X, image_Y));

            //if (SurfaceWidth == 0 || SurfaceHeight == 0)
            //{
            //    throw new Exception("SurfaceWidth and SurfaceHeight must be set before calling ConvertToScreenCoordinates");
            //}

            //return new MyPoint((((double)image_X / scaleX) + MinX),
            //                   (MaxY - ((double)image_Y / scaleY)));
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

            double x = ((double)pt.X / scaleX) + MinX;     // (pt.X / scaleX) + MinX;
            double y = MaxY - ((double)pt.Y / scaleY);     // (pt.Y / scaleY) + MinY;

            return new MyPoint(x, y, pt.ptColor, pt.Diameter);
        }
    }
}
