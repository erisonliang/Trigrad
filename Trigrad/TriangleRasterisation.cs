﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Trigrad.DataTypes;

namespace Trigrad
{
    internal static class TriangleRasterization
    {
        public static IEnumerable<Calculation> BuildTriCalculations(SampleTri t)
        {
            int minX = t.U.Point.X < t.V.Point.X && t.U.Point.X < t.W.Point.X ? t.U.Point.X : (t.V.Point.X < t.W.Point.X ? t.V.Point.X : t.W.Point.X);
            int minY = t.U.Point.Y < t.V.Point.Y && t.U.Point.Y < t.W.Point.Y ? t.U.Point.Y : (t.V.Point.Y < t.W.Point.Y ? t.V.Point.Y : t.W.Point.Y);

            int maxX = t.U.Point.X > t.V.Point.X && t.U.Point.X > t.W.Point.X ? t.U.Point.X : (t.V.Point.X > t.W.Point.X ? t.V.Point.X : t.W.Point.X);
            int maxY = t.U.Point.Y > t.V.Point.Y && t.U.Point.Y > t.W.Point.Y ? t.U.Point.Y : (t.V.Point.Y > t.W.Point.Y ? t.V.Point.Y : t.W.Point.Y);

            for (int x = minX; x < maxX + 1; x++)
            {
                for (int y = minY; y < maxY + 1; y++)
                {
                    Point p = new Point(x, y);

                    Calculation c = new Calculation();
                    c.A = t.U.Point;
                    c.B = t.V.Point;
                    c.C = t.W.Point;

                    c.P = p;
                    c.Tri = t;

                    yield return c;
                }
            }
        }
        public static IEnumerable<DrawPoint> PointsInTriangle(SampleTri t)
        {
            int minX = t.U.Point.X < t.V.Point.X && t.U.Point.X < t.W.Point.X ? t.U.Point.X : (t.V.Point.X < t.W.Point.X ? t.V.Point.X : t.W.Point.X);
            int minY = t.U.Point.Y < t.V.Point.Y && t.U.Point.Y < t.W.Point.Y ? t.U.Point.Y : (t.V.Point.Y < t.W.Point.Y ? t.V.Point.Y : t.W.Point.Y);

            int maxX = t.U.Point.X > t.V.Point.X && t.U.Point.X > t.W.Point.X ? t.U.Point.X : (t.V.Point.X > t.W.Point.X ? t.V.Point.X : t.W.Point.X);
            int maxY = t.U.Point.Y > t.V.Point.Y && t.U.Point.Y > t.W.Point.Y ? t.U.Point.Y : (t.V.Point.Y > t.W.Point.Y ? t.V.Point.Y : t.W.Point.Y);

            for (int x = minX; x < maxX + 1; x++)
            {
                for (int y = minY; y < maxY + 1; y++)
                {
                    Point p = new Point(x, y);

                    var coords = Barycentric.GetCoordinates(p, t.U.Point,t.V.Point,t.W.Point);

                    if (Barycentric.ValidCoords(coords))
                    {
                        yield return new DrawPoint(coords, p);
                    }
                }
            }
        }

        public static void CalculateMesh(List<SampleTri> mesh)
        {
            foreach (var t in mesh)
            {
                t.Points = PointsInTriangle(t).ToList();
            }
        }
    }
}
