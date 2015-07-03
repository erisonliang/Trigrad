﻿using System.Drawing;

namespace Trigrad.DataTypes
{
    /// <summary> The results of a TrigradDecompression, containing both the output and debug bitmaps. </summary>
    public class TrigradDecompressed
    {
        /// <summary> Constructor for a TrigradDecompressed object, defining the width and height of output bitmaps. </summary>
        public TrigradDecompressed(int width, int height)
        {
            Output = new Bitmap(width, height);
            DebugOutput = new Bitmap(width, height);
        }
        /// <summary> The decompressed output bitmap. </summary>
        public Bitmap Output;
        /// <summary> The debug output bitmap, showing calculated barycentric coordinates. </summary>
        public Bitmap DebugOutput;
    }
}
