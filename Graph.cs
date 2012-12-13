using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpreadInformer
{
    class Graph
    {
        double[] points;

        int FindMax()
        {
            int max = 0;
            for (int i = 1; i < points.Count(); i++)
            {
                if (points[i] > points[max])
                    max = i;
            }

            return max;
        }

        int FindMin()
        {
            int min = 0;

            for (int i = 0; i < points.Count(); i++)
            {
                if (points[i] < points[min])
                    min = i;
            }

            return min;
        }

        /// <summary>
        /// Set points of chart
        /// </summary>
        /// <param name="p">Table of points</param>
        public void SetPoints(double[] p)
        {
            points = p;
        }

        public void DrawGraph(Graphics e, int width, int height)
        {
            double d = points[FindMax()] - points[FindMin()];

            //if (d < 0.0001)
           //     d = 0.0001;

            width -= 40;
            height = height/2;

            int dx = width / (points.Count()-1);

            Point[] p_s = new Point[points.Count()];

            for (int i = 0; i < points.Count(); i++)
            {
                p_s[i].X = (dx * i) + 10;
                p_s[i].Y = (int)(((points[i] - points[FindMin()]) / d) * (-height)) + (height) + (height / 2);
            }

            Pen pen2 = new Pen(Color.DarkGray, 0.2f);
            for (int i = 1; i < 10; i++)
            {
                e.DrawLine(pen2, new Point(10, (int)((0.1 * i) * height + (height / 2))), new Point(width - 10, (int)((0.1 * i) * height + (height / 2))));
            }

            Pen pen = new Pen(Color.LightGray, 3);
            e.DrawLines(pen, p_s);
        }

    }
}
