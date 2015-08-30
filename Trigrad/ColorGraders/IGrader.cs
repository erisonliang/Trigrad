﻿using System.Drawing;
using Trigrad.DataTypes;

namespace Trigrad.ColorGraders
{
    /// <summary> Interface for producing color graders. </summary>
    public interface IGrader
    {
        /// <summary> Base method for color grading. </summary>
        Color Grade(Sample u, Sample v, Sample w, DrawPoint p);
    }
}
