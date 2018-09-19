using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    public class Border
    {
        public List<Line> Lines = new List<Line>();

        public Border(Window w)
        {
            Point2D topLeft = new Point2D() {X = 0, Y = 0};
            Point2D bottomLeft = new Point2D() {X = 0, Y = w.Height};
            Point2D topRight = new Point2D() {X = w.Width, Y = 0};
            Point2D bottomRight = new Point2D() {X = w.Width, Y = w.Height};

            Line leftLine = new Line()
            {
                StartPoint = new Point2D() {X = 0, Y = 0}, 
                EndPoint = new Point2D() {X = 0, Y = w.Height}
            };

            Line rightLine = new Line()
            {
                StartPoint = new Point2D() {X = w.Width, Y = 0}, 
                EndPoint = new Point2D() {X = w.Width, Y = w.Height}
            };

            Lines.Add(leftLine);
            Lines.Add(rightLine);
        }
    }
}