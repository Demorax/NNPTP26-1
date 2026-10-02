using System;
using System.Globalization;

namespace NNPTPZ1
{
    /// <summary>
    /// Size of the output image and the rendered area of the complex plane.
    /// </summary>
    public class FractalSettings
    {
        public const string Usage = "Usage: NNPTPZ1 <width> <height> <xmin> <xmax> <ymin> <ymax> [output]";
        public const string DefaultOutputPath = "../../../out.png";

        public int Width { get; set; }
        public int Height { get; set; }
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }
        public string OutputPath { get; set; } = DefaultOutputPath;

        public double XStep => (XMax - XMin) / Width;
        public double YStep => (YMax - YMin) / Height;

        /// <summary>
        /// Expected arguments: width height xmin xmax ymin ymax [output]
        /// </summary>
        /// <exception cref="ArgumentException">wrong number of arguments or invalid value</exception>
        public static FractalSettings FromArguments(string[] args)
        {
            if (args.Length < 6 || args.Length > 7)
                throw new ArgumentException("Wrong number of arguments.");

            FractalSettings settings = new FractalSettings()
            {
                Width = ParseInt(args[0], "width"),
                Height = ParseInt(args[1], "height"),
                XMin = ParseDouble(args[2], "xmin"),
                XMax = ParseDouble(args[3], "xmax"),
                YMin = ParseDouble(args[4], "ymin"),
                YMax = ParseDouble(args[5], "ymax")
            };

            if (args.Length == 7)
                settings.OutputPath = args[6];

            if (settings.Width <= 0 || settings.Height <= 0)
                throw new ArgumentException("Width and height must be positive.");

            return settings;
        }

        private static int ParseInt(string value, string name)
        {
            if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result))
                throw new ArgumentException($"Invalid {name}: '{value}'.");

            return result;
        }

        private static double ParseDouble(string value, string name)
        {
            if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
                throw new ArgumentException($"Invalid {name}: '{value}'.");

            return result;
        }
    }
}
