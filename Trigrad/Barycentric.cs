﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleNet.Data;

namespace Trigrad
{
    static class Barycentric
    {
        public static BarycentricCoordinates GetCoordinates(Point Pp, Vertex Pa, Vertex Pb, Vertex Pc)
        {
            double[] p = { Pp.X, Pp.Y };
            double[] a = { Pa.X, Pa.Y };
            double[] b = { Pb.X, Pb.Y };
            double[] c = { Pc.X, Pc.Y };

            double[] v0 = { b[0] - a[0], b[1] - a[1] };
            double[] v1 = { c[0] - a[0], c[1] - a[1] };
            double[] v2 = { p[0] - a[0], p[1] - a[1] };
            double d00 = dotProduct(v0, v0);
            double d01 = dotProduct(v0, v1);
            double d11 = dotProduct(v1, v1);
            double d20 = dotProduct(v2, v0);
            double d21 = dotProduct(v2, v1);
            double denom = d00 * d11 - d01 * d01;
            double v = ((d11 * d20 - d01 * d21) / denom);
            double w = ((d00 * d21 - d01 * d20) / denom);
            double u = (1.0f - v - w);

            return new BarycentricCoordinates(u, v, w);
        }

        private static double dotProduct(double[] a, double[] b)
        {
            return a.Zip(b, (x, y) => x * y).Sum();
        }
    }
    internal struct BarycentricCoordinates
    {
        public BarycentricCoordinates(double u, double v, double w)
        {
            U = u;
            V = v;
            W = w;
        }
        public double U;
        public double V;
        public double W;
    }
}