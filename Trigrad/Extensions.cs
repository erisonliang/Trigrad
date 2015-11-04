﻿using System.Collections.Generic;
using TriangleNet.Data;
using System.Drawing;
using PixelMapSharp;
using TriangleNet;
using Trigrad.DataTypes;

namespace Trigrad
{
    public static class Extensions
    {
        public static Point Point(this Vertex t)
        {
            return new Point((int)t.X, (int)t.Y);
        }

        public static PixelMap DrawMesh(this List<SampleTri> m,int width,int height)
        {
            Bitmap b = new Bitmap(width,height);
            Graphics g = Graphics.FromImage(b);


            foreach (var sampleTri in m)
            {
                g.DrawLine(new Pen(sampleTri.U.Color.Color), sampleTri.U.Point, sampleTri.V.Point);
                g.DrawLine(new Pen(sampleTri.U.Color.Color), sampleTri.V.Point, sampleTri.W.Point);
                g.DrawLine(new Pen(sampleTri.U.Color.Color), sampleTri.W.Point, sampleTri.U.Point);
            }

            return new PixelMap(b);
        }
    }
}
